using System;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class RigidBody : Component
{
    public Vector2 Velocity { get; set; } = Vector2.Zero;
    public float AirTime { get; set; } = 0;
    public bool IsGrounded { get; set; } = false;

    public RigidBody(Entity entity) : base(entity)
    {
        Entity.OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        float deltaTime = e.GameTime.ElapsedGameTime.Milliseconds / 1000f;
        ApplyGravity(deltaTime);
        ApplyCollision(deltaTime);
        ApplyVelocity(deltaTime);
    }

    public void ApplyGravity(float delta)
    {
        // Increase velocity the longer the player is in the air
        if (!IsGrounded)
            AirTime += delta;
        else AirTime = 0;
        Velocity += new Vector2(0, 981f * AirTime * delta);
    }

    public void ApplyCollision(float delta)
    {
        var myCollider = Entity.GetComponent<DynamicCollider>();

        if (myCollider == null)
        {
            Console.WriteLine("No collider found on rigid body. Collision will not be applied.");
            return;
        }

        var colliderEntities = IndustrioGame.Instance.Scene.Entities.FindAll(e => e.HasComponent<DynamicCollider>());

        foreach (var colliderEntity in colliderEntities)
        {
            var otherCollider = colliderEntity.GetComponent<DynamicCollider>();

            if (otherCollider == Entity.GetComponent<DynamicCollider>())
                continue;

            var myColliderRect = myCollider.GetRectangle();
            var otherColliderRect = otherCollider.GetRectangle();

            if (GetNextRectangle().Intersects(otherColliderRect))
            {
                var myColliderCenter = new Vector2(myColliderRect.X + myColliderRect.Width / 2, myColliderRect.Y + myColliderRect.Height / 2);
                var otherColliderCenter = new Vector2(otherColliderRect.X + otherColliderRect.Width / 2, otherColliderRect.Y + otherColliderRect.Height / 2);

                var distance = Vector2.Distance(myColliderCenter, otherColliderCenter);

                var myColliderSize = new Vector2(myColliderRect.Width / 2, myColliderRect.Height / 2);
                var otherColliderSize = new Vector2(otherColliderRect.Width / 2, otherColliderRect.Height / 2);

                var overlap = myColliderSize + otherColliderSize - new Vector2(Math.Abs(myColliderCenter.X - otherColliderCenter.X), Math.Abs(myColliderCenter.Y - otherColliderCenter.Y));

                if (Math.Abs(overlap.X) > Math.Abs(overlap.Y))
                {
                    if (myColliderCenter.Y < otherColliderCenter.Y)
                        Entity.Position += new Vector2(0, overlap.Y);
                    else
                        Entity.Position -= new Vector2(0, overlap.Y);
                    Velocity = new Vector2(Velocity.X, 0);
                }
                else
                {
                    if (myColliderCenter.X < otherColliderCenter.X)
                        Entity.Position += new Vector2(overlap.X, 0);
                    else
                        Entity.Position -= new Vector2(overlap.X, 0);
                    Velocity = new Vector2(0, Velocity.Y);
                }

                // check if grounded
                if (myColliderCenter.Y < otherColliderCenter.Y)
                {
                    IsGrounded = true;
                    AirTime = 0;
                }
            }
        }
    }

    public void ApplyVelocity(float delta)
    {
        if (Math.Abs(Velocity.X) > 0.01f)
            Entity.FlippedHorizontally = Velocity.X < 0;
        Entity.Position += Velocity;
        Velocity = Vector2.Zero;
    }

    public Rectangle GetNextRectangle()
    {
        return new Rectangle((int)(Entity.Position.X + Velocity.X), (int)(Entity.Position.Y + Velocity.Y), (int)Entity.GetComponent<DynamicCollider>().Shape.Size.X, (int)Entity.GetComponent<DynamicCollider>().Shape.Size.Y);
    }
}