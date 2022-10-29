using Industrio.Engine;

namespace Industrio.Scenes;

public static class DebugSceneCreator
{
    public static Scene CreateTestArea()
    {
        var scene = new Scene();

        var playerEntity = new Entity("Player");
        var playerRenderer = new Renderer(playerEntity)
        {
            SpriteMap = SpriteMap.Load("Textures/Character/Idle"),
            FrameDuration = 250,
        };
        playerEntity.Components.Add(playerRenderer);
        scene.Entities.Add(playerEntity);

        return scene;
    }
}