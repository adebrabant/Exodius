using AD.Exodius.Drivers;
using AD.Exodius.Entities.Pages;

namespace AD.Exodius.Navigators.Strategies;

/// <summary>
/// Navigation strategy that does nothing. 
/// Useful when the page is already loaded and you just want 
/// components initialized without routing.
/// </summary>
public class ByNoOp : INavigationStrategy
{
    public Task NavigateAsync<TPage>(IDriver driver, TPage page) where TPage : IPageEntity
    {
        return Task.CompletedTask;
    }
}