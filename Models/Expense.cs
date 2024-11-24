using System;

namespace Holiday_Expenses_API.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Holiday { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public ExpenseCategory Category { get; set; }
    }
}
