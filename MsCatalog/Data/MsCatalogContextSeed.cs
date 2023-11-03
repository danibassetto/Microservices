using MongoDB.Driver;
using MsCatalog.Entities;

namespace MsCatalog.Data
{
    public class MsCatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "1",
                    Name = "Iphone X",
                    Description = "Iphone X",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Id = "2",
                    Name = "Samsung Note10",
                    Description = "Samsung Note10",
                    Image = "product-2.png",
                    Price = 1000.00M,
                    Category = "Smartphone"
                }
            };
        }
    }
}