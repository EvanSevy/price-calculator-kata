using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.tests
{
    [TestFixture]
    class AddedExpenseTests
    {
        [Test]
        [TestCase(125.0, 5.0, ExpenseType.Monetary, 5.0)]
        [TestCase(125.0, 5.0, ExpenseType.Percentage, 6.25)]
        public void AddedExpenseShouldSetResult(decimal productPrice, decimal expenseValue, ExpenseType expenseType, decimal expectedResult)
        {
            // Arrange
            var fixture = new Fixture();

            var addedExpense = fixture.Create<AddedExpense>();
            addedExpense.Value = expenseValue;
            addedExpense.Type = expenseType;
			Product product = fixture.Create<Product>();
			product.Price = productPrice;

            var sut = new AddedExpenseResult(addedExpense, product);

            // Act
            //sut.SetResult();

            // Assert
            sut.Result.Should().Be(expectedResult);
        }
	}
}
