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

            AddedExpense ElephantStatue = new AddedExpense() { Name = "Elephat Statue", Value = 0.05m, Type = ExpenseType.Percentage };
            //#######################
            // Make it more explicit on how/where 'Result' is being calculated for the AddedExpense.
            //#######################

            Product buddha = new Product("Buddha Figurine", 12345, 42.25m);
            products.Add(ProductPriceFactory.ForProduct(buddha).WithAddedExpense(ElephantStatue).GetFactoryResult());

            Product book = new Product("Ken Wilber Book", 56789, 12.22m);
            products.Add(ProductPriceFactory.ForProduct(book).WithTaxRate(.22m).GetFactoryResult());

            Product chair = new Product("Aeron Chair", 34567, 1000m);
            products.Add(ProductPriceFactory.ForProduct(chair).WithTaxRate(.2m).WithDiscountRate(.15m).GetFactoryResult());

            Product shoes = new Product("Salomon Trail Runners", 123, 145m);
            products.Add(ProductPriceFactory.ForProduct(shoes).WithTaxRate(.07m).WithDiscountRate(.15m).GetFactoryResult());

            products.DisplayAllProducts();
            
            Console.ReadLine();
        }
    }
}
