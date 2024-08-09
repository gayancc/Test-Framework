using FlurTestFramework.Infrastructure.Reporter.Factories;

namespace FlurTestFramework.Infrastructure.Reporter;

public class ExtentReporter
{
    public ITestReporter ExecuteCreation(AventStack.ExtentReports.ExtentReports reporter, TestReporterParams reporterParams) => new HtmlFactory().Create(reporter, reporterParams);


}