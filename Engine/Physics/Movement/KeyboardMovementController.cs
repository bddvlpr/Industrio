using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine;

public class KeyboardMovementController : MovementController
{
    public KeyboardMovementController(ControllableRigidBody rigidBody) : base(rigidBody)
    {
    }

    public override Vector2 Update(GameTime gameTime)
    {
        var state = Keyboard.GetState();

        var velocity = Vector2.Zero;
        if (state.IsKeyDown(Keys.Left)) velocity.X -= 1;
        if (state.IsKeyDown(Keys.Right)) velocity.X += 1;
        if (state.IsKeyDown(Keys.Up)) velocity.Y -= 1;
        if (state.IsKeyDown(Keys.Down)) velocity.Y += 1;

        return velocity * RigidBody.MaxSpeed;
    }
}