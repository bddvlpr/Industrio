using System;
using Industrio.Entities;
using Industrio.Scenes;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class LevelTwo : Scene
{
    public LevelTwo()
    {
        var width = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth;
        var height = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight;

        Entities.AddRange(StructureEntity.CreateRandomBackground());

        Entities.Add(new PlayerEntity() { Position = new Vector2(100, height - 64) });

        for (int i = 0; i < (width / 32) + 2; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(i * 32, height - 32)));
        }

        Entities.Add(new TurretEntity() { Position = new Vector2(width - 128, height - 64), FlippedHorizontally = true });

        Entities.Add(new JumpPadEntity() { Position = new Vector2(width - 64, height - 64) });

        for (int i = 0; i < (width / 32) - 4; i++)
        {
            Entities.Add(StructureEntity.CreatePlatform(new Vector2(i * 32, height - 192), i, 0, (width / 32) - 3));
        }

        Entities.Add(new FloaterEntity() { Position = new Vector2(128, 192) });

        Entities.Add(new PortalEntity(() => IndustrioGame.Instance.Scene = new GameWonScene()) { Position = new Vector2(64, height - (192 + 32)) });

        Entities.Add(new ScreenBoundaryEntity());
    }
}