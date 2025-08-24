using FinanceApp.Data;
using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
           
        public async Task<IActionResult> ExpensesList()
        {
            var expenses = await _expensesService.GetAllExpenses();
            return View(expenses);
        }

        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.AddExpense(expense);
                return RedirectToAction("ExpensesList");
            }
            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expensesService.DeleteExpense(id);
            return RedirectToAction("ExpensesList");
        }

        public async Task<IActionResult> EditExpense(int id)
        {
            var expense = await _expensesService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.UpdateExpense(expense);
                return RedirectToAction("ExpensesList");
            }
            return View(expense);
        }

        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
