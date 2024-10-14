using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public virtual double CalculateCost(double basePrice, int currentYear)
        {
            return basePrice;
        }
    }

    public class SportsCar : Car
    {
        public override double CalculateCost(double basePrice, int currentYear)
        {
            double fixedTaxRate = 0.10;
            int age = currentYear - Year;
            double totalTax = basePrice * fixedTaxRate * age;
            return basePrice + totalTax;
        }
    }

    public class SUV : Car
    {
        public override double CalculateCost(double basePrice, int currentYear)
        {
            double fixedTaxRate = 0.05;
            int age = currentYear - Year;
            double totalTax = basePrice * fixedTaxRate * age;
            return basePrice + totalTax;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. Sports car");
            Console.WriteLine("2. SUV car");
            Console.WriteLine("3. None of the above");
            Console.Write("Choose the option: ");
            int choice = int.Parse(Console.ReadLine());

            Car car;

            if (choice == 1)
            {
                car = new SportsCar();
            }
            else if (choice == 2)
            {
                car = new SUV();
            }
            else
            {
                car = new Car();
            }

            Console.Write("Enter the make: ");
            car.Make = Console.ReadLine();

            Console.Write("Enter the model: ");
            car.Model = Console.ReadLine();

            Console.Write("Enter the year the car was made: ");
            car.Year = int.Parse(Console.ReadLine());

            Console.Write("Enter the basic price: ");
            double basePrice = double.Parse(Console.ReadLine());

            Console.Write("Enter the current year: ");
            int currentYear = int.Parse(Console.ReadLine());

            double totalCost = car.CalculateCost(basePrice, currentYear);

            if (choice == 1)
            {
                Console.WriteLine("Sports car cost is " + totalCost);
            }
            else if (choice == 2)
            {
                Console.WriteLine("SUV car cost is " + totalCost);
            }
            else
            {
                Console.WriteLine("The cost is " + totalCost);
            }
        }
    }
}