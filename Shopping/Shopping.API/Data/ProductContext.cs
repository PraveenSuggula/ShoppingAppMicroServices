using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            //var coindesk= new 
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }

        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p=> true).Any();
            if (existProduct)
            {
                productCollection.DeleteManyAsync(prop => true);
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
            else
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }
        public static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
            {
                Name = "OPPO f3 Plus",
                Description = "This phone is the company's biggest change to its flagship smartphone in 2023",
                ImageFile = "product-1.png",
                Price = 24567.00M,
                Category = "Smart Phone"
            },
            new Product()
            {
                Name = "Samsung M32",
                Description = "This phone is the company's biggest change to its flagship smartphone in 2020",
                ImageFile = "product-2.png",
                Price = 13235.68M,
                Category = "Smart Phone"
            },
            new Product()
            {
                Name = "OnePlus 8T",
                Description = "This phone is the company's biggest change to its flagship smartphone in 2020",
                ImageFile = "product-3.png",
                Price = 43339.57M,
                Category = "Smart Phone"
            },
            new Product()
            {
                Name = "IPhone X",
                Description = "This phone is the company's biggest change to its flagship smartphone in 2020",
                ImageFile = "product-4.png",
                Price = 98549.99M,
                Category = "Smart Phone"
            },
            new Product()
            {
                Name = "OnePlus nord 2",
                Description = "This phone is the company's biggest change to its flagship smartphone in 2020",
                ImageFile = "product-4.png",
                Price = 29999.00M,
                Category = "Smart Phone"
            }
            };
        }

    }
}
