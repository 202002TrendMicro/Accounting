using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = CreateBudgetResultPage;
    public class CreateBudgetResultPage : Page<_>
    {
        public Text<_> Status { get; set; }
    }
}