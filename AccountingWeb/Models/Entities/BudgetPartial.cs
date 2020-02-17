using System;
using AccountingWeb.Models.Domain;

namespace AccountingWeb.Models.Entities
{
    public partial class Budget
    {
        private DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
        private DateTime LastDay => DateTime.ParseExact(YearMonth + DaysInMonth(), "yyyyMMdd", null);

        public decimal OverlappingAmount(Period period)
        {
            return period.OverlappingDays(CreatePeriod()) * DailyAmount();
        }

        private Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }

        private decimal DailyAmount()
        {
            return Amount / DaysInMonth();
        }

        private int DaysInMonth()
        {
            return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
        }
    }
}