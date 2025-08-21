using SalesSystem.Models;

namespace SalesSystem.Utils;

public static class Printer {

	public static int GetGroupAges() {
		Console.Write("Enter the age of the customer: ");
		bool tryParse = int.TryParse(Console.ReadLine(), out int result);
		return tryParse ? result : 0;
	}
}
