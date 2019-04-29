using System;

namespace price_calculator_kata_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Product buddha = new Product("Buddha Figurine", 12345, 42.25m);
            DisplayProduct(buddha);

            Product book = new Product("Ken Wilber Book", 56789, 12.22m, .22m);
            DisplayProduct(book);

            Product chair = new Product("Aeron Chair", 34567, 1000m, .2m, .15m);
            DisplayProduct(chair);

            Console.ReadLine();
        }

        private static void DisplayProduct(Product product)
        {
            // Product & Price
            Console.WriteLine($"Product {product.Name}, was purchased for {product.Price.DecimalPlaces(2).CurrencyStr()}");
            // Tax Report
            Console.WriteLine($"A {product.Tax.ToPercentage().PercentageStr()} tax, resulted in a tax of {product.CalculateTax().DecimalPlaces(2).CurrencyStr()}");
            // Discount Report
            Console.WriteLine($"A {product.Discount.ToPercentage().PercentageStr()} discount, resulted in a discount of {product.CalculateDiscount().DecimalPlaces(2).CurrencyStr()}");

            // Total
            Console.WriteLine($"For a total with tax and discount of: {product.CalculateTotalWithTaxAndDiscount().DecimalPlaces(2).CurrencyStr()}");
        }
    }
}
