using System.Security.Cryptography;
using SalesSystem.Models;

namespace SalesSystem;

public class CustomerGroup {
	List<Customer> customers = new List<Customer>();
	ShoppingCart shoppingCart = new ShoppingCart();

	public CustomerGroup() {
		for (int i = 0; i < 3; i++) {
			customers.Add(new Customer(RandomNumberGenerator.GetInt32(0, 101)));
		}
		shoppingCart.AddItem(new Ticket("Ticket", "", 105, 105, 25));
		shoppingCart.AddItem(new Ticket("Ticket", "", 105, 105, 25));
		shoppingCart.AddItem(new Snack("Ahlgrens bilar", "125 g", 19.64,22, 12));
		shoppingCart.AddItem(new Snack("Ahlgrens bilar", "125 g", 19.64,22, 12));
	}

	public void PrintGroup() {
		customers.ForEach(customer => {
			Console.WriteLine(customer.Age);
		});
		shoppingCart.GetItems().ForEach(salesItem => {
			Console.WriteLine(salesItem.GetType().Name);
		});
	}
}
