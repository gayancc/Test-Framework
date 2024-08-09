namespace FlurTestFramework.Infrastructure.Reporter.Engines;

public class HtmlReportEngine : ITestReporter
{
    public ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string location)
    {
        var html = new AventStack.ExtentReports.Reporter.ExtentSparkReporter(location);
        reporter.AttachReporter(html);

        return this;
    }

    public ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string projectName, string buildName, string host, int port, string address)
    {
        throw new NotImplementedException();
    }
}
