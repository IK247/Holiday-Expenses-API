using Holiday_Expenses_API.Data;
using Holiday_Expenses_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Holiday_Expenses_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly DataContext _data;

        public ExpenseController(DataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Expense expense)
        {
            try
            {
                _data.AddExpense(expense);
                return Ok(new { message = "Expense added " });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("all")]
        public IActionResult GetExpenses()
        {
            try
            {
                var expenses = _data.GetExpenses();
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            try
            {
                _data.DeleteExpense(id);
                return Ok(new { message = "Expense deleted " });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, [FromBody] Expense expense)
        {
            try
            {
                _data.UpdateExpense(id, expense);
                return Ok(new { message = "Expense updated " });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("search")]
        public IActionResult SearchExpenses([FromQuery] string search)
        {
            try
            {
                var results = _data.SearchExpenses(search);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("category")]
        public IActionResult SearchByCategory([FromQuery] string category)
        {
            try
            {
                var results = _data.SearchCategory(category);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
