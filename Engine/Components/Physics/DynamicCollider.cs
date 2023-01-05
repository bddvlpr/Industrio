using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class DynamicCollider : Component
{
    public CollisionRectangle Shape { get; set; }

    public Vector2 Offset { get; set; } = Vector2.Zero;
    public bool IsTrigger { get; set; } = false;

    public float Left => Offset.X + Entity.Position.X;
    public float Right => Offset.X + Entity.Position.X + Shape.Size.X;
    public float Top => Offset.Y + Entity.Position.Y;
    public float Bottom => Offset.Y + Entity.Position.Y + Shape.Size.Y;

    public event EventHandler<CollisionEventArgs> OnCollide;

    public DynamicCollider(Entity entity) : base(entity)
    {
        Entity.OnUpdate += Update;
        Entity.OnDraw += Draw;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        var colliderEntities = IndustrioGame.Instance.Scene.Entities.FindAll(e => e.HasComponent<DynamicCollider>());

        foreach (var colliderEntity in colliderEntities)
        {
            if (colliderEntity == Entity) continue;

            var colliders = colliderEntity.GetComponents<DynamicCollider>();

            foreach (var collider in colliders)
            {
                if (Intersects(collider))
                {
                    OnCollide?.Invoke(this, new CollisionEventArgs(e.GameTime, this, colliderEntity.GetComponent<DynamicCollider>()));
                }
            }
        }
    }

    private void Draw(object sender, DrawEventArgs e)
    {
        var texture = new Texture2D(IndustrioGame.Instance.GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.Red });
        e.SpriteBatch.Draw(texture, GetRectangle(), Color.White);
    }

    public Rectangle GetRectangle()
    {
        return new Rectangle((int)Left, (int)Top, (int)Shape.Size.X, (int)Shape.Size.Y);
    }

    public bool Intersects(DynamicCollider other)
    {
        return GetRectangle().Intersects(other.GetRectangle());
    }

    public bool Intersects(Rectangle other)
    {
        return GetRectangle().Intersects(other);
    }
}