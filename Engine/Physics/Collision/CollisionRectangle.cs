using System;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class CollisionRectangle
{
    public Vector2 Size { get; set; }
    public Vector2 Start => Vector2.Zero;
    public Vector2 End => Size;

    public CollisionRectangle(Vector2 size)
    {
        Size = size * SpriteMap.Scale;
    }

    public bool Intersects(CollisionRectangle other)
    {
        return Size.X < other.Size.X && Size.Y < other.Size.Y;
    }
}