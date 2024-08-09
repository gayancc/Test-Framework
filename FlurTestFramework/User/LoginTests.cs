using Flurl;
using Flurl.Http;
using FlurTestFramework.Infrastructure;
using FlurTestFramework.Infrastructure.Helpers;
using FlurTestFramework.Infrastructure.Reporter.Attributes;
using FlurTestFramework.Models;

namespace FlurTestFramework.User;

[TestFixture]
[ExtentNUnit("User Tests")]
[ExtentNUnitFixture(true)]
[ExtentNUnitHtmlReporter]
public class LoginTests : BaseTestRunner
{

    [ExtentNUnitCategory("User Login Test")]
    [ExtentNUnitDescription("User should be able to login with username and password")]
    [TestCase("mail2@gmail.com", "Test-123", "IFE", true, TestName = "To verify the status code of Login Request")]
    [TestCase("mail@gmail.com", "Test-1232222", "IFE22", true, TestName = "To verify the status code of Login Request")]
    public async Task LoginRequestStatusCodeValidation(string username, string password, string channel, bool oAuth)
    {
        var requestBody = new Login_RequestDTO { UserName = username, Password = password, Channel = channel, OAuth = oAuth };
        var response = await Baseurl
            .AppendPathSegment(UrlHelper.LOGIN_URL)
            .PostJsonAsync(requestBody);
        response.StatusCode.ShouldEqual(404);

    }
}