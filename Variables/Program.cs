using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Movie name");
            string name = Console.ReadLine();
            Console.Write("Enter the ticket id");
            int ticketId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the seat number");
            string seatNumber = Console.ReadLine();
            Movie movie = new Movie().ReturnMovieDetails(name, ticketId, seatNumber);
            Console.WriteLine("Movie name : " + name);
            Console.WriteLine("Ticket id : " + ticketId);
            Console.WriteLine("Seat number : " + seatNumber);
        }
    }
    public class Movie
    {
        public static string name { get; set; }
        public int ticketId { get; set; }
        public string seatNumber { get; set; }

        public string MovieName { get; private set; }

        public Movie ReturnMovieDetails(string name, int ticketId, string seatNumber)
        {
            Movie movie = new Movie();
            movie.MovieName = name;
            movie.ticketId = ticketId;
            movie.seatNumber = seatNumber;

            return movie;
        }
    }
}

