using SalesSystem.Interfaces;

namespace SalesSystem.Models;

public class ShoppingCart {
	private List<ISalesItem> shoppingCart { get; set; } = [];
	private DateTime date { get; set; }  = DateTime.Now;

	public void AddItem(ISalesItem item) {
		this.shoppingCart.Add(item);
	}

	public List<ISalesItem> GetItems() {
		return this.shoppingCart;
	}

	public void RemoveItem(ISalesItem item) {
		this.shoppingCart.Remove(item);
	}
}
