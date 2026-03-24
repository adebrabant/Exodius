namespace Mock.SwagLabs.Utilities;

/// <summary>
/// Serves as a base class for test entities, providing a unique instance identifier.
/// </summary>
public class TestEntity
{
    private static long _entityCounter = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestEntity"/> class.
    /// Assigns a unique, auto-incrementing entity identifier.
    /// </summary>
    protected TestEntity()
    {
        EntityId = ++_entityCounter;
    }

    /// <summary>
    /// Gets the unique identifier for this test entity.
    /// </summary>
    protected long EntityId { get; }

    /// <summary>
    /// Returns a string representation of this entity, including its name and unique identifier.
    /// </summary>
    /// <returns>A string containing the entity name and identifier.</returns>
    public override string ToString()
    {
        return $"{GetType().Name} EntityId: {EntityId}";
    }
}
