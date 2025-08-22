Console.writeLine("Price Calculation discount");

Console.writeLine("Enter the price of the product:");
decimal price = Convert.ToDecimal(Console.ReadLine());
Console.writeLine("Enter the discount percentage:");
decimal discountPercentage = Convert.ToDecimal(Console.ReadLine());
decimal discountAmount = (discountPercentage / 100) * price;
decimal finalPrice = price - discountAmount;
Console.writeLine($"The final price after a discount of {discountPercentage}% is: {finalPrice:C}");
Console.writeLine("Thank you for using the Price Calculation system.");






