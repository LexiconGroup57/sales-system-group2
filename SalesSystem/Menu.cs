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
                Console.WriteLine("q: Quit");
                switch (Console.ReadLine() ?? "")
                {
                    case "q":
                        Running = false;
                        break;
                    case "1":
                        Handler.MakeOrder();
                        break;
                }
                Console.Clear();
            }
        }
    }
}