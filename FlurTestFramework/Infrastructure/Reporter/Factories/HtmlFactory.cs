using FlurTestFramework.Infrastructure.Reporter.Engines;

namespace FlurTestFramework.Infrastructure.Reporter.Factories;

public class HtmlFactory : ExtentReporterFactory
{
    public override ITestReporter Create(AventStack.ExtentReports.ExtentReports reports, TestReporterParams reporterParams)
    {
        return new HtmlReportEngine().AttachTestReporter(reports, reporterParams.TestResultsPath);
    }
}

