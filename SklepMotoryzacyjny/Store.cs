using System.Collections.Generic;

namespace SklepMotoryzacyjny
{
    public class Store
    {
        private List<Product> products;

        public Store()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Olej silnikowy", Price = 99.99m, Stock = 10 },
                new Product { Id = 2, Name = "Filtr powietrza", Price = 49.50m, Stock = 15 },
                new Product { Id = 3, Name = "Świece zapłonowe", Price = 29.99m, Stock = 20 },
                new Product { Id = 4, Name = "Klocki hamulcowe", Price = 199.00m, Stock = 5 },
                new Product { Id = 5, Name = "Akumulator", Price = 350.00m, Stock = 3 }
            };
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\n--- Lista produktów ---");
            foreach (var p in products)
                Console.WriteLine($"ID: {p.Id}\tNazwa: {p.Name}\tCena: {p.Price:C}\tIlość: {p.Stock}");
        }

        public Product? GetProductById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public void UpdateStock(int id, int qty)
        {
            var prod = GetProductById(id);
            if (prod != null)
                prod.Stock -= qty;
        }
    }
}
