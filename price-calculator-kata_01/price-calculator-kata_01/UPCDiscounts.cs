using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace price_calculator_kata_01
{
    public class UPCDiscounts
    {
        public List<UPCDiscount> Discounts { get; set; } = new List<UPCDiscount>();

        public decimal FindDiscountRate(int upc)
        {
            decimal discountRate = Discounts.Where(d => d.UPC.Equals(upc)).Select(d => d.Discount).FirstOrDefault();
            return discountRate;
        }

        public void Add(UPCDiscount discount)
        {
            Discounts.Add(discount);
        }
    }
}
