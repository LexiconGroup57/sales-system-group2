using System.Security.Cryptography;
using SalesSystem.Interfaces;
using SalesSystem.Models;
using SalesSystem.Utils;

namespace SalesSystem;

public class CustomerGroup {
	private readonly List<Customer> customers = [];
	private readonly ShoppingCart shoppingCart = new ShoppingCart();

	private readonly Dictionary<string, Snack> snackList = new Dictionary<string, Snack> {
		["cars"] = new Snack("Ahlgrens bilar", "125 g", 19.64, 0.12),
		["popcorn"] = new Snack("Popcorn and Coca-Cola", "", 38.39, 0.12)
	};

	public CustomerGroup(int groupSize) {
		this.AddCustomers(groupSize);
	}

	public List<Customer> GetCustomers() {
		return [..customers];
	}

	public ShoppingCart GetShoppingCart() {
		return new ShoppingCart {
			salesItems = shoppingCart.salesItems,
			date = shoppingCart.date
		};
	}

	public void AddShoppingCartItem(string salesItem, Movie movie, int? amount, string? item) {
		if (salesItem.Equals("ticket", StringComparison.CurrentCultureIgnoreCase)) {
			this.AddTicket(movie);
		} else if (salesItem.Equals("snack", StringComparison.CurrentCultureIgnoreCase)) {
			this.AddSnack(amount ?? 1, item ?? string.Empty);
		}
	}

	private void AddCustomers(int groupSize) {
		for (int i = 0; i < groupSize; i++) {
			int userInput = Printer.GetGroupAges();
			if (userInput > 0) {
				customers.Add(new Customer(userInput));
			} else {
				i--;
			}
		}
	}

	private void AddTicket(Movie movie) {
		foreach (Customer customer in customers) {
			shoppingCart.salesItems.Add(new Ticket(
				movie.Title,
				string.Empty,
				CalculateTicketPrice(customer.Age, shoppingCart.date),
				0.25,
				movie)
			);
		}
	}

	private void AddSnack(int amount, string item) {
		for (int i = 0; i < amount; i++) {
			shoppingCart.salesItems.Add(snackList[item]);
		}
	}

	private static double CalculateTicketPrice(int customerAge, DateTime date) {
		return customerAge switch {
			< 6 => 0,
			<= 11 => 65,
			>= 67 => 90,
			_ => date.Hour == 13 ? 105 : 130
		};
	}
}
