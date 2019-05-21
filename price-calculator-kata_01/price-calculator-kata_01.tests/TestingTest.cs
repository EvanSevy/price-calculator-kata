using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.tests
{
    [TestFixture]
    class TestingTest
    {
        [Test]
        [TestCase(125.0, 5.0, ExpenseType.Monetary, 5.0)]
        [TestCase(125.0, 5.0, ExpenseType.Percentage, 6.25)]
        public void AddedExpenseShouldSetResult(decimal productPrice, decimal expenseValue, ExpenseType expenseType, decimal expectedResult)
        {
            // Arrange
            var fixture = new Fixture();

            var addedExpense = fixture.Create<AddedExpense>();
            addedExpense.ForProduct.Price = productPrice;
            addedExpense.Value = expenseValue;
            addedExpense.Type = expenseType;

            var sut = new AddedExpenseResult(addedExpense);

            // Act
            sut.SetResult();

            // Assert
            sut.Result.Should().Be(expectedResult);
        }

		//[Test]
		//public void ProductPriceFactoryReturnsValidResult()
		//{
		//	// Arrange
		//	var fixture = new Fixture();
		//	Product product = new Product("ProductName", 12345, 155.55m);
		//	AddedExpense expense = new AddedExpense();
		//	expense.
		//	ProductPriceFactory sut = ProductPriceFactory.ForProduct(product).WithTaxRate(7).WithDiscountRate(10).WithAddedExpense()

		//	// Act

		//	// Assert
		//}
    }
}
