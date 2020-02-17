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

        public decimal OverlappingDays(Period another)
        {
            if (Start > another.End || End < another.Start)
            {
                return 0;
            }

            var overlappingStart = Start > another.Start ? Start : another.Start;
            var overlappingEnd = End < another.End ? End : another.End;
            return (overlappingEnd - overlappingStart).Days + 1;
        }
    }
}