using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = CreateBudgetResultPage;
    public class CreateBudgetResultPage : Page<_>
    {
        [FindByName("Status")]
        public Text<_> Status { get; set; }
    }
}