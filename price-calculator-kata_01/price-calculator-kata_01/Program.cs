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

            Console.ReadLine();
        }

        private static void DisplayProduct(Product product)
        {
            Console.WriteLine($"Product {product.Name}, was purchased for {product.Price.ToTwoDecimals().FormatAsCurrency()}");
            Console.WriteLine($"A {product.Tax.FormatAsPercentage()} tax, resulted in a tax of {product.CalculateTax().ToTwoDecimals().FormatAsCurrency()}");
            Console.WriteLine($"For a total with tax of: {product.CalculateTotalWithTax().ToTwoDecimals().FormatAsCurrency()}");
        }
    }
}
