using FluentAssertions;
using NUnit.Framework;
using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.tests
{
	[TestFixture]
	class ProductPriceTests
	{
		Product BuddhaProduct;
		Product ShoesProduct;
		AddedExpense PackagingExpense;
		AddedExpense BubbleWrapExpense;
		AddedExpense Stamps;
		UPCDiscount discountOne;
		UPCDiscount discountTwo;
		[SetUp]
		public void Init()
		{
			BuddhaProduct = new Product("Buddha Figurine", 12345, 42.25m);
			ShoesProduct = new Product("Salomon Trail Runners", 123, 145m);
			discountOne = new UPCDiscount() { Discount = 19m, UPC = 12345 };
			discountTwo = new UPCDiscount() { Discount = 29m, UPC = 56789 };
			PackagingExpense = new AddedExpense() { Name = "Packaging", Type = ExpenseType.Percentage, Value = 5 };
			BubbleWrapExpense = new AddedExpense() { Name = "Bubble Wrap", Type = ExpenseType.Percentage, Value = 2m };
			Stamps = new AddedExpense() { Name = "Postage Stamps", Value = 2.5m, Type = ExpenseType.Monetary };

			ProductPriceFactory.UPCDiscounts.Add(discountOne);
			ProductPriceFactory.UPCDiscounts.Add(discountTwo);
		}

		[Test]
		public void ProductPriceFactoryReturnsValidResult()
		{
			// Act
			IProductPriceHandler sut = ProductPriceFactory.ForProduct(BuddhaProduct).WithAddedExpense(PackagingExpense).WithAddedExpense(BubbleWrapExpense).WithDiscountRate(5).GetFactoryResult();

			// Assert
			sut.Product.Should().Be(BuddhaProduct);
			sut.Tax.Should().Be(2);
			sut.Discount.Should().Be(5);
			sut.AddedExpenses.Should().Contain(PackagingExpense);
			sut.AddedExpenses.Should().Contain(BubbleWrapExpense);

			sut.AddedExpensesResults.Should().BeEmpty();
			sut.DiscountForUpc.Should().Be(0m);
			sut.TaxResult.Should().Be(0m);
			sut.DiscountResult.Should().Be(0m);
			sut.Total.Should().Be(0m);
		}
		[Test]
		public void ProductPriceHandlerReturnsValidResultWithUpcDiscountWithoutDiscountAndTaxRates()
		{
			IProductPriceHandler sut = ProductPriceFactory.ForProduct(BuddhaProduct).WithAddedExpense(PackagingExpense).WithAddedExpense(BubbleWrapExpense).GetFactoryResult();
			sut = sut.CalculateTax().CalculateDiscount().GetResult();

			sut.Total.Should().BeApproximately(38.02m, 0.01m);
			sut.TaxResult.Should().BeApproximately(0.85m, 0.01m);
			sut.DiscountForUpcResult.Should().BeApproximately(8.03m, 0.01m);
			sut.AddedExpensesResults.TotalOfExpenses.Should().BeApproximately(2.96m, 0.01m);
		}
		[Test]
		public void ProductPriceHandlerReturnsValidResultWithoutUpcDiscount()
		{
			IProductPriceHandler sut = ProductPriceFactory.ForProduct(ShoesProduct).WithTaxRate(7m).WithDiscountRate(15m).WithAddedExpense(BubbleWrapExpense).WithAddedExpense(Stamps).GetFactoryResult();
			sut = sut.CalculateTax().CalculateDiscount().GetResult();

			sut.Total.Should().BeApproximately(138.80m, 0.01m);
			sut.TaxResult.Should().BeApproximately(10.15m, 0.01m);
			sut.DiscountResult.Should().BeApproximately(21.75m, 0.01m);
			sut.DiscountForUpcResult.Should().Be(0m);
			sut.AddedExpensesResults.TotalOfExpenses.Should().BeApproximately(5.40m, 0.01m);
		}
	}
}
