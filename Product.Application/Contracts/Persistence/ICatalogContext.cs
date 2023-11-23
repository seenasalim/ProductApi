using MongoDB.Driver;
using Product.domain.Entities;

namespace Product.Application.Contracts.Persistence
{
    public interface ICatalogContext
    {
        IMongoCollection<ProductModel> Products { get; }
    }
}
