using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; } = 0.2m;
        public decimal Discount { get; set; } = 0;

        public Product(string name, int upc, decimal price, decimal tax = 0.2m, decimal discount = 0.0m)
        {
            Name = name;
            UPC = upc;
            Price = price;
            Tax = tax;
            Discount = discount;
        }
        
        public decimal CalculateTax()
        {
            return Price * Tax;
        }
        public decimal CalculateTotalWithTax()
        {
            return Price + CalculateTax();
        }

        public decimal CalculateDiscount()
        {
            return Price * Discount;
        }

        public decimal CalculateTotalWithTaxAndDiscount()
        {
            return CalculateTotalWithTax() - CalculateDiscount();
        }
    }
}
