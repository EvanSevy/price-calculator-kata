using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductPrice : IPriceResult, ITaxOrDiscount, ITax, IDiscount
    {
        public Product Product { get; set; }
        public decimal Tax { get; set; } = 0.2m;
        public decimal Discount { get; set; } = 0.0m;
        public decimal DiscountForUPC { get; set; } = 0.0m;


        public decimal RunningTotal { get; set; }
        private ProductPrice()
        {
            RunningTotal = Product.Price;
        }

        public ITaxOrDiscount ForPriceResult() => this;


        public IDiscount PerformTax()
        {
            RunningTotal = RunningTotal * Tax;
            return this;
            //return Product.Price * Tax;
        }
        public decimal CalculateTax()
        {
            return Product.Price * Tax;
        }
        //public decimal CalculateTotalWithTax()
        //{
        //    return Product.Price + CalculateTax();
        //}

        public ITax PerformDiscount()
        {
            RunningTotal = RunningTotal - (RunningTotal * Discount);
            RunningTotal = RunningTotal - (RunningTotal * DiscountForUPC);
            return this;
            //return Product.Price * Discount;
        }
        public decimal CalculateDiscount()
        {
            return Product.Price * Discount;
        }

        public decimal CalculateUPCDiscount()
        {
            return Product.Price * DiscountForUPC;
        }

        //public decimal CalculateTotalWithTaxAndDiscount()
        //{
        //    return CalculateTotalWithTax() - CalculateDiscount();
        //}

        //public decimal CalculateTotalWithTaxDiscountAndUPCDiscount()
        //{
        //    return CalculateTotalWithTax() - CalculateDiscount() - CalculateUPCDiscount();
        //}

        public decimal GetResult()
        {
            return RunningTotal;
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
            //Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {.DecimalPlaces(2).CurrencyStr()}");
            //Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {CalculateTotalWithTaxDiscountAndUPCDiscount().DecimalPlaces(2).CurrencyStr()}");
            Console.WriteLine();
        }
    }
}
