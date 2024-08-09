namespace FlurTestFramework.Infrastructure;

public static class TestExtensions
{


    public static T ShouldNotNull<T>(this T obj)
    {
        Assert.That(obj, Is.Not.Null);
        return obj;
    }

    public static T ShouldNotNull<T>(this T obj, string message)
    {
        Assert.That(obj, Is.Not.Null, message);
        return obj;
    }

    public static T ShouldNotBeNull<T>(this T obj)
    {
        Assert.That(obj, Is.Not.Null);
        return obj;
    }

    public static T ShouldNotBeNull<T>(this T obj, string message)
    {
        Assert.That(obj, Is.Not.Null, message);
        return obj;
    }

    public static T ShouldEqual<T>(this T actual, object expected)
    {
        Assert.That(actual, Is.EqualTo(expected));
        return actual;
    }

    public static void ShouldEqual(this object actual, object expected, string message)
    {
        Assert.That(actual, Is.EqualTo(expected), message);
    }

    public static System.Exception ShouldBeThrownBy(this Type exceptionType, TestDelegate testDelegate)
    {
        return Assert.Throws(exceptionType, testDelegate);
    }

    public static void ShouldBe<T>(this object actual)
    {
        Assert.That(actual, Is.InstanceOf<T>());
    }

    public static void ShouldBeNull(this object actual)
    {
        Assert.That(actual, Is.Null);
    }

    public static void ShouldBeTheSameAs(this object actual, object expected)
    {
        Assert.That(actual, Is.SameAs(expected));
    }

    public static void ShouldBeNotBeTheSameAs(this object actual, object expected)
    {
        Assert.That(actual, Is.Not.SameAs(expected));
    }

    public static T CastTo<T>(this object source)
    {
        return (T)source;
    }

    public static void ShouldBeTrue(this bool source)
    {
        Assert.That(source, Is.True);
    }

    public static void ShouldBeFalse(this bool source)
    {
        Assert.That(source, Is.False);
    }

    public static void AssertSameStringAs(this string actual, string expected)
    {
        if (!string.Equals(actual, expected, StringComparison.InvariantCultureIgnoreCase))
        {
            var message = $"Expected {expected} but was {actual}";
            throw new AssertionException(message);
        }
    }

    public static T PropertiesShouldEqual<T>(this T actual, T expected, params string[] filters)
    {
        var properties = typeof(T).GetProperties().ToList();

        var filterByEntities = new List<string>();
        var values = new Dictionary<string, object>();

        foreach (var propertyInfo in properties.ToList())
        {
            if (filters.Any(f => f == propertyInfo.Name || f + "Id" == propertyInfo.Name) || propertyInfo.Name == "Id")
                continue;
            var value = propertyInfo.GetValue(actual);
            values.Add(propertyInfo.Name, value);

            if (value == null)
                continue;

            if (value.GetType().IsArray || value.GetType().Namespace == "System.Collections.Generic")
            {
                properties.Remove(propertyInfo);
                continue;
            }


            filterByEntities.Add(propertyInfo.Name + "Id");
            properties.Remove(propertyInfo);
        }

        foreach (var propertyInfo in properties.Where(p => values.ContainsKey(p.Name)))
        {
            if (filterByEntities.Any(f => f == propertyInfo.Name))
                continue;

            Assert.That(values[propertyInfo.Name], Is.EqualTo(propertyInfo.GetValue(expected)),
                $"The property \"{typeof(T).Name}.{propertyInfo.Name}\" of these objects is not equal");
        }

        return actual;
    }
}