using System;
using Industrio.Engine;
using Industrio.Engine.UI;
using Industrio.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Industrio.Scenes;

public class GameOverScene : Scene
{
    public GameOverScene()
    {
        var minY = IndustrioGame.Instance.GraphicsDevice.Viewport.Height / 2;

        Entities.AddRange(StructureEntity.CreateRandomBackground());
        Entities.Add(new UIText("GAME OVER")
        {
            Position = new Vector2(10, minY - 160),
            Scale = new Vector2(4)
        });
        Entities.Add(new UIText("Go to main menu")
        {
            Position = new Vector2(10, minY - 40),
            OnClick = (state) => IndustrioGame.Instance.Scene = new MainMenuScene()
        });
        Entities.Add(new UIText("Quit")
        {
            Position = new Vector2(10, minY - 20),
            OnClick = (state) => IndustrioGame.Instance.Exit()
        });

        IndustrioGame.Instance.GameOverSound.Play();
    }
}