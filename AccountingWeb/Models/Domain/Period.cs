using System;
using AccountingWeb.Models.Entities;

namespace AccountingWeb.Models.Domain
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public decimal OverlappingDays(Budget budget)
        {
            if (Start > budget.LastDay || End < budget.FirstDay)
            {
                return 0;
            }

            var overlappingStart = Start > budget.FirstDay ? Start : budget.FirstDay;
            var overlappingEnd = End < budget.LastDay ? End : budget.LastDay;
            return (overlappingEnd - overlappingStart).Days + 1;
        }
    }
}