using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Entities;

public class PortalEntity : Entity
{
    public Action Action { get; set; }
    public StaticRenderer Renderer { get; set; }
    public DynamicCollider Collider { get; set; }

    public PortalEntity(Action action)
    {
        Name = $"Portal";
        Action = action;

        Renderer = new StaticRenderer(this)
        {
            SpriteMap = SpriteMap.Load("Textures/Tile/Portal"),
            Frame = 0,
            Depth = 0.5f,
        };

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
            IsTrigger = true,
        };

        Collider.OnCollide += Collide;
    }

    private void Collide(object sender, CollisionEventArgs e)
    {
        var keyState = Keyboard.GetState();

        if (e.TargetCollider.Entity is PlayerEntity)
        {
            Console.WriteLine($"Portal {Name} was activated!");
            if (keyState.IsKeyDown(Keys.Down))
                Action();
        }
    }
}