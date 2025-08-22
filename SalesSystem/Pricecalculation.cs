namespace 
SalesSystem;
using System;

public class PriceCalculation
    
{
    public static double CalculatePrice(double price, bool discount)

    {
    
        double discountPercentage = 0;
        if (discount)
            discountPercentage = 0.5; 
     



        double discountAmount = discountPercentage * price;
        return price - discountAmount;
    }
}







