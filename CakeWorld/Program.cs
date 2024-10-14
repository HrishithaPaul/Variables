using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Cake
    {
        public string Flavour { get; set; }
        public int QuantityInKg { get; set; }
        public double PricePerKg { get; set; }

        public bool CakeOrder()
        {
            try
            {
                if (Flavour != "Vanilla" && Flavour != "Chocolate" && Flavour != "Red Velvet")
                {
                    throw new InvalidFlavourException("Flavour not available. Please select the available flavour");
                }

                if (QuantityInKg <= 0)
                {
                    throw new Exception("Quantity must be greater than zero");
                }

                return true;
            }
            catch (InvalidFlavourException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public double CalculatePrice()
        {
            double totalCost = QuantityInKg * PricePerKg;

            double discount = 0;
            if (Flavour == "Vanilla")
            {
                discount = 3;
            }
            else if (Flavour == "Chocolate")
            {
                discount = 5;
            }
            else if (Flavour == "Red Velvet")
            {
                discount = 10;
            }

            double discountedPrice = totalCost - (totalCost * discount / 100);

            return discountedPrice;
        }
    }

    public class InvalidFlavourException : Exception
    {
        public InvalidFlavourException(string message) : base(message)
        {
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the flavour: ");
            string flavour = Console.ReadLine();

            Console.Write("Enter the quantity in kg: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the price per kg: ");
            double pricePerKg = double.Parse(Console.ReadLine());

            Cake cake = new Cake
            {
                Flavour = flavour,
                QuantityInKg = quantity,
                PricePerKg = pricePerKg
            };

            try
            {
                if (cake.CakeOrder())
                {
                    Console.WriteLine("Cake order was successful");
                    double discountedPrice = cake.CalculatePrice();
                    Console.WriteLine("Price after discount is " + discountedPrice);
                }
            }
            catch (InvalidFlavourException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}