using System.Collections;
using System.Collections.Generic;

namespace price_calculator_kata_01
{
	public class AddedExpenses : IEnumerable<AddedExpense>
	{
		public List<AddedExpense> Expenses { get; set; } = new List<AddedExpense>();
		public AddedExpenses()
		{
		}
		public void Add(AddedExpense expense)
		{
			Expenses.Add(expense);
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