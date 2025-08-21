using SalesSystem.Interfaces;

namespace SalesSystem.Models;

public class ShoppingCart {
	public List<ISalesItem> salesItems { get; init; } = [];
	public DateTime date { get; init; } = DateTime.Now;
}
