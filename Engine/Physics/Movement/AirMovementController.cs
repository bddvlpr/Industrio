using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine;

public class AirMovementController : MovementController
{
    public bool DirectionSwitched { get; set; } = false;

    public AirMovementController(ControllableRigidBody rigidBody) : base(rigidBody)
    {
    }

    public override Vector2 Update(GameTime gameTime)
    {
        var playerEntity = IndustrioGame.Instance.Scene.Entities.Find(e => e.Name == "Player");

        if (playerEntity == null) return Vector2.Zero;

        var floaterToPlayer = playerEntity.Position - RigidBody.Entity.Position;
        floaterToPlayer = Vector2.Clamp(floaterToPlayer, new Vector2(-100, -100), new Vector2(100, 100));

        return floaterToPlayer;
    }
}