using Industrio.Engine;
using Industrio.Engine.UI;
using Industrio.Entities;
using Microsoft.Xna.Framework;

namespace Industrio.Scenes;

public class GameWonScene : Scene
{
    public GameWonScene()
    {
        var minY = IndustrioGame.Instance.GraphicsDevice.Viewport.Height / 2;

        Entities.AddRange(StructureEntity.CreateRandomBackground());
        Entities.Add(new UIText("You won!")
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
    }
}