using AD.Exodius.Components;
using AD.Exodius.Drivers;
using AD.Exodius.Events;

namespace AD.Exodius.Entities.Pages;

public class PageEntity : Entity, IPageEntity
{
    public PageEntity(IDriver driver, IEventBus eventBus)
        :base(driver, eventBus)
    {
        EventBus.Subscribe<PageReadyCheckEvent>(OnReadyCheck);
    }

    private async Task OnReadyCheck(PageReadyCheckEvent _)
    {
        await WaitUntilReadyAsync();
    }

    public virtual async Task WaitUntilReadyAsync()
    {
        var waitSections = GetComponents<IWaitComponent>();

        await Task.WhenAll(waitSections
            .Select(section => section.WaitUntilFullyLoadedAsync()));
    }
}
