using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    internal class Accounting
    {
        // Declaring fixed VAT rates to tickets and snacks
        private double TicketVat = 0.25;
        private double SnackVat = 0.12;
        // Variables to store total tickets and snacks sales
        public double TotalTicketsSales { get; private set; }
        public double TotalSnacksSale { get; private set; }
        // Constructor to set the starting values
        public Accounting()
        {
            TotalTicketsSales = 0;
            TotalSnacksSale = 0;
        }
        // Method to add Ticket sale
        public void AddTicketsale(double amount)
        {
            TotalTicketsSales += amount;
        }
        // Method to add snack sales
        public void AddSnacksale(double amount)
        {
            TotalSnacksSale += amount;
        }
        // Method to calculate VAT for tickets
        public double GetTicketVat()
        {
            return TotalTicketsSales * TicketVat;

        }
        // Method to calculate VAT for snacks
        public double GetSnackVat()
        {
            return TotalSnacksSale * SnackVat;
        }
        // Method to calculate total tickets with vat
        public double GetTotalTicketWithVat()
        {
            return TotalTicketsSales + GetTicketVat();
        }
        public double GetTotalSnackWithVat()
        {
            return TotalSnacksSale + GetSnackVat();
        }
        // Method to get the total sales
        public double GetTotal()
        {
            return GetTotalTicketWithVat() + GetTotalSnackWithVat();
        }
        // Show monthly report
        public void ShowMonthlyReport()
        {
            Console.WriteLine("-----------Monthly Sales Report--------");
            Console.WriteLine("Total Tickets Sale: " +  TotalTicketsSales + "SEK");
            Console.WriteLine("Total Snacks Sale: " +  TotalSnacksSale + "SEK");
            Console.WriteLine("Tickets with VAT rate: " +GetTotalTicketWithVat() + "SEK");
            Console.WriteLine("Snacks with VAT rate: " + GetTotalSnackWithVat() + "SEK");
            Console.WriteLine("Total including VAT: " + GetTotal() + "SEK");
        }





    }
}
