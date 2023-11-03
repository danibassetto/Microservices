using MongoDB.Driver;
using MsCatalog.Entities;

namespace MsCatalog.Data
{
    public interface IMsCatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}