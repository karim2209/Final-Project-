using System;
using System.Xml.Linq;

namespace FianlProject.Models.Repositories
{
	public class ProductRepository
	{
        private static List<Product> products = new List<Product>()
        {
        new Product{Id = 1, Brand ="Apple", Color = "Silver", Price = 30,},
        new Product{Id = 2, Brand ="Dell", Color = "Black", Price = 40,},
        new Product{Id = 3, Brand ="Samsung", Color = "Blue", Price = 30},
        new Product{Id = 4, Brand ="Lenovo", Color = "Red", Price = 40},
        new Product{Id = 5, Brand ="Sony", Color = "White", Price = 10 }

        };
        public static List<Product> GetProducts()
        {
            return products;
        }
        public static bool ProductExists(int id)
        {
            return products.Any(x => x.Id == id);
        }
        public static Product? GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
        public static Product? GetProductByProperties(string? brand, string? color)
        {
            return products.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase)          
            );
        }
        public static void AddProduct(Product product)
        {
            int maxId = products.Max(x => x.Id);
            product.Id = maxId + 1;
            products.Add(product);
        }
        public static void UpdateProduct(Product product)
        {
            var productToUpdate = products.First(x => x.Id == product.Id);
            productToUpdate.Brand = product.Brand;
            productToUpdate.Price = product.Price;
            productToUpdate.Color = product.Color;
            
        }
        public static void Deleteproduct(int Id)
        {
            var product = GetProductById(Id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
}

