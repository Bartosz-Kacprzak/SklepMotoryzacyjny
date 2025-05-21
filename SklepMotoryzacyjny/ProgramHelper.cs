using System;

namespace SklepMotoryzacyjny
{
    public static class ProgramHelper
    {
        public static void AddProductToCart(Store store, Cart cart)
        {
            Console.Write("Podaj ID produktu: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Product? product = store.GetProductById(id);
                if (product != null)
                {
                    Console.Write("Podaj ilość: ");
                    if (int.TryParse(Console.ReadLine(), out int qty))
                    {
                        try
                        {
                            cart.AddToCart(product, qty);
                            Console.WriteLine($"Dodano {qty} x {product.Name} do koszyka.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else Console.WriteLine("Nieprawidłowa ilość.");
                }
                else Console.WriteLine("Produkt o podanym ID nie istnieje.");
            }
            else Console.WriteLine("Nieprawidłowe ID.");
        }

        public static void RemoveProductFromCart(Cart cart)
        {
            Console.Write("Podaj ID produktu do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (cart.RemoveFromCart(id))
                    Console.WriteLine("Produkt usunięty z koszyka.");
                else
                    Console.WriteLine("Produkt nie występuje w koszyku.");
            }
            else Console.WriteLine("Nieprawidłowe ID.");
        }

        public static void FinalizePurchase(Store store, Cart cart)
        {
            Console.WriteLine("\n--- Podsumowanie zakupu ---");
            cart.DisplayCart();
            decimal total = cart.CalculateTotal();
            Console.WriteLine($"\nŁączna kwota: {total:C}");

            foreach (var item in cart.Items)
            {
                store.UpdateStock(item.Product.Id, item.Quantity);
            }

            cart.Clear();
            Console.WriteLine("Zakup sfinalizowany. Dziękujemy!");
        }
    }
}
