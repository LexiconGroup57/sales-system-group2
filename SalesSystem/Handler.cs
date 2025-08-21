using System;
using SalesSystem.Models;

namespace SalesSystem
{
    public static class Handler
    {
        private static SeatArrangement seatArrangement = new();
        private static Accounting accounting = new();

        /// <summary>
        /// Turns a string into a number and clamps it to be within the specified range. If it fails it returns inclusiveLower instead.
        /// </summary>
        private static int GetNumberFromString(string input, int inclusiveLower, int inclusiveUpper)
        {
            if(int.TryParse(input, out int value))
                return Math.Clamp(value, inclusiveLower, inclusiveUpper);
            return inclusiveLower;
        }
        /// <summary>
        /// Turns a string into a number. If it fails it returns zero instead.
        /// </summary>
        private static int GetNumberFromString(string input)
        {
            if (int.TryParse(input, out int value))
                return value;
            return 0;
        }

        public static void MakeOrder()
        {
            // movie selection
            Console.Clear();
            List<Movie> allMovies = Movie.GetAllMovies();
            Console.WriteLine("Available movies:\n");
            for (int i = 0; i < allMovies.Count; i++)
            {
                Console.WriteLine((i+1).ToString() + ": " + allMovies[i].ToString());
            }
            Console.Write("\nChoose a movie: ");
            Movie movie = allMovies[GetNumberFromString(Console.ReadLine(), 1, allMovies.Count) - 1];

            // Customer group creation
            Console.Clear();
            CustomerGroup group = new CustomerGroup();
            Console.Write("Enter Customer Count: ");
            int count = GetNumberFromString(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter Person " + (i+1).ToString() + "'s Age: ");
                group.AddCustomer(new Customer(GetNumberFromString(Console.ReadLine())));
            }

            // Snack adding
            Console.Clear();

            // Seat selection
            Console.Clear();

            // Order confirmation
            Console.Clear();

            Console.ReadLine();
        }
        public static void ShowMonthlyReport()
        {
            Console.Clear();
            accounting.ShowMonthlyReport();
            Console.ReadLine();
        }
    }
}