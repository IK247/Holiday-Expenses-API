using Holiday_Expenses_API.Models;
using LiteDB;
using System.Collections.Generic;

namespace Holiday_Expenses_API.Data
{
    public class Database : DataContext
    {
        private readonly LiteDatabase _db;

        public Database()
        {
            _db = new LiteDatabase(@"data.db");
        }

        public void AddExpense(Expense expense)
        {
            _db.GetCollection<Expense>("Expenses").Insert(expense);
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return _db.GetCollection<Expense>("Expenses").FindAll();
        }

        public void DeleteExpense(int id)
        {
            _db.GetCollection<Expense>("Expenses").Delete(id);
        }

        public void UpdateExpense(int id, Expense expense)
        {
            var expenses = _db.GetCollection<Expense>("Expenses");
            expense.Id = id; 
            expenses.Update(expense);
        }

        public IEnumerable<Expense> SearchExpenses(string search)
        {
            return _db.GetCollection<Expense>("Expenses")
                      .Find(x => x.Description != null && x.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Expense> SearchCategory(string category)
        {
            return _db.GetCollection<Expense>("Expenses")
                      .Find(x => x.Category.ToString().Equals(category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
