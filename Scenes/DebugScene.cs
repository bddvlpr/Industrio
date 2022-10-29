using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Scenes;

public static class DebugSceneCreator
{
    public static Scene CreateTestArea()
    {
        var scene = new Scene();

        var staticPlayer = new Entity("Static Player");
        var staticRenderer = new StaticRenderer(staticPlayer)
        {
            SpriteMap = SpriteMap.Load("Textures/Character/Idle"),
        };

        scene.Entities.Add(staticPlayer);

        var animatedPlayer = new Entity("Animated Player");
        var animatedRenderer = new AnimatedRenderer(animatedPlayer)
        {
            SpriteMap = SpriteMap.Load("Textures/Character/Idle"),
            Animation = new Animation(new int[] { 0, 1, 2 }, 250f),
        };

        animatedPlayer.Position = new Vector2(100, 100);

        scene.Entities.Add(animatedPlayer);

        return scene;
    }
}