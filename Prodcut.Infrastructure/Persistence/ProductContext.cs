using Product.domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.Application.Contracts.Persistence;

namespace Product.Infrastructure.Persistence
{
    public class ProductContext : ICatalogContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient("mongodb+srv://seena:seenasalim@product.aattro9.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("Product");

            Products = database.GetCollection<ProductModel>("Products");
            ProductContextSeed.SeedData(Products);
        }

        public IMongoCollection<ProductModel> Products { get; }
    }
}
