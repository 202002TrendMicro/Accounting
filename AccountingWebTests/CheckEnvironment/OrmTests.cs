using System;
using System.Linq;
using AccountingWeb.Models.DataModels;
using AccountingWebTests.DataModels;
using ExpectedObjects;
using NUnit.Framework;
using Budget = AccountingWebTests.DataModels.Budget;

namespace AccountingWebTests.CheckEnvironment
{
    [TestFixture]
    public class OrmTests
    {
        //if you can't get passed tests, you need to check if you installed LocalDb correctly and check the connection string setting in app.config
        //
        //<connectionStrings>
        //    <add name = "AccountingEntities" connectionString="metadata=res://*/DataModels.AccountingDataModel.csdl|res://*/DataModels.AccountingDataModel.ssdl|res://*/DataModels.AccountingDataModel.msl;provider=System.Data.SqlClient;provider connection string='data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=&quot;C:\Users\joeychen\source\repos\202002 TrendMicro\web\Accounting\AccountingWeb\App_Data\Accounting.mdf&quot;;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework'" providerName="System.Data.EntityClient" />
        //</connectionStrings>
        //
        // you have to adjust the connection string content: `connection string='data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=&quot;C:\Users\joeychen\source\repos\202002 TrendMicro\web\Accounting\AccountingWeb\App_Data\Accounting.mdf`

        [SetUp]
        [TearDown]
        public void Setup()
        {
            using (var dbContext = new NorthwindEntitiesForTest())
            {
                dbContext.Budgets.RemoveRange(dbContext.Budgets);
                dbContext.SaveChanges();
            }
        }

        [Test]
        public void add_data_and_query_data()
        {
            using (var dbContext = new NorthwindEntitiesForTest())
            {
                var amount = new Random(DateTime.Now.Millisecond).Next(0, 100);
                dbContext.Budgets.Add(new Budget() {Amount = amount, YearMonth = "202002"});
                dbContext.SaveChanges();

                var expected = new Budget() {Amount = amount, YearMonth = "202002"};
                var actual = dbContext.Budgets.First();

                expected.ToExpectedObject().ShouldMatch(actual);
            }
        }
    }
}