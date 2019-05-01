using price_calculator_kata_01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductPriceHandler : IProductPriceHandler, ITaxOrDiscountOrUpcDiscount, ITaxOrDiscount, ITaxOrUpcDiscount, IDiscountOrUpcDiscount
    {
        public Product Product { get; set; }
        public decimal Tax { get; set; } = 0.2m;
        public decimal TaxResult { get; set; } = 0.0m;
        public decimal Discount { get; set; } = 0.0m;
        public decimal DiscountResult { get; set; } = 0.0m;
        public decimal DiscountForUpc { get; set; } = 0.0m;
        public decimal DiscountForUpcResult { get; set; } = 0.0m;
        public decimal Total { get; set; } = 0.0m;


        public decimal RunningTotal { get; set; }
        private ProductPriceHandler(Product product)
        {
            Product = product;
            //RunningTotal = Product.Price;
        }

        public static IProductPriceHandler ForPriceResult(Product product) => (IProductPriceHandler)new ProductPriceHandler(product);


        //public IDiscount PerformTax()
        //{
        //    RunningTotal = RunningTotal + (RunningTotal * Tax);
        //    return this;
        //    //return Product.Price * Tax;
        //}
        public IDiscountOrUpcDiscount CalculateTax()
        {
            TaxResult = (Product.Price - (DiscountResult + DiscountForUpcResult)) * Tax;
            return this;
            //if(DiscountResult == 0.0m && DiscountForUPCResult == 0.0m)
            //{
            //    TaxResult = Product.Price * Tax;
            //} else
            //{
            //    TaxResult = (Product.Price - (DiscountResult + DiscountForUPCResult)) * Tax;
            //}
            //return Product.Price * Tax;
        }
        //public decimal CalculateTotalWithTax()
        //{
        //    return Product.Price + CalculateTax();
        //}

        //public ITax PerformDiscount()
        //{
        //    RunningTotal = RunningTotal - (RunningTotal * Discount);
        //    RunningTotal = RunningTotal - (RunningTotal * DiscountForUPC);
        //    return this;
        //    //return Product.Price * Discount;
        //}
        public ITaxOrUpcDiscount CalculateDiscount()
        {
            DiscountResult = Product.Price * Discount;
            return this;
            //return Product.Price * Discount;
        }

        public ITaxOrDiscount CalculateUpcDiscount()
        {
            DiscountForUpcResult = Product.Price * DiscountForUpc;
            return this;
            //return Product.Price * DiscountForUPC;
        }

        //public decimal CalculateTotalWithTaxAndDiscount()
        //{
        //    return CalculateTotalWithTax() - CalculateDiscount();
        //}

        //public decimal CalculateTotalWithTaxDiscountAndUPCDiscount()
        //{
        //    return CalculateTotalWithTax() - CalculateDiscount() - CalculateUPCDiscount();
        //}

        public IProductPriceHandler GetResult()
        {
            Total = Product.Price + TaxResult - DiscountResult - DiscountForUpcResult;
            return this;
            //return RunningTotal;
        }

        //##########################################



        //public Product Product { get; set; }
        //public decimal Tax { get; set; } = 0.2m;
        //public decimal Discount { get; set; } = 0.0m;
        //public decimal DiscountForUPC { get; set; } = 0.0m;


        //public decimal RunningTotal { get; set; }



        //public decimal CalculateTax()
        //{
        //    return Product.Price * Tax;
        //}
        //public decimal CalculateTotalWithTax()
        //{
        //    return Product.Price + CalculateTax();
        //}

        //public decimal CalculateDiscount()
        //{
        //    return Product.Price * Discount;
        //}

        //public decimal CalculateUPCDiscount()
        //{
        //    return Product.Price * DiscountForUPC;
        //}

        //public decimal CalculateTotalWithTaxAndDiscount()
        //{
        //    return CalculateTotalWithTax() - CalculateDiscount();
        //}

        //public decimal CalculateTotalWithTaxDiscountAndUPCDiscount()
        //{
        //    return CalculateTotalWithTax() - CalculateDiscount() - CalculateUPCDiscount();
        //}

        //public void DisplayProduct()
        //{
        //    // Product & Price
        //    Console.WriteLine($"Product {Product.Name}, was purchased for {Product.Price.DecimalPlaces(2).CurrencyStr()}");
        //    // Tax Report
        //    Console.WriteLine($"A {Tax.ToPercentage().PercentageStr()} tax, resulted in a tax of {CalculateTax().DecimalPlaces(2).CurrencyStr()}");
        //    // Discount Report
        //    Console.WriteLine($"A {Discount.ToPercentage().PercentageStr()} discount, resulted in a discount of {CalculateDiscount().DecimalPlaces(2).CurrencyStr()}");
        //    // Discount UPC Report
        //    Console.WriteLine($"A {DiscountForUPC.ToPercentage().PercentageStr()} discount for UPC {Product.UPC}, resulted in a discount of {CalculateUPCDiscount().DecimalPlaces(2).CurrencyStr()}");

        //    // Total
        //    Console.WriteLine($"For a total with tax and discount and UPC-Discount of: {CalculateTotalWithTaxDiscountAndUPCDiscount().DecimalPlaces(2).CurrencyStr()}");
        //    Console.WriteLine();
        //}
    }
}
