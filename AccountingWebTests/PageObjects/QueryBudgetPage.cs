using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = QueryBudgetPage;

    [Url("budgets/query")]
    public class QueryBudgetPage : Page<_>
    {
        public void Query(string start, string end)
        {
            this
                .Start.Set(start)
                .End.Set(end)
                .QueryBudget.Click();
        }

        [FindByName("Query")] public Button<_> QueryBudget { get; set; }
        [FindByName("End")] public TextInput<_> End { get; set; }
        [FindByName("Start")] public TextInput<_> Start { get; set; }
        [FindByName("TotalAmount")] public Text<_> TotalAmount { get; set; }
    }
}