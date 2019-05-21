using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace price_calculator_kata_01
{
	public class AddedExpenses : IEnumerable<AddedExpenseResult>
    {
        public List<AddedExpenseResult> Expenses { get; set; } = new List<AddedExpenseResult>();
        public decimal TotalOfExpenses { get; set; } = 0.0m;

        public void Add(AddedExpenseResult expense)
        {
            Expenses.Add(expense);
        }
        public void CalculateExpenses()
        {
            TotalOfExpenses = Expenses.Sum(e => e.Result);
        }
        public void DisplayAllAddedExpenses()
        {
            foreach(AddedExpenseResult expense in Expenses)
            {
                expense.DisplayAddedExpense();
            }
        }

        public IEnumerator<AddedExpenseResult> GetEnumerator()
        {
            return ((IEnumerable<AddedExpenseResult>)Expenses).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<AddedExpenseResult>)Expenses).GetEnumerator();
        }
    }
}
