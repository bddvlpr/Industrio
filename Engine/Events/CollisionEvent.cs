using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class CollisionEventArgs : EventArgs
{
    public GameTime GameTime { get; set; }
    public Entity Entity { get; set; }

    public CollisionEventArgs(GameTime gameTime, Entity entity)
    {
        GameTime = gameTime;
        Entity = entity;
    }
}