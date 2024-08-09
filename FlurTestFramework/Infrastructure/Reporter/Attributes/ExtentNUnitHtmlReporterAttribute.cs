using NUnit.Framework.Interfaces;

namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitHtmlReporterAttribute : PropertyAttribute, ITestAction
{
    public ExtentNUnitHtmlReporterAttribute()
    {
        var paramter = new TestReporterParams
        {
            //TestResultsPath = TestContext.CurrentContext.WorkDirectory
            TestResultsPath = TestConfiguraiton.ReportPath
        };
        new ExtentReporter().ExecuteCreation(ExtentNUnitManager.Instance, paramter);
    }
    public void BeforeTest(ITest test)
    {

    }

    public void AfterTest(ITest test)
    {

    }

    public ActionTargets Targets => ActionTargets.Suite;
}
