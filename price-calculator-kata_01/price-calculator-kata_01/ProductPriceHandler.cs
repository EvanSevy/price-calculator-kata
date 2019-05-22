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
		public AddedExpenses AddedExpenses { get; set; } = new AddedExpenses();
		public AddedExpensesResults AddedExpensesResults { get; set; } = new AddedExpensesResults();

		private ProductPriceHandler(Product product)
		{
			Product = product;
		}
		public static IProductPriceHandler ForPriceResult(Product product) => new ProductPriceHandler(product);

		public IDiscountOrUpcDiscount CalculateTax()
		{
			TaxResult = (Tax / 100) * Product.Price;
			//TaxResult = (Product.Price - (DiscountResult + DiscountForUpcResult)) * Tax;
			return this;
		}
		public IDiscount CalculateDiscount()
		{
			DiscountResult = (Product.Price - DiscountForUpcResult) * (Discount / 100);
			return this;
		}
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
			PerformAddedExpenses();
			CalculateUpcDiscount();
			Total = Product.Price + TaxResult - DiscountResult - DiscountForUpcResult + AddedExpensesResults.TotalOfExpenses;
			return this;
		}
		public void PerformAddedExpenses()
		{
			AddedExpensesResults = new AddedExpensesResults(AddedExpenses, Product);
			AddedExpensesResults.CalculateExpenses();
		}
		public static void Display(ITax Product)
		{
			var result = Product.CalculateTax().CalculateDiscount().GetResult();

			// Product & Price
			Console.WriteLine($"Product {result.Product.Name}, was purchased for {result.Product.Price.CurrencyStr()}");
			// Tax Report
			Console.WriteLine($"A {result.Tax.PercentageStr()} tax, resulted in a tax of {result.TaxResult.CurrencyStr()}");
			// Discount Report
			Console.WriteLine($"A {result.Discount.PercentageStr()} discount, resulted in a discount of {result.DiscountResult.CurrencyStr()}");
			// Discount UPC Report
			Console.WriteLine($"A {result.DiscountForUpc.PercentageStr()} discount for UPC {result.Product.UPC}, resulted in a discount of {result.DiscountForUpcResult.CurrencyStr()}");

			// Added Expenses
			result.AddedExpensesResults.DisplayAllAddedExpenses();
			Console.WriteLine($"The total for all 'Added Expenses' is {result.AddedExpensesResults.TotalOfExpenses.CurrencyStr()}");

			// Total
			Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {result.Total.CurrencyStr()}");
			Console.WriteLine();
		}
	}
}
