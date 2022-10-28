using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class Entity
{
    public string Name { get; set; }
    public List<Component> Components { get; set; } = new List<Component>();

    public Vector2 Position { get; set; }
    public Vector2 Rotation { get; set; }
    public Vector2 Scale { get; set; }

    public event EventHandler<DrawEventArgs> OnDraw;
    public event EventHandler<UpdateEventArgs> OnUpdate;

    public Entity(string name)
    {
        Name = name;
        Position = Vector2.Zero;
        Rotation = Vector2.Zero;
        Scale = Vector2.One;
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
}