using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{

    class Candy
    {
        public string Flavour { get; set; }
        public int Quantity { get; set; }
        public int PricePerPiece { get; set; }
        public double TotalPrice { get; set; }

        public bool ValidateCandyFlavour()
        {
            return Flavour.ToUpper() == "STRAWBERRY" || Flavour.ToUpper() == "LEMON" || Flavour.ToUpper() == "MINT";
        }
    }

    class Program
    {
        public static Candy CalculateDiscountedPrice(Candy candy)
        {
            candy.TotalPrice = candy.Quantity * candy.PricePerPiece;

            double discountPercentage = 0;
            switch (candy.Flavour.ToUpper())
            {
                case "STRAWBERRY":
                    discountPercentage = 15;
                    break;
                case "LEMON":
                    discountPercentage = 10;
                    break;
                case "MINT":
                    discountPercentage = 5;
                    break;
                default:
                    // This shouldn't happen as validation ensures valid flavours
                    break;
            }

            candy.TotalPrice -= candy.TotalPrice * discountPercentage / 100;
            return candy;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the flavour: ");
            string flavour = Console.ReadLine();

            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the price per piece: ");
            int pricePerPiece = int.Parse(Console.ReadLine());

            Candy candy = new Candy
            {
                Flavour = flavour,
                Quantity = quantity,
                PricePerPiece = pricePerPiece
            };

            if (candy.ValidateCandyFlavour())
            {
                candy = CalculateDiscountedPrice(candy);
                Console.WriteLine("\nFlavour : {0}", candy.Flavour);
                Console.WriteLine("Quantity : {0}", candy.Quantity);
                Console.WriteLine("Price Per Piece : {0}", candy.PricePerPiece);
                Console.WriteLine("Total Price : {0:F2}", candy.TotalPrice); // Formatted to 2 decimal places
                Console.WriteLine("Discount Price : {0:F2}", candy.TotalPrice); // Discount price is the same as the final total price
            }
            else
            {
                Console.WriteLine("Invalid flavour");
            }
        }
    }
}