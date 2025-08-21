namespace SalesSystem.Interfaces;

public interface ISalesItem {
	string Name { get; set; }
	string Description { get; set; }
	double BasePrice { get; set; }
	double VatPrice { get; set; }
	double Vat { get; set; }
}
