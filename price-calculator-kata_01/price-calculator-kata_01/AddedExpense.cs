using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class AddedExpense
    {
        public string Name { get; set; }
        public Product ForProduct { get; set; }
        public ExpenseType Type { get; set; }
        public decimal Value { get; set; }
    }

    enum ExpenseType { Percentage, Monetary };
}
