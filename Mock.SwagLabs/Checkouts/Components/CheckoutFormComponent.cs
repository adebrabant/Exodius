using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;
using Mock.SwagLabs.Checkouts.Models;

namespace Mock.SwagLabs.Checkouts.Components;

public class CheckoutFormComponent(IDriver driver, IEntity owner, IEventBus eventBus) 
    : EntityComponent(driver, owner, eventBus)
{
    private TextInputElement FirstNameTextInput =>
        Driver.FindElement<ByTestData, TextInputElement>("firstName");
    private TextInputElement LastNameTextInput =>
        Driver.FindElement<ByTestData, TextInputElement>("lastName");

    private TextInputElement PostalCodeTextInput =>
        Driver.FindElement<ByTestData, TextInputElement>("postalCode");

    public async Task FillFormAsync(CheckoutForm form)
    {
        await FirstNameTextInput.TypeInputAsync(form.FirstName);
        await LastNameTextInput.TypeInputAsync(form.LastName);
        await PostalCodeTextInput.TypeInputAsync(form.PostalCode);
    }
}
