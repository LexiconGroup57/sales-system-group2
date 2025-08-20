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
            Console.WriteLine("Enter the size of the group");
            int groupSize = int.Parse(Console.ReadLine());

            int[] ChosenSeats = new int[groupSize];
            for(int i = 0; i < groupSize; i++)
            {
                Console.Clear();
                Console.WriteLine("Choose seat for person " + (i+1).ToString());
                ChosenSeats[i] = seatArrangement.checkAndFillSeat();
                Console.ReadLine();
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