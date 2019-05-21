using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    public class ProductPriceHandler : IProductPriceHandler, ITax, IDiscountOrUpcDiscount, IDiscount, IUpcDiscount, IResult
    {
        public Product Product { get; set; }
        public decimal Tax { get; set; } = 2.0m;
        public decimal TaxResult { get; set; } = 0.0m;
        public decimal Discount { get; set; } = 0.0m;
        public decimal DiscountResult { get; set; } = 0.0m;
        public decimal DiscountForUpc { get; set; } = 0.0m;
        public decimal DiscountForUpcResult { get; set; } = 0.0m;
        public decimal Total { get; set; } = 0.0m;
        public AddedExpensesResults AddedExpensesResults { get; set; } = new AddedExpensesResults();

        public decimal RunningTotal { get; set; }
        private ProductPriceHandler(Product product)
        {
            Product = product;
		}
		public static IProductPriceHandler ForPriceResult(Product product) => 
            (IProductPriceHandler)new ProductPriceHandler(product);

        public IDiscountOrUpcDiscount CalculateTax()
        {
            TaxResult = Product.Price * (Tax / 100);
            //TaxResult = (Product.Price - (DiscountResult + DiscountForUpcResult)) * Tax;
            return this;
        }
        public IDiscount CalculateDiscount()
        {
            DiscountResult = (Product.Price - DiscountForUpcResult) * (Discount / 100);
            if (DiscountForUpcResult == 0.0m)
            {
                return this;
            } else
            {
                var temp = this;
                return temp;
            }
            return this;
        }
        //public IThenDiscount CalculateDiscount()
        //{
        //    DiscountResult = (Product.Price - DiscountForUpcResult) * Discount;
        //    return this;
        //}

        public IResult CalculateUpcDiscount()
        {
			FindUpcDiscount();
            DiscountForUpcResult = (Product.Price - DiscountResult) * (DiscountForUpc / 100);
            return this;
        }
		private void FindUpcDiscount()
		{
			DiscountForUpc = ProductPriceFactory.UPCDiscounts.FindDiscountRate(Product.UPC);
		}

		public IProductPriceHandler GetResult()
        {
            AddedExpensesResults.CalculateExpenses();
            CalculateUpcDiscount();
            Total = Product.Price + TaxResult - DiscountResult - DiscountForUpcResult + AddedExpensesResults.TotalOfExpenses;
            return this;
        }

        //public void DisplayProduct()
        //{
        //    var result = CalculateTax().CalculateDiscount().GetResult();
        //    //var result = CalculateTax().CalculateDiscount().CalculateUpcDiscount().GetResult();
        //    // Product & Price
        //    Console.WriteLine($"Product {result.Product.Name}, was purchased for {result.Product.Price.DecimalPlaces(2).CurrencyStr()}");
        //    // Tax Report
        //    Console.WriteLine($"A {result.Tax.ToPercentage().PercentageStr()} tax, resulted in a tax of {result.TaxResult.DecimalPlaces(2).CurrencyStr()}");
        //    // Discount Report
        //    Console.WriteLine($"A {result.Discount.ToPercentage().PercentageStr()} discount, resulted in a discount of {result.DiscountResult.DecimalPlaces(2).CurrencyStr()}");
        //    // Discount UPC Report
        //    Console.WriteLine($"A {result.DiscountForUpc.ToPercentage().PercentageStr()} discount for UPC {result.Product.UPC}, resulted in a discount of {result.DiscountForUpcResult.DecimalPlaces(2).CurrencyStr()}");

        //    AddedExpenses.DisplayAllAddedExpenses();

        //    Console.WriteLine($"The total for all 'Added Expenses' is {AddedExpenses.TotalOfExpenses.DecimalPlaces(2).CurrencyStr()}");

        //    // Total
        //    Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {result.Total.DecimalPlaces(2).CurrencyStr()}");
        //    Console.WriteLine();
        //}
    }
}
