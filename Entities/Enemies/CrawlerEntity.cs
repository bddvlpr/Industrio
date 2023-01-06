using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class CrawlerEntity : Entity
{
    public AnimatedRenderer Renderer { get; set; }
    public ControllableRigidBody RigidBody { get; set; }
    public DynamicCollider Collider { get; set; }
    public DynamicCollider BiteCollider { get; set; }

    public CrawlerEntity()
    {
        Name = "Crawler";

        Renderer = new AnimatedRenderer(this)
        {
            Animation = GetIdleAnimation(),
        };

        RigidBody = new ControllableRigidBody(this);

        RigidBody.MovementController = new LinearMovementController(RigidBody);

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };

        BiteCollider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
            Offset = new Vector2(8, 8),
            IsTrigger = true,
        };

        OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        if (FlippedHorizontally)
        {
            BiteCollider.Offset = new Vector2(-8, 8);
        }
        else
        {
            BiteCollider.Offset = new Vector2(8, 8);
        }
    }

    public static Animation GetIdleAnimation()
    {
        return new Animation("Idle", SpriteMap.Load("Textures/Crawler/Idle"), new int[] { 0, 1, 2, 3, 4, 5 }, 150, true); ;
    }
}