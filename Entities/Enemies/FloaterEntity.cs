using System;
using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class FloaterEntity : Entity
{
    public AnimatedRenderer Renderer { get; set; }
    public ControllableRigidBody RigidBody { get; set; }
    public DynamicCollider Collider { get; set; }

    private float _shotTimer = 0;

    public FloaterEntity()
    {
        Name = "Floater";

        Renderer = new AnimatedRenderer(this)
        {
            Animation = GetIdleAnimation(),
        };

        RigidBody = new ControllableRigidBody(this);

        RigidBody.MovementController = new AirMovementController(RigidBody);
        RigidBody.HasGravity = false;

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };

        OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        _shotTimer += e.GameTime.ElapsedGameTime.Milliseconds;

        if (_shotTimer >= 1000)
        {
            _shotTimer = 0;

            var bullet = new BulletEntity(new Vector2(FlippedHorizontally ? -256 : 256, 0))
            {
                Position = Position + new Vector2(FlippedHorizontally ? -32 : 32, 0),
            };
            IndustrioGame.Instance.Scene.SpawnQueue.Add(bullet);
        }
    }

    public static Animation GetIdleAnimation()
    {
        return new Animation("Idle", SpriteMap.Load("Textures/Floater/Idle"), new int[] { 0, 1, 2, 3 }, 150, true); ;
    }
}