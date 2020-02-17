using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = QueryBudgetsPage;

    [Url("budgets/query")]
    public class QueryBudgetsPage : Page<_>
    {
        public void Query(string start, string end)
        {
            throw new System.NotImplementedException();
        }

        public Text<_> Amount { get; set; }
    }
}