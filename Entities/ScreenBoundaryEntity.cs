using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class ScreenBoundaryEntity : Entity
{
    public DynamicCollider ColliderLeft { get; set; }
    public DynamicCollider ColliderRight { get; set; }
    public DynamicCollider ColliderTop { get; set; }
    public DynamicCollider ColliderBottom { get; set; }

    public ScreenBoundaryEntity()
    {
        var width = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferWidth;
        var height = IndustrioGame.Instance.GraphicsDeviceManager.PreferredBackBufferHeight;

        ColliderLeft = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(0, height)),
        };

        ColliderTop = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(width, 0)),
        };

        ColliderRight = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(0, height)),
            Offset = new Vector2(width, 0)
        };

        ColliderBottom = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(width, 0)),
            Offset = new Vector2(0, height)
        };
    }
}