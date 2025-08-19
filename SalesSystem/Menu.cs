using System;

namespace SalesSystem
{
    public class Menu
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter 'q' to quit");
                if (Console.ReadLine() == "q")
                    break;
            }
        }
    }
}