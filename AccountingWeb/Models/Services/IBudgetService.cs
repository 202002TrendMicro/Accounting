namespace AccountingWeb.Models.Services
{
    public interface IBudgetService
    {
        void Save(string yearMonth, decimal amount);
    }
}