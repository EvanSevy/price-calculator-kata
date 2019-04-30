﻿using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductsForPricing
    {
        public List<ProductPriceHandler> Products { get; set; } = new List<ProductPriceHandler>();
        //public List<UPCDiscount> UPCDiscounts { get; set; }
        public UPCDiscounts UPCDiscounts { get; set; } = new UPCDiscounts();
        //public int DiscountedUPC { get; set; }
        public static ProductsForPricing WithDiscountUPC(UPCDiscount upc) => new ProductsForPricing(upc);

        public ProductsForPricing(UPCDiscount discountedUPC)
        {
            UPCDiscounts.Add(discountedUPC);
            //DiscountedUPC = discountedUPC;
        }
        public void Add(ProductPriceHandler product)
        {
            Products.Add(product);
        }

        public void DisplayAllProducts()
        {
            foreach(ProductPriceHandler product in Products)
            {
                product.DisplayProduct();
            }
        }


    }
}