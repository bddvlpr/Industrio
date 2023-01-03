using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class DynamicCollider : Component
{
    public CollisionRectangle Shape { get; set; }
    public bool IsTrigger { get; set; } = false;

    public float Left => Entity.Position.X;
    public float Right => Entity.Position.X + Shape.Size.X;
    public float Top => Entity.Position.Y;
    public float Bottom => Entity.Position.Y + Shape.Size.Y;

    public event EventHandler<CollisionEventArgs> OnCollide;

    public DynamicCollider(Entity entity) : base(entity)
    {
        //Entity.OnDraw += Draw;
    }

    private void Draw(object sender, DrawEventArgs e)
    {
        var texture = new Texture2D(IndustrioGame.Instance.GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.Red });
        e.SpriteBatch.Draw(texture, new Rectangle((int)Left, (int)Top, (int)Shape.Size.X, (int)Shape.Size.Y), Color.White);
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