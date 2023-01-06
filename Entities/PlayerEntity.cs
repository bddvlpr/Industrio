using System;
using Industrio.Engine;
using Industrio.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Entities;

public class PlayerEntity : Entity
{
    public AnimatedRenderer Renderer { get; set; }
    public ControllableRigidBody RigidBody { get; set; }
    public DynamicCollider Collider { get; set; }

    public static int Health { get; set; } = 3;

    private float _invulnerabilityTimer = 0;

    public PlayerEntity()
    {
        Name = "Player";

        Renderer = new AnimatedRenderer(this)
        {
            Animation = GetIdleAnimation(),
        };

        RigidBody = new ControllableRigidBody(this);

        RigidBody.MovementController = new KeyboardMovementController(RigidBody);

        Collider = new DynamicCollider(this)
        {
            Shape = new CollisionRectangle(new Vector2(16, 16)),
        };

        OnUpdate += Update;
        OnDraw += Draw;
        Collider.OnCollide += OnCollide;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        if (RigidBody.Velocity != Vector2.Zero && !Renderer.Animation.Name.Equals("Walking"))
        {
            Renderer.Animation = GetWalkingAnimation();
        }
        if (RigidBody.Velocity == Vector2.Zero && !Renderer.Animation.Name.Equals("Idle"))
        {
            Renderer.Animation = GetIdleAnimation();
        }

        _invulnerabilityTimer = Math.Clamp(_invulnerabilityTimer - e.GameTime.ElapsedGameTime.Milliseconds, 0, 5000);
        if (_invulnerabilityTimer > 0)
        {
            Renderer.Color = new Color(1f, 0.5f, 0.5f, MathF.Abs(MathF.Sin(_invulnerabilityTimer / 100)));
        }
        else Renderer.Color = Color.White;
    }

    private void Draw(object sender, DrawEventArgs e)
    {
        var spriteMap = SpriteMap.Load("Textures/UI/Health");
        for (int i = 0; i < 3; i++)
        {
            e.SpriteBatch.Draw(spriteMap.Map, new Vector2(10 + (i * 16), 10), spriteMap.GetFrame(i < Health ? 0 : 1), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
        }
    }

    private void OnCollide(object sender, CollisionEventArgs e)
    {
        if (e.TargetCollider.Entity.Name.Equals("Bullet") || e.TargetCollider.Entity.Name.Equals("Crawler"))
        {
            if (_invulnerabilityTimer > 0) return;

            if (Health > 1)
            {
                Health--;
                _invulnerabilityTimer = 2500;
                IndustrioGame.Instance.HitSound.Play();
            }
            else
            {
                IndustrioGame.Instance.Scene = new GameOverScene();
            }
        }
    }

    public static Animation GetIdleAnimation()
    {
        return new Animation("Idle", SpriteMap.Load("Textures/Character/Idle"), new int[] { 0, 1, 2 }, 250, true); ;
    }

    public static Animation GetWalkingAnimation()
    {
        return new Animation("Walking", SpriteMap.Load("Textures/Character/Walk"), new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 100, true);
    }
}