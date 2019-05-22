using price_calculator_kata_01.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class ProductsForPricing : IEnumerable<IProductPriceHandler>
    {
        public List<IProductPriceHandler> Products { get; set; } = new List<IProductPriceHandler>();
        public void Add(IProductPriceHandler product)
        {
            Products.Add(product);
        }

        public void DisplayAllProducts()
        {
            foreach (ProductPriceHandler product in Products)
            {
				ProductPriceHandler.Display(product);
			}
        }

        public IEnumerator<IProductPriceHandler> GetEnumerator()
        {
            return ((IEnumerable<IProductPriceHandler>)Products).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IProductPriceHandler>)Products).GetEnumerator();
        }
    }
}
