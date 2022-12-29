using Industrio.Engine;
using Industrio.Entities;
using Microsoft.Xna.Framework;

namespace Industrio.Scenes;

public static class DebugSceneCreator
{
    public static Scene CreateTestArea()
    {
        var scene = new Scene();

        var player = new PlayerEntity();

        scene.Entities.Add(player);

        var tile = new StructureEntity() { Position = new Vector2(0, 100) };

        scene.Entities.Add(tile);

        return scene;
    }
}