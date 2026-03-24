using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;

namespace Mock.SwagLabs.Common.Components;

public class LogoWaitComponent(IDriver driver, IEntity owner, IEventBus eventBus)
    : EntityComponent(driver, owner, eventBus), IWaitComponent
{

    private LabelElement LogoLabel =>
        Driver.FindElement<ByText, LabelElement>("Swag Labs");

    public async Task WaitUntilFullyLoadedAsync()
    {
        await LogoLabel.WaitUntilVisibleAsync();
    }
}
