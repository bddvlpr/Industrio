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

    public static StructureEntity CreatePlatform(Vector2 position, int frame = 1)
    {
        var entity = new StructureEntity()
        {
            Name = "Platform",
        };
        entity.Position = position;
        entity.Renderer = new StaticRenderer(entity)
        {
            SpriteMap = SpriteMap.Load("Textures/Tile/Structure"),
            Frame = frame,
        };
        entity.Collider.Shape = new CollisionRectangle(new Vector2(16, 16));
        return entity;
    }
}