using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class StructureEntity : Entity
{
    public StaticRenderer Renderer { get; set; }
    public DynamicCollider Collider { get; set; }

    public StructureEntity()
    {
        Name = "StructureTile";

        Renderer = new StaticRenderer(this)
        {
            SpriteMap = SpriteMap.Load("Textures/Tile/Structure"),
            Frame = 0,
        };

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };
    }
}