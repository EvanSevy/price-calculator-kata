using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductPriceHandler
    {
        public Product Product { get; set; }
        public decimal Tax { get; set; } = 0.2m;
        public decimal Discount { get; set; } = 0.0m;
        public decimal DiscountForUPC { get; set; } = 0.0m;

        public decimal CalculateTax()
        {
            return Product.Price * Tax;
        }
        public decimal CalculateTotalWithTax()
        {
            return Product.Price + CalculateTax();
        }

        public decimal CalculateDiscount()
        {
            return Product.Price * Discount;
        }

        public decimal CalculateUPCDiscount()
        {
            return Product.Price * DiscountForUPC;
        }

        public decimal CalculateTotalWithTaxAndDiscount()
        {
            return CalculateTotalWithTax() - CalculateDiscount();
        }

        public decimal CalculateTotalWithTaxDiscountAndUPCDiscount()
        {
            return CalculateTotalWithTax() - CalculateDiscount() - CalculateUPCDiscount();
        }

        public void DisplayProduct()
        {
            // Product & Price
            Console.WriteLine($"Product {Product.Name}, was purchased for {Product.Price.DecimalPlaces(2).CurrencyStr()}");
            // Tax Report
            Console.WriteLine($"A {Tax.ToPercentage().PercentageStr()} tax, resulted in a tax of {CalculateTax().DecimalPlaces(2).CurrencyStr()}");
            // Discount Report
            Console.WriteLine($"A {Discount.ToPercentage().PercentageStr()} discount, resulted in a discount of {CalculateDiscount().DecimalPlaces(2).CurrencyStr()}");
            // Discount UPC Report
            Console.WriteLine($"A {DiscountForUPC.ToPercentage().PercentageStr()} discount for UPC {Product.UPC}, resulted in a discount of {CalculateUPCDiscount().DecimalPlaces(2).CurrencyStr()}");

            // Total
            Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {CalculateTotalWithTaxDiscountAndUPCDiscount().DecimalPlaces(2).CurrencyStr()}");
            Console.WriteLine();
        }
    }
}
