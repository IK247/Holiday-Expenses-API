using Holiday_Expenses_API.Models;
using System.Collections.Generic;

namespace Holiday_Expenses_API.Data
{
    public interface DataContext
    {
        void AddExpense(Expense expense);
        IEnumerable<Expense> GetExpenses();
        void DeleteExpense(int id);
        void UpdateExpense(int id, Expense expense);
        IEnumerable<Expense> SearchExpenses(string search);
        IEnumerable<Expense> SearchCategory(string category);
    }
}
