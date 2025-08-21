using SalesSystem.Interfaces;

namespace SalesSystem.Models;

public class Ticket(string name, string? description, double basePrice, double vat, Movie movie)
	: ISalesItem {
	public string Name { get; set; } = name;
	public string Description { get; set; } = description ?? string.Empty;
	public double BasePrice { get; set; } = basePrice;
	public double Vat { get; set; } = vat;
	public double VatPrice { get; set; } = Math.Round(basePrice * (1 + vat / 100));
	public Movie Movie { get; set; } = movie;
}
