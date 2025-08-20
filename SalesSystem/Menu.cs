using System;

namespace SalesSystem
{
    public class Menu
    {
        
        private bool Running = true;
        public void Run()
        {
            while (Running)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1: Make order");
                Console.WriteLine("2: Get Monthly Report");
                Console.WriteLine("q: Quit");
                switch (Console.ReadLine() ?? "")
                {
                    case "q":
                        Running = false;
                        break;
                    case "1":
                        Handler.MakeOrder();
                        break;
                    case "2":
                        Handler.ShowMonthlyReport();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}