namespace FlurTestFramework.Infrastructure.Reporter;

public interface ITestReporter
{
    ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string location);
    ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string projectName, string buildName, string host, int port, string address);
}