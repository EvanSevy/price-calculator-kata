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

            AddedExpense Packaging = new AddedExpense() { Name = "Packaging", Value = 0.05m, Type = ExpenseType.Percentage };
            AddedExpense BubbleWrap = new AddedExpense() { Name = "Bubble Wrap", Value = 0.02m, Type = ExpenseType.Percentage };

            Product buddha = new Product("Buddha Figurine", 12345, 42.25m);
            products.Add(ProductPriceFactory.ForProduct(buddha).WithAddedExpense(Packaging).WithAddedExpense(BubbleWrap).GetFactoryResult());

            Product book = new Product("Ken Wilber Book", 56789, 12.22m);
            products.Add(ProductPriceFactory.ForProduct(book).WithTaxRate(.22m).GetFactoryResult());

            Product chair = new Product("Aeron Chair", 34567, 1000m);
            products.Add(ProductPriceFactory.ForProduct(chair).WithTaxRate(.2m).WithDiscountRate(.15m).GetFactoryResult());

            Product shoes = new Product("Salomon Trail Runners", 123, 145m);
            products.Add(ProductPriceFactory.ForProduct(shoes).WithTaxRate(.07m).WithDiscountRate(.15m).WithAddedExpense(BubbleWrap).GetFactoryResult());

            products.DisplayAllProducts();
            
            Console.ReadLine();
        }
    }
}
