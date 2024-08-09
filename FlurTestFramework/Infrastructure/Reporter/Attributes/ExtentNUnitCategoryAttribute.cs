namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitCategoryAttribute(string extentCategory) : NUnitAttribute
{
    internal string ExtentCategory { get; } = extentCategory;
}