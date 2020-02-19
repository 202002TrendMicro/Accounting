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
            return this
                   .YearMonth.Set(budget.YearMonth)
                   .Amount.Set(budget.Amount)
                   .CreateBudget.ClickAndGo();
        }

        [FindByValue("Create")] public Button<CreateBudgetResultPage, _> CreateBudget { get; set; }
        [FindByName("Amount")] public NumberInput<_> Amount { get; set; }
        [FindByName("YearMonth")] public TextInput<_> YearMonth { get; set; }
    }
}