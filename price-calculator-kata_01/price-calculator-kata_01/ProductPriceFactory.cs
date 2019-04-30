using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace price_calculator_kata_01
{
    class ProductPriceFactory
    {
        ProductPriceHandler ProductPricing = new ProductPriceHandler();
        private ProductPriceFactory(Product product)
        {
            ProductPricing.Product = product;
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
        public ProductPriceFactory WithUPCDiscountRate(UPCDiscounts discountInfo)
        {
            ProductPricing.DiscountForUPC = discountInfo.FindDiscountRate(ProductPricing.Product.UPC);
            //discountInfo.Where(x => x.UPC.Equals(ProductPricing.Product.UPC)).
            //ProductPricing.DiscountUPC = ProductPricing.Product.UPC.Equals(discountInfo.UPC) ?
            //    discountInfo.Discount :
            //    0.0m;
            return this;
        }

        public ProductPriceHandler GetFactoryResult()
        {
            return ProductPricing;
        }
    }
}
