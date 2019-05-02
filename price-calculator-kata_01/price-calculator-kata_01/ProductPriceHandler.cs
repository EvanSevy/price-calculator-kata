using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductPriceHandler : IProductPriceHandler, ITaxOrDiscountOrUpcDiscount, ITaxOrDiscount, ITaxOrUpcDiscount, IDiscountOrUpcDiscount
    {
        public Product Product { get; set; }
        public decimal Tax { get; set; } = 0.2m;
        public decimal TaxResult { get; set; } = 0.0m;
        public decimal Discount { get; set; } = 0.0m;
        public decimal DiscountResult { get; set; } = 0.0m;
        public decimal DiscountForUpc { get; set; } = 0.0m;
        public decimal DiscountForUpcResult { get; set; } = 0.0m;
        public decimal Total { get; set; } = 0.0m;
        public AddedExpenses AddedExpenses { get; set; } = new AddedExpenses();

        public decimal RunningTotal { get; set; }
        private ProductPriceHandler(Product product)
        {
            Product = product;
        }

        public static IProductPriceHandler ForPriceResult(Product product) => (IProductPriceHandler)new ProductPriceHandler(product);

        public IDiscountOrUpcDiscount CalculateTax()
        {
            TaxResult = (Product.Price - (DiscountResult + DiscountForUpcResult)) * Tax;
            return this;
        }
        public ITaxOrUpcDiscount CalculateDiscount()
        {
            DiscountResult = Product.Price * Discount;
            return this;
        }

        public ITaxOrDiscount CalculateUpcDiscount()
        {
            DiscountForUpcResult = Product.Price * DiscountForUpc;
            return this;
        }

        public IProductPriceHandler GetResult()
        {
            AddedExpenses.CalculateExpenses();
            CalculateUpcDiscount();
            Total = Product.Price + TaxResult - DiscountResult - DiscountForUpcResult + AddedExpenses.TotalOfExpenses;
            return this;
        }

        public void DisplayProduct()
        {
            var result = CalculateTax().CalculateDiscount().GetResult();
            //var result = CalculateTax().CalculateDiscount().CalculateUpcDiscount().GetResult();
            // Product & Price
            Console.WriteLine($"Product {result.Product.Name}, was purchased for {result.Product.Price.DecimalPlaces(2).CurrencyStr()}");
            // Tax Report
            Console.WriteLine($"A {result.Tax.ToPercentage().PercentageStr()} tax, resulted in a tax of {result.TaxResult.DecimalPlaces(2).CurrencyStr()}");
            // Discount Report
            Console.WriteLine($"A {result.Discount.ToPercentage().PercentageStr()} discount, resulted in a discount of {result.DiscountResult.DecimalPlaces(2).CurrencyStr()}");
            // Discount UPC Report
            Console.WriteLine($"A {result.DiscountForUpc.ToPercentage().PercentageStr()} discount for UPC {result.Product.UPC}, resulted in a discount of {result.DiscountForUpcResult.DecimalPlaces(2).CurrencyStr()}");

            AddedExpenses.DisplayAllAddedExpenses();

            Console.WriteLine($"The total for all 'Added Expenses' is {AddedExpenses.TotalOfExpenses.DecimalPlaces(2).CurrencyStr()}");

            // Total
            Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {result.Total.DecimalPlaces(2).CurrencyStr()}");
            Console.WriteLine();
        }
    }
}
