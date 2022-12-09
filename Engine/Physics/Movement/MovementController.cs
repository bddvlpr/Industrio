using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public abstract class MovementController
{
    public ControllableRigidBody RigidBody { get; set; }

    public MovementController(ControllableRigidBody rigidBody)
    {
        RigidBody = rigidBody;
    }

    public abstract Vector2 Update(GameTime gameTime);
}