using System;

namespace Industrio.Engine;

public abstract class Component : ICloneable
{
    public Entity Entity { get; init; }

    public Component(Entity entity)
    {
        Entity = entity;
        Entity.Components.Add(this);
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}