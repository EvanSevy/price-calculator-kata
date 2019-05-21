using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    public class AddedExpenseResult
    {
        public AddedExpense AddedExpense { get; set; }
		public Product ForProduct { get; set; }
		public decimal Result { get; set; }

        public AddedExpenseResult(AddedExpense addedExpense, Product forProduct)
        {
            AddedExpense = addedExpense;
			ForProduct = forProduct;
            SetResult();
        }
        private void SetResult()
        {
            if (AddedExpense.Type == ExpenseType.Percentage)
                Result = (AddedExpense.Value / 100) * ForProduct.Price;
            else if (AddedExpense.Type == ExpenseType.Monetary)
            {
                Result = AddedExpense.Value;
            }
        }
        public void DisplayAddedExpense()
        {
            String ValueStr = (AddedExpense.Type == ExpenseType.Monetary) ? AddedExpense.Value.DecimalPlaces(2).CurrencyStr() : AddedExpense.Value.DecimalPlaces(2).PercentageStr();
            Console.WriteLine($"Added expense of {AddedExpense.Name}, for {ValueStr}, resulted in a cost of {Result.DecimalPlaces(2).CurrencyStr()}");
        }
    }
}
