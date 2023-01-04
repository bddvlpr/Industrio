using Industrio.Entities;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class LevelOne : Scene
{
    public LevelOne()
    {
        var width = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth;
        var height = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight;

        Entities.Add(new PlayerEntity() { Position = new Vector2(100, height - 64) });

        for (int i = 0; i < (width / 32) + 2; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(i * 32, height - 32)));
        }

        for (int i = 0; i < 10; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 2 + i * 32, height - 112), i, 0, 9));
        }

        for (int i = 0; i < 5; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 4 + i * 32, height - 192), i, 0, 4));
        }

        for (int i = 0; i < 10; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 2 + i * 32, height - 256), i, 0, 9));
        }

        for (int i = 0; i < 4; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(width / 5 + i * 32, height - 340), i, 0, 3));
        }

        Entities.Add(new CrawlerSpawnerEntity() { Position = new Vector2(width / 2 + 288, height - 288), Delay = 2000f });
    }
}