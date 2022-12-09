using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class DynamicCollider : Component
{
    public CollisionRectangle Shape { get; set; }

    public DynamicCollider(Entity entity) : base(entity)
    {

    }
}