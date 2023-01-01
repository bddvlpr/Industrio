using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine;

public class LinearMovementController : MovementController
{
    public bool DirectionSwitched { get; set; } = false;

    public LinearMovementController(ControllableRigidBody rigidBody) : base(rigidBody)
    {
    }

    public override Vector2 Update(GameTime gameTime)
    {
        var colliderEntities = IndustrioGame.Instance.Scene.Entities.FindAll(e => e.HasComponent<DynamicCollider>());

        foreach (var colliderEntity in colliderEntities)
        {
            if (colliderEntity == RigidBody.Entity) continue;

            var collider = colliderEntity.GetComponent<DynamicCollider>();

            if (RigidBody.GetNextRectangle(
                new Vector2(DirectionSwitched ? 1 : -1, 0)
            ).Intersects(collider.GetRectangle()))
            {
                DirectionSwitched = !DirectionSwitched;
            }
        }

        return new Vector2(DirectionSwitched ? 100 : -100, 0);
    }
}