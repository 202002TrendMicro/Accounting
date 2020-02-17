namespace AccountingWeb.Models.Services
{
    public interface IBudgetService
    {
        bool Save(string yearMonth, decimal amount);
    }
}