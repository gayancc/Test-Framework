namespace FlurTestFramework.Infrastructure.Reporter.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class ExtentNUnitDescriptionAttribute(string description) : NUnitAttribute
{
    internal string Description { get; } = description;
}