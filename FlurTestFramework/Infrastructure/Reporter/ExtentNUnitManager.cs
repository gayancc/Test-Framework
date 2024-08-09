using System.Reflection;
using AventStack.ExtentReports;
using FlurTestFramework.Infrastructure.Helpers;
using FlurTestFramework.Infrastructure.Reporter.Attributes;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace FlurTestFramework.Infrastructure.Reporter;

public static class ExtentNUnitManager
{
    private static AventStack.ExtentReports.ExtentTest _testSuite;
    private static string _testSuiteName;

    private static readonly Dictionary<string, AventStack.ExtentReports.ExtentTest> TestCollection = [];

    private static readonly Lazy<AventStack.ExtentReports.ExtentReports> Lazy = new(() => new AventStack.ExtentReports.ExtentReports());

    public static AventStack.ExtentReports.ExtentReports Instance => Lazy.Value;

    static ExtentNUnitManager() { }

    public static void StartTestSuite(string testSuiteName)
    {
        _testSuiteName = testSuiteName;
        _testSuite = Instance.CreateTest(_testSuiteName, GenerateId());
        TestCollection.Add(_testSuite.Model.Description, _testSuite);
    }

    public static void StopTestSuite()
    {
        Instance.Flush();
    }

    public static string StartTest(ITest test)
    {
        var testId = GenerateId();
        var childTest = _testSuite.CreateNode(test.FullName, testId);
        TestCollection.Add(testId, childTest);
        return testId;
    }

    public static void StopTest(string testId, TestContext context, ITest unitTest, bool includeScreenShotsOnFailure)
    {
        var test = TestCollection[testId];
        var attributes = unitTest.Method?.GetCustomAttributes<NUnitAttribute>(true).ToList();

        attributes?.AddRange(GetTestFixture(unitTest).GetCustomAttributes<NUnitAttribute>(true).ToList());
        ProcessAttributes(test, attributes);

        EvaluateTestResults(test, context, includeScreenShotsOnFailure);
    }

    private static void EvaluateTestResults(AventStack.ExtentReports.ExtentTest test, TestContext context, bool includeScreenShotsOnFailure)
    {
        var result = context.Result;
        switch (result.Outcome.Status)
        {
            case TestStatus.Passed:
                {
                    test.Pass(context.Test.ToTable());
                    break;
                }

            case TestStatus.Skipped:
                test.Skip("Skipped");
                break;
            case TestStatus.Inconclusive:
                test.Info("Inconclusive");
                break;
            case TestStatus.Warning:
                test.Warning("Warning: " + result.StackTrace);
                break;
            case TestStatus.Failed:
            default:
                test.Fail(result.StackTrace);
                if (includeScreenShotsOnFailure)
                {
                    DirectoryInfo taskDirectory = new DirectoryInfo(context.WorkDirectory);
                    FileInfo[] files = taskDirectory.GetFiles($"{test.Model.Name}*.png");
                    if (files.Any())
                    {
                        FileInfo file = files.Last();
                        test.AddScreenCaptureFromPath(file.FullName);
                    }

                }
                break;
        }
    }

    private static void ProcessAttributes(AventStack.ExtentReports.ExtentTest test, List<NUnitAttribute> attributes)
    {
        foreach (var attribute in attributes)
        {
            switch (attribute)
            {
                case ExtentNUnitCategoryAttribute categoryAttribute:
                    test.AssignCategory(categoryAttribute.ExtentCategory);
                    break;
                case ExtentNUnitAuthorAttribute authorAttribute:
                    test.AssignAuthor(authorAttribute.ExtentAuthor);
                    break;
                case ExtentNUnitDeviceAttribute deviceAttribute:
                    test.AssignAuthor(deviceAttribute.ExtentDevice);
                    break;
                case ExtentNUnitDescriptionAttribute descriptionAttribute:
                    test.Model.Description = $"{descriptionAttribute.Description} - {test.Model.Description}";
                    break;
                default:
                    break;
            }
        }
    }

    private static string GenerateId() => Guid.NewGuid().ToString("N");


    private static TestFixture GetTestFixture(ITest test)
    {
        var currentTest = test;
        var isTestSuite = currentTest.IsSuite;
        while (isTestSuite != true)
        {
            if (currentTest == null) continue;
            currentTest = currentTest.Parent;
            if (currentTest is ParameterizedMethodSuite) currentTest = currentTest.Parent;
            if (currentTest != null) isTestSuite = currentTest.IsSuite;
        }

        return (TestFixture)currentTest;
    }

    public static AventStack.ExtentReports.ExtentTest GetTest(string testId)
    {
        return TestCollection[testId];
    }
}
