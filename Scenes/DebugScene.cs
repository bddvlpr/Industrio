using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Scenes;

public class DebugScene : Scene
{
    public DebugScene()
    {
        var testEntity = new Entity("Debug Renderer") { Position = new Vector2(100, 100) };
        var testRenderer = new SpriteRenderer(
            testEntity)
        {
            SpriteMap = SpriteMap.Load("Textures/Character/Idle"),
            FrameDuration = 400f
        };

        Entities.Add(testEntity);
    }
}