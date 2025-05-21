using System;
using System.Collections.Generic;

namespace SklepMotoryzacyjny
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        public IReadOnlyList<CartItem> Items => items.AsReadOnly();

        public void AddToCart(Product product, int qty)
        {
            if (qty <= 0)
                throw new ArgumentException("Ilość musi być większa niż zero.");
            if (qty > product.Stock)
                throw new ArgumentException("Nie można dodać więcej niż jest na stanie.");

            var existing = items.Find(i => i.Product.Id == product.Id);
            if (existing != null)
            {
                if (existing.Quantity + qty > product.Stock)
                    throw new ArgumentException("Nie można dodać więcej niż jest na stanie.");
                existing.Quantity += qty;
            }
            else
            {
                items.Add(new CartItem { Product = product, Quantity = qty });
            }
        }

        public bool RemoveFromCart(int productId)
        {
            var item = items.Find(i => i.Product.Id == productId);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public void DisplayCart()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Koszyk jest pusty.");
                return;
            }

            Console.WriteLine("\n--- Zawartość koszyka ---");
            foreach (var i in items)
            {
                decimal lineTotal = i.Product.Price * i.Quantity;
                Console.WriteLine($"ID: {i.Product.Id}\tNazwa: {i.Product.Name}\tCena: {i.Product.Price:C}\tIlość: {i.Quantity}\tRazem: {lineTotal:C}");
            }
        }

        public decimal CalculateTotal()
        {
            decimal sum = 0;
            foreach (var i in items)
                sum += i.Product.Price * i.Quantity;
            return sum;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}

