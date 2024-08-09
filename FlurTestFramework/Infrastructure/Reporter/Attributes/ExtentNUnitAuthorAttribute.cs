namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitAuthorAttribute(string extentAuthor) : NUnitAttribute
{
    internal string ExtentAuthor { get; } = extentAuthor;
}