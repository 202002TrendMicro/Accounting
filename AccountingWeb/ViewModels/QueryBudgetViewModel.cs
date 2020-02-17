using System;

namespace AccountingWeb.ViewModels
{
    public class QueryBudgetViewModel
    {
        public string Start { get; set; }
        public string End { get; set; }

        public decimal Amount { get; set; }

        public DateTime StartDate()
        {
            return DateTime.ParseExact(Start, "yyyyMMdd", null);
        }

        public DateTime EndDate()
        {
            return DateTime.ParseExact(End, "yyyyMMdd", null);
        }
    }
}