namespace AccountingWeb.Models.Domain
{
    public interface IBudgetManager
    {
        bool Save(string yearMonth, decimal amount);
    }
}