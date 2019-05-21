﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using price_calculator_kata_01.interfaces;

namespace price_calculator_kata_01
{
    public class ProductPriceFactory
    {
        IProductPriceHandler ProductPricing;
        public static UPCDiscounts UPCDiscounts { get; set; } = new UPCDiscounts();

        private ProductPriceFactory(Product product)
        {
            ProductPricing = ProductPriceHandler.ForPriceResult(product);
        }
        public static ProductPriceFactory ForProduct(Product product) => new ProductPriceFactory(product);

        public ProductPriceFactory WithTaxRate(decimal tax)
        {
            ProductPricing.Tax = tax;
            return this;
        }

        public ProductPriceFactory WithDiscountRate(decimal discount)
        {
            ProductPricing.Discount = discount;
            return this;
        }
        public ProductPriceFactory WithAddedExpense(AddedExpense expense)
        {
            //expense.ForProduct = ProductPricing.Product;
            ProductPricing.AddedExpensesResults.Add(new AddedExpenseResult(expense, ProductPricing.Product));
            return this;
        }
        public IProductPriceHandler GetFactoryResult()
        {
            return (IProductPriceHandler)ProductPricing;
        }
    }
}
