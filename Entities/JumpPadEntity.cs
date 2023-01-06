using Industrio.Engine;
using Microsoft.Xna.Framework;

namespace Industrio.Entities;

public class JumpPadEntity : Entity
{
    public StaticRenderer Renderer { get; set; }
    public DynamicCollider Collider { get; set; }
    public DynamicCollider JumpCollider { get; set; }

    public JumpPadEntity()
    {
        Renderer = new StaticRenderer(this)
        {
            SpriteMap = SpriteMap.Load("Textures/Tile/JumpPad"),
            Frame = 0,
        };

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };

        JumpCollider = new DynamicCollider(this)
        {
            Offset = new Vector2(0, -8),
            Shape = new CollisionRectangle(new Vector2(16, 16)),
            IsTrigger = true,
        };
        JumpCollider.OnCollide += Collide;
    }

    private void Collide(object sender, CollisionEventArgs e)
    {
        if (e.TargetCollider.Entity is PlayerEntity)
        {
            var player = e.TargetCollider.Entity as PlayerEntity;
            player.RigidBody.IsGrounded = false;
            player.RigidBody.AirTime = -50;
        }
    }
}