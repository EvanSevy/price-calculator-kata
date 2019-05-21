using AutoFixture;
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
        public void AddedExpenseMonetaryShouldBeValueResult()
        {
            // Arrange
            var fixture = new Fixture();

            var product = fixture.Create<Product>();
            product.Price = 125.0m;

            var addedExpense = new AddedExpense {
                Name = "SomeExpense",
                ForProduct = product,
                Type = ExpenseType.Monetary,
                Value = 5.0m
            };
            var sut = new AddedExpenseResult(addedExpense);

            // Act
            sut.SetResult();

            // Assert
            Assert.That(sut.Result, Is.EqualTo(5.0m));
        }

        [Test]
        public void AddedExpensePercentageShouldBePercentageResult()
        {
            // Arrange
            var fixture = new Fixture();

            var product = fixture.Create<Product>();
            product.Price = 125.0m;

            var addedExpense = new AddedExpense
            {
                Name = "SomeExpense",
                ForProduct = product,
                Type = ExpenseType.Percentage,
                Value = 5.0m
            };
            var sut = new AddedExpenseResult(addedExpense);

            // Act
            sut.SetResult();

            // Assert
            Assert.That(sut.Result, Is.EqualTo(6.25m));
        }
    }
}
