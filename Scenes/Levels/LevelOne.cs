using System;
using Industrio.Entities;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class LevelOne : Scene
{
    public LevelOne()
    {
        PlayerEntity.Health = 3;

        var width = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth;
        var height = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight;

        Entities.AddRange(StructureEntity.CreateRandomBackground());

        Entities.Add(new PlayerEntity() { Position = new Vector2(100, height - 64) });

        for (int i = 0; i < (width / 32) + 2; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(i * 32, height - 32)));
        }

        for (int i = 0; i < 10; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 2 + i * 32, height - 100), i, 0, 9));
        }

        for (int i = 0; i < 5; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 4 + i * 32, height - 150), i, 0, 4));
        }

        for (int i = 0; i < 10; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 2 + i * 32, height - 220), i, 0, 9));
        }

        for (int i = 0; i < 4; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 5 + i * 32, height - 280), i, 0, 3));
        }

        Entities.Add(new CrawlerSpawnerEntity() { Position = new Vector2(width / 5 + 16, height - 300), Delay = 5000f });

        Entities.Add(new PortalEntity(() => IndustrioGame.Instance.Scene = new LevelTwo()) { Position = new Vector2(width / 2 + 288, height - 254) });

        Entities.Add(new ScreenBoundaryEntity());
    }
}