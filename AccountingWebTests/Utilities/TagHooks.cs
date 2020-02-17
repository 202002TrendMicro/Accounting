using System.Linq;
using AccountingWebTests.DataModels;
using TechTalk.SpecFlow;

namespace AccountingWebTests.Utilities
{
    [Binding]
    public class TagHooks : Steps
    {
        [BeforeScenario()]
        public void SetUpScenario()
        {
            CleanTable();
        }

        private void CleanTable()
        {
            var tags = ScenarioContext.ScenarioInfo.Tags.Where(x => x.StartsWith("Clean")).Select(x => x.Replace("Clean", ""));

            foreach (var tag in tags)
            { 
                using (var dbContext = new AccountingEntitiesForTest())
                {
                    dbContext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
                }
            }
        }
    }
}