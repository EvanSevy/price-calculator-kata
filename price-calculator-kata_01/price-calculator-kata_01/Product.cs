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

        public Product(string name, int upc, decimal price, decimal tax = 0.2m)
        {
            Name = name;
            UPC = upc;
            Price = price;
            Tax = tax;
        }
        
        public decimal CalculateTax()
        {
            return Price * Tax;
        }
        public decimal CalculateTotalWithTax()
        {
            return Price + CalculateTax();
        }
    }
}
