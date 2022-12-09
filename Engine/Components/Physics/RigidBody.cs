using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class RigidBody : Component
{
    public Vector2 Velocity { get; set; }
    public float AirTime { get; set; } = 0;

    public RigidBody(Entity entity) : base(entity)
    {
        Entity.OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        float deltaTime = e.GameTime.ElapsedGameTime.Milliseconds / 1000f;
        var gravityMulitplier = ApplyGravity(deltaTime);
        var velocityMultiplier = ApplyVelocity(deltaTime);
        var newPosition = Entity.Position + gravityMulitplier + velocityMultiplier;

        Entity.Position = ProcessCollision(newPosition);
    }

    public Vector2 ApplyGravity(float delta)
    {
        return new Vector2(0, 0.2f * delta);
    }

    public Vector2 ApplyVelocity(float delta)
    {

        if (Math.Abs(Velocity.X) > 0.01f)
            Entity.FlippedHorizontally = Velocity.X < 0;

        return Velocity * delta;
    }

    public Vector2 ProcessCollision(Vector2 newPosition)
    {
        var myCollider = Entity.GetComponent<DynamicCollider>();

        if (myCollider == null)
        {
            Debug.WriteLine("RigidBody has no collider");
            return newPosition;
        }

        var myBoundingBox = new Rectangle(
            (int)Entity.Position.X,
            (int)Entity.Position.Y,
            (int)(Entity.Position.X + myCollider.Shape.Size.X),
            (int)(Entity.Position.Y + myCollider.Shape.Size.Y)
        );

        var colliders = IndustrioGame.Instance.Scene.Entities
            .FindAll(e => e != Entity && e.GetComponent<DynamicCollider>() != null);

        foreach (var entity in colliders)
        {
            if (entity == Entity) continue;

            var otherCollider = entity.GetComponent<DynamicCollider>();
            var otherBoundingBox = new Rectangle(
                (int)entity.Position.X,
                (int)entity.Position.Y,
                (int)(entity.Position.X + otherCollider.Shape.Size.X),
                (int)(entity.Position.Y + otherCollider.Shape.Size.Y)
            );

            if (myBoundingBox.Intersects(otherBoundingBox))
            {
                Velocity = Vector2.Zero;
                return Entity.Position;
            }
        }
        return newPosition;
    }
}