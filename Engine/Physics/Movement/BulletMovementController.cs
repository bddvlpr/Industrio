using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine;

public class BulletMovementController : MovementController
{
    public Vector2 Direction { get; set; } = Vector2.Zero;

    public BulletMovementController(ControllableRigidBody rigidBody) : base(rigidBody)
    {
    }

    public override Vector2 Update(GameTime gameTime)
    {
        return Direction;
    }
}