using Industrio.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Industrio.Entities;

public abstract class DestroyableEnemyEntity : Entity
{
    public DynamicCollider DeathCollider { get; set; }

    public DestroyableEnemyEntity()
    {
        DeathCollider = new DynamicCollider(this)
        {
            Offset = new Vector2(0, -1),
            Shape = new CollisionRectangle(new Vector2(16, 16)),
            IsTrigger = true
        };

        DeathCollider.OnCollide += OnCollide;
    }

    private void OnCollide(object sender, CollisionEventArgs e)
    {
        if (e.TargetCollider.Entity is PlayerEntity)
        {
            var player = e.TargetCollider.Entity as PlayerEntity;
            IndustrioGame.Instance.RobotDeathSound.Play();
            IndustrioGame.Instance.Scene.DeletionQueue.Add(this);
            player.RigidBody.AirTime = -8;
            player.RigidBody.IsGrounded = false;
        }
    }
}