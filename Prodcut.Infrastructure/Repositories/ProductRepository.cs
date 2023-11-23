using MongoDB.Driver;
using Product.Application.Contracts.Persistence;
using Product.domain.Entities;
using Product.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }        

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<ProductModel> GetProduct(int id)
        {
            return await _context
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string name)
        {
            FilterDefinition<ProductModel> filter = Builders<ProductModel>.Filter.Eq(p => p.Name, name);

            return await _context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<ProductModel> filter = Builders<ProductModel>.Filter.Eq(p => p.Category, categoryName);

            return await _context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateProduct(ProductModel Product)
        {
            await _context.Products.InsertOneAsync(Product);
        }

        public async Task<bool> UpdateProduct(ProductModel Product)
        {
            var updateResult = await _context
                                        .Products
                                        .ReplaceOneAsync(filter: g => g.Id == Product.Id, replacement: Product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            FilterDefinition<ProductModel> filter = Builders<ProductModel>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
