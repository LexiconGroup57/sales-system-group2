using SalesSystem.Interfaces;

namespace SalesSystem.Models;

public class Snack(string name, string description, double basePrice, double vatPrice, int vat)
	: ISalesItem {
	public required string Name { get; set; } = name;
	public string Description { get; set; } = description;
	public double BasePrice { get; set; } = basePrice;
	public double VatPrice { get; set; } = vatPrice;
	public double Vat { get; set; } = vat;
}
