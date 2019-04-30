using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductsForPricing
    {
        public List<ProductPriceHandler> Products { get; set; } = new List<ProductPriceHandler>();
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
