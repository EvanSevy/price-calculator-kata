using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    public class AddedExpense
    {
        public string Name { get; set; }
		public ExpenseType Type { get; set; }
		public decimal Value { get; set; }
	}

    public enum ExpenseType { Percentage, Monetary };
}
