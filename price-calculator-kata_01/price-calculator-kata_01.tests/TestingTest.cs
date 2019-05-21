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
    }
}
