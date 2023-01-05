using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class BulletEntity : Entity
{
    public AnimatedRenderer Renderer { get; set; }
    public ControllableRigidBody RigidBody { get; set; }
    public DynamicCollider Collider { get; set; }

    public BulletEntity(Vector2 direction)
    {
        Name = "Bullet";

        Renderer = new AnimatedRenderer(this)
        {
            Animation = GetIdleAnimation(),
        };

        RigidBody = new ControllableRigidBody(this)
        {
            HasGravity = false,
            HasPhysics = false,
        };
        RigidBody.MovementController = new BulletMovementController(RigidBody) { Direction = direction };

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(8, 8)),
            Offset = new Vector2(8, 8),
            IsTrigger = true,
        };
    }

    public static Animation GetIdleAnimation()
    {
        return new Animation("Idle", SpriteMap.Load("Textures/Bullet/Idle"), new int[] { 0, 1 }, 150, true); ;
    }
}