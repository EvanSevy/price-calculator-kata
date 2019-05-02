using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class AddedExpense
    {
        public string Name { get; set; }
        public ExpenseType Type { get; set; }
        public decimal Value { get; set; }
        public decimal Result { get; set; }
        public void CalculateExpenseResult (Product forProduct)
        {
            if (Type == ExpenseType.Percentage)
                Result = Value * forProduct.Price;
            else if (Type == ExpenseType.Monetary)
            {
                Result = Value;
            }
        }
        public void DisplayAddedExpense()
        {
            String ValueStr = (Type == ExpenseType.Monetary) ? Value.DecimalPlaces(2).CurrencyStr() : Value.DecimalPlaces(2).PercentageStr();
            Console.WriteLine($"Added expense of {Name}, for {ValueStr}, resulted in a cost of {Result}");
        }
    }

    enum ExpenseType { Percentage, Monetary };
}
