using price_calculator_kata_01.interfaces;
using System;

namespace price_calculator_kata_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsForPricing products = new ProductsForPricing();

            ProductPriceFactory.UPCDiscounts.Add(new UPCDiscount() { Discount = 0.19m, UPC = 12345 });
            ProductPriceFactory.UPCDiscounts.Add(new UPCDiscount() { Discount = 0.29m, UPC = 56789 });

            Product buddha = new Product("Buddha Figurine", 12345, 42.25m);
            products.Add(ProductPriceFactory.ForProduct(buddha).GetFactoryResult());

            Product book = new Product("Ken Wilber Book", 56789, 12.22m);
            products.Add(ProductPriceFactory.ForProduct(book).WithTaxRate(.22m).GetFactoryResult());

            Product chair = new Product("Aeron Chair", 34567, 1000m);
            products.Add(ProductPriceFactory.ForProduct(chair).WithTaxRate(.2m).WithDiscountRate(.15m).GetFactoryResult());

            Product shoes = new Product("Salomon Trail Runners", 123, 145m);
            products.Add(ProductPriceFactory.ForProduct(shoes).WithTaxRate(.07m).WithDiscountRate(.15m).GetFactoryResult());

            DisplayProducts(products);

            //products.Products[0].PerformTax().PerformDiscount().GetResult();

            //products.DisplayAllProducts();
            
            Console.ReadLine();
        }

        public static void DisplayProducts(ProductsForPricing products)
        {
            foreach (IProductPriceHandler product in products)
            {
                //var pricingProduct = product.ForPriceResult();
                
                // Product & Price
                Console.WriteLine($"Product {product.Product.Name}, was purchased for {product.Product.Price.DecimalPlaces(2).CurrencyStr()}");
                // Tax Report
                Console.WriteLine($"A {product.Tax.ToPercentage().PercentageStr()} tax, resulted in a tax of {product.CalculateTax().DecimalPlaces(2).CurrencyStr()}");
                // Discount Report
                Console.WriteLine($"A {product.Discount.ToPercentage().PercentageStr()} discount, resulted in a discount of {product.CalculateDiscount().DecimalPlaces(2).CurrencyStr()}");
                // Discount UPC Report
                Console.WriteLine($"A {product.DiscountForUPC.ToPercentage().PercentageStr()} discount for UPC {product.Product.UPC}, resulted in a discount of {product.CalculateUPCDiscount().DecimalPlaces(2).CurrencyStr()}");

                // Total
                Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {product.PerformTax().PerformDiscount().GetResult().DecimalPlaces(2).CurrencyStr()}");
                //Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {CalculateTotalWithTaxDiscountAndUPCDiscount().DecimalPlaces(2).CurrencyStr()}");
                Console.WriteLine();
            }
        }
    }
}
