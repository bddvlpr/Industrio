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
        var scene = new Scene();

        var player = new PlayerEntity();

        scene.Entities.Add(player);

        for (int i = 0; i < IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth / 32; i++)
        {
            scene.Entities.Add(StructureEntity.CreatePlatform(new Vector2(i * 32, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight - 32)));
        }

        var crawler = new CrawlerEntity() { Position = new Vector2(200, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight - 64) };
        scene.Entities.Add(crawler);

        var floater = new FloaterEntity() { Position = new Vector2(200, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight - 64) };
        scene.Entities.Add(floater);

        scene.Entities.Add(StructureEntity.CreatePlatform(new Vector2(0, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight - 64)));
        scene.Entities.Add(StructureEntity.CreatePlatform(new Vector2(IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth - 32, IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight - 64)));

        scene.Entities.AddRange(StructureEntity.CreateRandomBackground());

        scene.Entities.Add(new UIText("FPS: 0") { OnClick = (state) => Console.WriteLine("bruh") });

        return scene;
    }
}