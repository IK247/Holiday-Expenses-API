using Holiday_Expenses_API.Models;
using System.Collections.Generic;
using System;

namespace Holiday_Expenses_API.Data
{
    public class DataList : DataContext
    {
        private readonly List<Expense> _expenses = new();

        public void AddExpense(Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            _expenses.Add(expense);
        }

        public void DeleteExpense(int id)
        {
            if (id < 0 || id >= _expenses.Count)
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid ID ");

            _expenses.RemoveAt(id);
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return _expenses;
        }

        public IEnumerable<Expense> SearchExpenses(string search)
        {
            if (string.IsNullOrEmpty(search)) return _expenses;
            return _expenses.Where(e => e.Description?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false);
        }

        public void UpdateExpense(int id, Expense expense)
        {
            if (id < 0 || id >= _expenses.Count)
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid ID ");

            if (expense == null) throw new ArgumentNullException(nameof(expense));

            _expenses[id] = expense;
        }

        public IEnumerable<Expense> SearchCategory(string category)
        {
            if (string.IsNullOrEmpty(category)) return _expenses;
            return _expenses.Where(e => e.Category.ToString().Equals(category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
