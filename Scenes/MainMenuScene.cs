using System;
using Industrio.Engine;
using Industrio.Engine.UI;
using Industrio.Entities;
using Microsoft.Xna.Framework;

namespace Industrio.Scenes;

public class MainMenuScene : Scene
{
    public MainMenuScene()
    {
        var minY = IndustrioGame.Instance.GraphicsDevice.Viewport.Height / 2;

        Entities.AddRange(StructureEntity.CreateRandomBackground());
        Entities.Add(new UIText("Industrio")
        {
            Position = new Vector2(10, minY - 160),
            Scale = new Vector2(4)
        });
        Entities.Add(new UIText("Start game")
        {
            Position = new Vector2(10, minY - 40),
            OnClick = (state) => IndustrioGame.Instance.Scene = new LevelOne()
        });
        Entities.Add(new UIText("Quit")
        {
            Position = new Vector2(10, minY - 20),
            OnClick = (state) => IndustrioGame.Instance.Exit()
        });
    }
}