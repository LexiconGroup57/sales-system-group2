using System.Security.Cryptography;
using SalesSystem.Interfaces;
using SalesSystem.Models;

namespace SalesSystem;

public class CustomerGroup {
	public List<Customer> customers { get; } = [];
	public ShoppingCart shoppingCart { get; } = new ShoppingCart();

	// TODO only for testing purposes. Will be rewritten
	public CustomerGroup() {
		for (int i = 0; i < 3; i++) {
			this.AddCustomer(new Customer(RandomNumberGenerator.GetInt32(0, 101)));
		}
		this.AddShoppingCartItem(new Ticket("Ticket", "", 105, 105, 25));
		this.AddShoppingCartItem(new Ticket("Ticket", "", 105, 105, 25));
		this.AddShoppingCartItem(new Snack("Ahlgrens bilar", "125 g", 19.64,22, 12));
		this.AddShoppingCartItem(new Snack("Ahlgrens bilar", "125 g", 19.64,22, 12));
	}

	// TODO only for testing purposes. Will be removed
	public void PrintGroup() {
		customers.ForEach(customer => {
			Console.WriteLine(customer.Age);
		});
		shoppingCart.salesItems.ForEach(salesItem => {
			Console.WriteLine(salesItem.GetType().Name);
		});
	}

	public void AddCustomer(Customer newCustomer) {
		customers.Add(newCustomer);
	}

	public void AddShoppingCartItem(ISalesItem salesItem) {
		shoppingCart.salesItems.Add(salesItem);
	}
}
