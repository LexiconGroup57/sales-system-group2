using SalesSystem.Interfaces;

namespace SalesSystem.Models;

public class Snack(string name, string description, double basePrice, double vat)
	: ISalesItem {
	public string Name { get; set; } = name;
	public string Description { get; set; } = description;
	public double BasePrice { get; set; } = basePrice;
	public double Vat { get; set; } = vat;
	public double VatPrice { get; set; } = Math.Round(basePrice * (1 + vat));
}
