using AD.Exodius.Helpers;
using AD.Exodius.Navigators.Strategies;
using Mock.SwagLabs.Configurations.Models;
using Mock.SwagLabs.Logins;
using Mock.SwagLabs.Logins.Mappers;

namespace Mock.SwagLabs.Tests.Fixtures;

public class BypassLoginTestStartup : BaseDashboardTestStartup
{
    protected override async Task OnSetUpAsync()
    {
        await base.OnSetUpAsync();

        var login = ApplicationSettings
            .GetFirstUser()
            .ToLogin();

        await Navigator
            .GoToAsync<LoginPage, ByRoute>()
            .Then(page => page.SubmitLoginAsync(login));
    }
}
