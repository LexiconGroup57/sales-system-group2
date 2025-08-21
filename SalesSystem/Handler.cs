using System;

namespace SalesSystem
{
    public static class Handler
    {
        private static SeatArrangement seatArrangement = new();
        private static Accounting accounting = new();

        public static void MakeOrder()
        {
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