using System;

namespace AccountingWeb.Models.Services
{
    public interface IBudgetService
    {
        bool Save(string yearMonth, decimal amount);
        decimal TotalAmount(DateTime start, DateTime end);
    }
}