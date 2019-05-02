using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    class AddedExpenses : IEnumerable<AddedExpense>
    {
        public List<AddedExpense> Expenses { get; set; } = new List<AddedExpense>();

        public void Add(AddedExpense expense)
        {
            Expenses.Add(expense);
        }
        public decimal CalculateExpenses(Product forProduct)
        {
            decimal Total = 0.0m;
            foreach(AddedExpense expense in Expenses)
            {
                if(expense.Type == ExpenseType.Monetary)
                {
                    Total += (expense.Value);
                } else if (expense.Type == ExpenseType.Percentage)
                {
                    Total += (expense.Value * forProduct.Price);
                }
            }
            return Total;
        }
        public void DisplayAllAddedExpenses()
        {
            foreach(AddedExpense expense in Expenses)
            {
                expense.DisplayAddedExpense();
            }
        }

        public IEnumerator<AddedExpense> GetEnumerator()
        {
            return ((IEnumerable<AddedExpense>)Expenses).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<AddedExpense>)Expenses).GetEnumerator();
        }
    }
}
