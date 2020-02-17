using AccountingWebTests.DataModels;
using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = CreateBudgetsPage;

    [Url("budgets/create")]
    public class CreateBudgetsPage : Page<_>
    {
        public CreateBudgetResultPage Create(Budget budget)
        {
            throw new System.NotImplementedException();
        }

    }
}