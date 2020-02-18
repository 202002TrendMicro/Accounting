using System;

namespace AccountingWeb.Models.Services
{
    public interface IBudgetService
    {
        void Save(string yearMonth, decimal amount, Action<bool> setStatusCallback);
        decimal TotalAmount(DateTime start, DateTime end);
    }
}