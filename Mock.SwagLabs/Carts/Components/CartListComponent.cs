using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;

namespace Mock.SwagLabs.Carts.Components;

public class CartListComponent(IDriver driver, IEntity owner, IEventBus eventBus)
    : EntityComponent(driver, owner, eventBus)
{

}