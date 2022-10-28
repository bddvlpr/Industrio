using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class Collider : Component
{
    public Rectangle Bounds { get; set; }

    public Collider(Entity entity) : base(entity)
    {
        Bounds = new Rectangle(0, 0, (int)SpriteMap.TileSize, (int)SpriteMap.TileSize);
    }

    public bool CollidesWith(Collider other)
    {
        return Bounds.Intersects(other.Bounds);
    }
}