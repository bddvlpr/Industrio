using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class Entity : ICloneable
{
    public string Name { get; set; }
    public List<Component> Components { get; init; } = new List<Component>();

    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;

    public bool FlippedHorizontally { get; set; } = false;
    public bool FlippedVertically { get; set; } = false;

    public event EventHandler<DrawEventArgs> OnDraw;
    public event EventHandler<UpdateEventArgs> OnUpdate;

    public Entity(string name)
    {
        Name = name;
    }

    public Entity() : this("Untitled Entity") { }

    public void InvokeDraw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        OnDraw?.Invoke(this, new DrawEventArgs(gameTime, spriteBatch));
    }

    public void InvokeUpdate(GameTime gameTime)
    {
        OnUpdate?.Invoke(this, new UpdateEventArgs(gameTime));
    }

    public T GetComponent<T>() where T : Component
    {
        return (T)Components.Find(component => component is T);
    }

    public bool HasComponent<T>() where T : Component
    {
        return Components.Exists(component => component is T);
    }

    public object Clone()
    {
        var clone = new Entity(Name);
        clone.Position = Position;
        clone.Scale = Scale;
        clone.FlippedHorizontally = FlippedHorizontally;
        clone.FlippedVertically = FlippedVertically;

        foreach (var component in Components)
        {
            clone.Components.Add((Component)component.Clone());
        }

        return clone;
    }
}