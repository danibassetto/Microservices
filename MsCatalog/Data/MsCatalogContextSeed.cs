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
                    Id = "507f1f77bcf86cd799439011",
                    Name = "Iphone X",
                    Description = "Iphone X",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Id = "507f1f77bcf86cd799439012",
                    Name = "Samsung Note10",
                    Description = "Samsung Note10",
                    Image = "product-2.png",
                    Price = 1000.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Id = "507f1f77bcf86cd799439013",
                    Name = "Redmi",
                    Description = "Redmi",
                    Image = "product-3.png",
                    Price = 700M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Id = "607f1f77bcf86cd799439014",
                    Name = "Havaianas",
                    Description = "Havaianas",
                    Image = "product-4.png",
                    Price = 100M,
                    Category = "Sapatos"
                }
            };
        }
    }
}