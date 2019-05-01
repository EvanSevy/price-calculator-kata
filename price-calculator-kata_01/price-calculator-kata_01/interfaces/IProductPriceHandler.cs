using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.interfaces
{
    interface IProductPriceHandler : ITaxOrDiscount
    {
        Product Product { get; set; }
        decimal Tax { get; set; }
        decimal Discount { get; set; }
        decimal DiscountForUPC { get; set; }

        decimal CalculateTax();
        decimal CalculateDiscount();
        decimal CalculateUPCDiscount();
    }
}
