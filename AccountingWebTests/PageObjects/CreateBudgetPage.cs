using AccountingWebTests.DataModels;
using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = CreateBudgetPage;

    [Url("budgets/create")]
    public class CreateBudgetPage : Page<_>
    {
        public CreateBudgetResultPage Create(Budget budget)
        {
            throw new System.NotImplementedException();
        }
    }
}