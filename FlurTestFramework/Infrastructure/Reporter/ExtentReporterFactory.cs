namespace FlurTestFramework.Infrastructure.Reporter;

public abstract class ExtentReporterFactory
{
    public abstract ITestReporter Create(AventStack.ExtentReports.ExtentReports reports, TestReporterParams reporterParams);
}