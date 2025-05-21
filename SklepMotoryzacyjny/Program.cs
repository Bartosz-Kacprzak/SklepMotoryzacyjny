using System;
using System.Collections.Generic;

namespace SklepMotoryzacyjny
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Cart cart = new Cart();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== SKLEP ===");
                Console.WriteLine("1. Wyświetl produkty");
                Console.WriteLine("2. Dodaj produkt do koszyka");
                Console.WriteLine("3. Usuń produkt z koszyka");
                Console.WriteLine("4. Pokaż koszyk");
                Console.WriteLine("5. Finalizuj zakup");
                Console.WriteLine("0. Wyjdź");
                Console.Write("Wybierz opcję: ");
                string? userInput;
                while (string.IsNullOrWhiteSpace(userInput = Console.ReadLine()))
                {
                    Console.Write("Pole nie może być puste. Wprowadź opcję ponownie: ");
                }
                string choice = userInput;

                switch (choice)
                {
                    case "1":
                        store.DisplayProducts();
                        break;
                    case "2":
                        ProgramHelper.AddProductToCart(store, cart);
                        break;
                    case "3":
                        ProgramHelper.RemoveProductFromCart(cart);
                        break;
                    case "4":
                        cart.DisplayCart();
                        break;
                    case "5":
                        ProgramHelper.FinalizePurchase(store, cart);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                }
            }
        }
    }
}

