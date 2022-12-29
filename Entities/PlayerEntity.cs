using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class PlayerEntity : Entity
{
    public AnimatedRenderer Renderer { get; set; }
    public ControllableRigidBody RigidBody { get; set; }
    public DynamicCollider Collider { get; set; }

    public PlayerEntity()
    {
        Name = "Player";

        Renderer = new AnimatedRenderer(this)
        {
            Animation = GetIdleAnimation(),
        };

        RigidBody = new ControllableRigidBody(this);

        RigidBody.MovementController = new KeyboardMovementController(RigidBody);

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };

        OnUpdate += UpdateAnimationVisual;
    }

    private void UpdateAnimationVisual(object sender, UpdateEventArgs e)
    {
        if (RigidBody.Velocity != Vector2.Zero && !Renderer.Animation.Name.Equals("Walking"))
        {
            Renderer.Animation = GetWalkingAnimation();
        }
        if (RigidBody.Velocity == Vector2.Zero && !Renderer.Animation.Name.Equals("Idle"))
        {
            Renderer.Animation = GetIdleAnimation();
        }
    }

    public static Animation GetIdleAnimation()
    {
        return new Animation("Idle", SpriteMap.Load("Textures/Character/Idle"), new int[] { 0, 1, 2 }, 250, true); ;
    }

    public static Animation GetWalkingAnimation()
    {
        return new Animation("Walking", SpriteMap.Load("Textures/Character/Walk"), new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 100, true);
    }
}