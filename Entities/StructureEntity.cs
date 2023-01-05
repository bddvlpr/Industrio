using System;
using System.Collections.Generic;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class StructureEntity : Entity
{
    public StaticRenderer Renderer { get; set; }
    public DynamicCollider Collider { get; set; }

    public StructureEntity()
    {
    }

    public static StructureEntity CreatePlatform(Vector2 position, int amount, int min, int max)
    {
        return CreatePlatform(position, GetFrame(amount, min, max));
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
        entity.Collider = new DynamicCollider(entity)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };
        entity.Collider.Shape = new CollisionRectangle(new Vector2(16, 16));
        return entity;
    }

    public static List<StructureEntity> CreateRandomBackground(int amount = 3)
    {
        var newEntities = new List<StructureEntity>();
        var random = new Random();

        for (int i = 0; i < amount; i++)
        {
            var position = new Vector2(
                random.Next(0, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth),
                random.Next(0, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight)
            );
            var predictionRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);

            if (newEntities.Count > 0)
            {
                foreach (var entity in newEntities)
                {
                    var entityRectangle = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, 64, 64);
                    if (predictionRectangle.Intersects(entityRectangle))
                    {
                        i--;
                        continue;
                    }
                }
            }

            newEntities.AddRange(CreateBackground(position));
        }

        return newEntities;
    }

    public static List<StructureEntity> CreateBackground(Vector2 position)
    {
        var newEntities = new List<StructureEntity>();

        for (int i = 0; i < 4; i++)
        {
            var entity = new StructureEntity()
            {
                Name = "Background",
            };

            var verticalOffset = i == 0 || i == 1 ? 0 : 32;
            var horizontalOffset = i == 0 || i == 2 ? 0 : 32;

            entity.Position = position + new Vector2(horizontalOffset, verticalOffset);
            entity.Renderer = new StaticRenderer(entity)
            {
                SpriteMap = SpriteMap.Load("Textures/Tile/Sewer"),
                Frame = i,
                Depth = 0.1f
            };
            newEntities.Add(entity);
        }
        return newEntities;
    }

    public static int GetFrame(int amount, int min, int max)
    {
        if (amount == min) return 0;
        else if (amount == max) return 3;
        else return amount % 2 == 0 ? 1 : 2;
    }
}