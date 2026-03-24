using AD.Exodius.Helpers;
using AD.Exodius.Navigators.Strategies;
using Mock.SwagLabs.Logins;
using Mock.SwagLabs.Logins.Models;
using Mock.SwagLabs.Tests.Fixtures;
using NUnit.Framework;

namespace Mock.SwagLabs.Tests.Logins;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LoginTests : BaseDashboardTestStartup
{
    [TestCase("standard_user", "secret_sauce")]
    [TestCase("performance_glitch_user", "secret_sauce")]
    [TestCase("problem_user", "secret_sauce")]
    public async Task Login_ShouldSucceed_WhenCredentialsAreValid(string username, string password)
    {
        var login = new Login { Username = username, Password = password };

        var isLoginPageErrorMessagePresent = await Navigator
            .GoToAsync<LoginPage, ByRoute>()
            .Then(page => page.SubmitLoginAsync(login))
            .Then(page => page.IsErrorMessagePresentAsync());

        isLoginPageErrorMessagePresent
            .Should()
            .BeFalse();
    }

    [TestCase("standard_user", "junk")]
    [TestCase("standard_user", "hello")]
    public async Task Login_ShouldShowError_WhenPasswordIsInvalid(string username, string password)
    {
        var login = new Login { Username = username, Password = password };

        var loginPageErrorMessage = await Navigator
            .GoToAsync<LoginPage, ByRoute>()
            .Then(page => page.SubmitLoginAsync(login))
            .Then(page => page.GetErrorMessageTextAsync());

        loginPageErrorMessage
            .Should()
            .Be("Epic sadface: Username and password do not match any user in this service");
    }

    [TestCase("locked_out_user", "secret_sauce")]
    public async Task Login_ShouldShowLockedOutError_WhenUserIsLockedOut(string username, string password)
    {
        var login = new Login { Username = username, Password = password };

        var loginPageErrorMessage = await Navigator
            .GoToAsync<LoginPage, ByRoute>()
            .Then(page => page.SubmitLoginAsync(login))
            .Then(page => page.GetErrorMessageTextAsync());

        loginPageErrorMessage
            .Should()
            .Be("Epic sadface: Sorry, this user has been locked out.");
    }
}
