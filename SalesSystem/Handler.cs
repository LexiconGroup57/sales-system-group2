using System;
using SalesSystem.Models;
using SalesSystem.Utils;
using SalesSystem.Interfaces;

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
            Console.Write("Enter Customer Count: ");
            int groupSize = GetNumberFromString(Console.ReadLine());
            CustomerGroup group = new CustomerGroup(groupSize);
            group.AddShoppingCartItem("ticket", movie, 0, null);

            // Snack adding
            Console.Clear();
            Console.Write("Choose snack count (cars): ");
            int carsCount = GetNumberFromString(Console.ReadLine());
            Console.Write("Choose snack count (popcorn): ");
            int popcornCount = GetNumberFromString(Console.ReadLine());
            group.AddShoppingCartItem("snack", movie, carsCount, "cars");
            group.AddShoppingCartItem("snack", movie, popcornCount, "popcorn");

            // Seat selection
            int[] chosenSeats = new int[groupSize];
            for(int i = 0; i < groupSize; i++)
            {
                Console.Clear();
                Console.WriteLine("Choose " + groupSize.ToString() + " Seats. (" + (groupSize - i).ToString() + " left)");
                chosenSeats[i] = seatArrangement.CheckAndFillSeat();
            }
            Console.ReadLine();

            // Order confirmation
            Console.Clear();
            Console.WriteLine("Order Confirmation\n");
            Console.WriteLine("Moive:        " + movie.ToString());
            string seatoutput = "";
            for (int i = 0; i < chosenSeats.Length; i++)
            {
                seatoutput += chosenSeats[i].ToString();
                if (i != chosenSeats.Length - 1)
                    seatoutput += ", ";
            }
            Console.WriteLine("Seats:        " + seatoutput);
            Console.WriteLine("Customers:");
            List<Customer> customers = group.GetCustomers();
            for(int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("              " + (i+1).ToString() + ". Age: " + customers[i].Age.ToString());
            }
            Console.Write("\nConfirm? (Y/N): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                ConfirmOrder(group);
                return;
            }
            seatArrangement.UnreserveSeats(chosenSeats);
        }
        private static void ConfirmOrder(CustomerGroup group)
        {
            ShoppingCart cart = group.GetShoppingCart();
            DateTime date = cart.date;
            bool discount = (date.Month == 10);

            ISalesItem[] items = cart.salesItems.ToArray();
            for(int i = 0; i < items.Length; i++)
            {
                ISalesItem item = items[i];
                if (item is Snack snack)
                {
                    accounting.AddSnacksale(PriceCalculation.CalculatePrice(snack.BasePrice, false));
                }
                else if (item is Ticket ticket)
                {
                    accounting.AddTicketsale(PriceCalculation.CalculatePrice(ticket.BasePrice, discount));
                }
            }
        }

        public static void ShowMonthlyReport()
        {
            Console.Clear();
            accounting.ShowMonthlyReport();
            Console.ReadLine();
        }
    }
}