using System;

namespace price_calculator_kata_01
{
    class Program
    {
        static void Main(string[] args)
        {


            Product buddha = new Product("Buddha Figurine", 12345, 42.25m);
            //ProductPriceHandler buddhaPrice = ProductPriceFactory.ForProduct(buddha).GetFactoryResult();
            //buddhaPrice.DisplayProduct();

            //UPCDiscount discount = new UPCDiscount() { Discount = 0.18m, UPC = 123 };
            ProductsForPricing products = ProductsForPricing.WithDiscountUPC(new UPCDiscount() { Discount = 0.18m, UPC = 12345 });
            products.Add(ProductPriceFactory.ForProduct(buddha).WithUPCDiscountRate(products.UPCDiscounts).GetFactoryResult());

            Product book = new Product("Ken Wilber Book", 56789, 12.22m);
            products.Add(ProductPriceFactory.ForProduct(book).WithTaxRate(.22m).GetFactoryResult());

            Product chair = new Product("Aeron Chair", 34567, 1000m);
            products.Add(ProductPriceFactory.ForProduct(chair).WithTaxRate(.2m).WithDiscountRate(.15m).GetFactoryResult());

            Product shoes = new Product("Salomon Trail Runners", 123, 145m);
            products.Add(ProductPriceFactory.ForProduct(shoes).WithTaxRate(.07m).WithDiscountRate(.15m).WithUPCDiscountRate(products.UPCDiscounts).GetFactoryResult());

            products.DisplayAllProducts();



            //Product book = new Product("Ken Wilber Book", 56789, 12.22m);
            //ProductPriceHandler bookPrice = ProductPriceFactory.ForProduct(book).WithTaxRate(.22m).GetFactoryResult();
            //bookPrice.DisplayProduct();

            //Product chair = new Product("Aeron Chair", 34567, 1000m);
            //ProductPriceHandler chairPrice = ProductPriceFactory.ForProduct(chair).WithTaxRate(.2m).WithDiscountRate(.15m).GetFactoryResult();
            //chairPrice.DisplayProduct();

            //Product shoes = new Product("Salomon Trail Runners", 123, 145m);
            //ProductPriceHandler shoesPrice = ProductPriceFactory.ForProduct(shoes).WithTaxRate(.07m).WithDiscountRate(.15m).WithUPCDiscountRate(.2m, 123).GetFactoryResult();
            //shoesPrice.DisplayProduct();





            Console.ReadLine();
        }
    }
}
