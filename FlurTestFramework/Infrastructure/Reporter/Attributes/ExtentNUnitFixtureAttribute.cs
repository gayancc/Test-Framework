using NUnit.Framework.Interfaces;

namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitFixtureAttribute : PropertyAttribute, ITestAction
{
    public ActionTargets Targets => ActionTargets.Test;
    public string TestId;
    public bool AttachScreenShot = false;

    public ExtentNUnitFixtureAttribute(bool attachScreenShotOnFailure)
    {
        AttachScreenShot = attachScreenShotOnFailure;
    }

    public void BeforeTest(ITest test)
    {
        TestId = ExtentNUnitManager.StartTest(test);
    }

    public void AfterTest(ITest test)
    {
        ExtentNUnitManager.StopTest(TestId, TestContext.CurrentContext, test, AttachScreenShot);
    }

}