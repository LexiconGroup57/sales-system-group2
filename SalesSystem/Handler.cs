using System;
using SalesSystem.Models;

namespace SalesSystem
{
    public static class Handler
    {
        private static SeatArrangement seatArrangement = new();
        private static Accounting accounting = new();
        public static void MakeOrder()
        {
            Console.Clear();
            Console.WriteLine("Enter the size of the group");
            int groupSize = int.Parse(Console.ReadLine());

            ShoppingCart cart = new();
            Customer[] Customers = new Customer[groupSize];
            int[] ChosenSeats = new int[groupSize];

            for(int i = 0; i < groupSize; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter age of person " + (i + 1).ToString());
                Customers[i] = new(int.Parse(Console.ReadLine()));
                Console.WriteLine("Choose seat for person " + (i+1).ToString());
                ChosenSeats[i] = seatArrangement.checkAndFillSeat();
                Console.ReadLine();
            }


            // testing stuff, delete later-------------
            Console.Clear();
            Console.WriteLine("Order details:");
            string output = "";
            for (int i = 0; i < groupSize; i++)
            {
                output += ChosenSeats[i].ToString() + (i == groupSize - 1 ? "" : ", ");
            }
            Console.WriteLine("Seats: " + output);
            for (int i = 0;i < groupSize; i++)
            {
                Console.WriteLine("Person " + (i + 1).ToString() + " age: " + Customers[i].Age.ToString());
            }
            Console.ReadLine();
            //------------------------------------------
        }
        public static void ShowMonthlyReport()
        {
            Console.Clear();
            accounting.ShowMonthlyReport();
            Console.ReadLine();
        }
    }
}