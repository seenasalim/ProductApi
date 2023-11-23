using Product.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int id);
        Task<IEnumerable<ProductModel>> GetProductByName(string name);
        Task<IEnumerable<ProductModel>> GetProductByCategory(string categoryName);

        Task CreateProduct(ProductModel Product);
        Task<bool> UpdateProduct(ProductModel Product);
        Task<bool> DeleteProduct(int id);
    }
}
