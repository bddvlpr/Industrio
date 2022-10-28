namespace Industrio.Engine;

public abstract class Component
{
    public Entity Entity { get; init; }

    public Component(Entity entity)
    {
        Entity = entity;
    }
}