using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;

namespace Mock.SwagLabs.Common.Components;

public class TitleWaitComponent(IDriver driver, IEntity owner, IEventBus eventBus)
    : EntityComponent(driver, owner, eventBus), IWaitComponent
{
    private LabelElement YourCartLabel =>
        Driver.FindElement<ByTestData, LabelElement>("title");

    public async Task WaitUntilFullyLoadedAsync()
    {
        await YourCartLabel.WaitUntilVisibleAsync();
    }
}