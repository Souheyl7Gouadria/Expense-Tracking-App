using FinanceApp.Models;

namespace FinanceApp.Data.Service
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAllExpenses();

        Task AddExpense(Expense expense);

        Task DeleteExpense(int id);

        Task<Expense?> GetExpenseById(int id);

        Task UpdateExpense(Expense expense);

        IEnumerable<object> GetChartData();
    }
}
