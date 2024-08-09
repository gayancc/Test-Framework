namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitDeviceAttribute(string extentDevice) : NUnitAttribute
{
    internal string ExtentDevice { get; } = extentDevice;
}