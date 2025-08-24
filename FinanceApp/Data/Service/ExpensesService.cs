using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _dbContext;
        public ExpensesService(FinanceAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddExpense(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            var expenses = await _dbContext.Expenses.ToListAsync();
            return expenses;
        }

        public async Task DeleteExpense(int id)
        {
            var expense = await _dbContext.Expenses.FindAsync(id);
            if (expense != null)
            {
                _dbContext.Expenses.Remove(expense);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Expense?> GetExpenseById(int id)
        {
            return await _dbContext.Expenses.FindAsync(id);
        }

        public async Task UpdateExpense(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<object> GetChartData()
        {
            var data = _dbContext.Expenses
                .GroupBy(e => e.Category)
                .Select(grp => new
                {
                    category = grp.Key,
                    total = grp.Sum(e => e.Amount)
                })
                .ToList();
            return data;
        }
    }
}
