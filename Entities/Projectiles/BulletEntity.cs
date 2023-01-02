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

        RigidBody = new ControllableRigidBody(this);

        RigidBody.MovementController = new BulletMovementController(RigidBody) { Direction = direction };
        RigidBody.HasGravity = false;


        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };

        OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        var colliderEntities = IndustrioGame.Instance.Scene.Entities.FindAll(e => e.HasComponent<DynamicCollider>());

        foreach (var colliderEntity in colliderEntities)
        {
            if (colliderEntity == this)
                continue;

            // TODO: kill
            //if (RigidBody.GetNextRectangle(RigidBody.Velocity).Intersects(colliderEntity.GetComponent<DynamicCollider>().GetRectangle()))
            //    IndustrioGame.Instance.Scene.DeletionQueue.Add(this);
        }
    }

    public static Animation GetIdleAnimation()
    {
        return new Animation("Idle", SpriteMap.Load("Textures/Bullet/Idle"), new int[] { 0, 1 }, 150, true); ;
    }
}