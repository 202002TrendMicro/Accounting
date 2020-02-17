using System.Collections.Generic;
using AccountingWeb.Models.Entities;

namespace AccountingWeb.Models.Services
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll();
    }
}