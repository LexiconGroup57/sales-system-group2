using SalesSystem.Interfaces;

namespace SalesSystem.Models;

public class ShoppingCart {
	public List<ISalesItem> salesItems { get; private set; } = [];
	public DateTime date { get; private set; } = DateTime.Now;
}
