using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Scenes;

public class DebugScene : Scene
{
    public DebugScene()
    {
        var testEntity = new Entity("Debug Renderer") { Position = new Vector2(100, 100) };
        var testRenderer = new SpriteRenderer(testEntity)
        {
            SpriteMap = SpriteMap.Load("Textures/Character/Idle"),
            FrameDuration = 400f
        };

        for (var i = 0; i < 100; i++)
        {
            var tileEntity = new Entity($"Tile {i}")
            {
                Position = new Vector2(i * SpriteMap.TileSize, 200)
            };
            var tileCollider = new Collider(tileEntity);
            var tileRenderer = new SpriteRenderer(tileEntity)
            {
                SpriteMap = SpriteMap.Load("Textures/Tile/Structure"),
                Frame = new Random().Next(1, 2)
            };

            Entities.Add(tileEntity);
        }

        Entities.Add(testEntity);
    }
}