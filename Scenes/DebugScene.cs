using System;
using Industrio.Engine;
using Industrio.Engine.UI;
using Industrio.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Scenes;

public static class DebugSceneCreator
{
    public static Scene CreateTestArea()
    {

        var width = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth;
        var height = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight;

        var scene = new Scene();
        var player = new PlayerEntity();

        scene.Entities.Add(new PlayerEntity());

        for (int i = 0; i < width / 32; i++)
        {
            scene.Entities.Add(StructureEntity.CreatePlatform(new Vector2(i * 32, height - 32)));
        }

        scene.Entities.Add(StructureEntity.CreatePlatform(new Vector2(0, height - 64)));
        scene.Entities.Add(StructureEntity.CreatePlatform(new Vector2(width - 32, height - 64)));

        scene.Entities.Add(new FloaterEntity() { Position = new Vector2(100, 100) });

        scene.Entities.AddRange(StructureEntity.CreateRandomBackground(8));

        scene.Entities.Add(new ScreenBoundaryEntity());

        return scene;
    }
}