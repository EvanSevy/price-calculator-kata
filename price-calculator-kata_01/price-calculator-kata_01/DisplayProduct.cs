using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class DisplayProduct
    {
        //public IProductPriceHandler Product { get; set; }
        //public DisplayProduct(IProductPriceHandler product)
        //{
        //    Product = product;
        //}

        public static void Display(ITax Product)
        {
            var result = Product.CalculateTax().CalculateDiscount().GetResult();
            //var result = CalculateTax().CalculateDiscount().CalculateUpcDiscount().GetResult();
            // Product & Price
            Console.WriteLine($"Product {result.Product.Name}, was purchased for {result.Product.Price.CurrencyStr()}");
            // Tax Report
            Console.WriteLine($"A {result.Tax.PercentageStr()} tax, resulted in a tax of {result.TaxResult.CurrencyStr()}");
            // Discount Report
            Console.WriteLine($"A {result.Discount.PercentageStr()} discount, resulted in a discount of {result.DiscountResult.CurrencyStr()}");
            // Discount UPC Report
            Console.WriteLine($"A {result.DiscountForUpc.PercentageStr()} discount for UPC {result.Product.UPC}, resulted in a discount of {result.DiscountForUpcResult.CurrencyStr()}");

            result.AddedExpensesResults.DisplayAllAddedExpenses();

            Console.WriteLine($"The total for all 'Added Expenses' is {result.AddedExpensesResults.TotalOfExpenses.DecimalPlaces(2).CurrencyStr()}");

            // Total
            Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {result.Total.DecimalPlaces(2).CurrencyStr()}");
            Console.WriteLine();
        }

    }
}
