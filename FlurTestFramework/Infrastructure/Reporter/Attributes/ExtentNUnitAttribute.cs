using NUnit.Framework.Interfaces;

namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitAttribute(string testSuiteName = "AllTests") : PropertyAttribute, ITestAction
{
    public ActionTargets Targets => ActionTargets.Suite;

    public void BeforeTest(ITest test)
    {
        ExtentNUnitManager.StartTestSuite(testSuiteName);

    }

    public void AfterTest(ITest test)
    {
        ExtentNUnitManager.StopTestSuite();
    }
}