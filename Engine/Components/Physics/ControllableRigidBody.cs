using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class ControllableRigidBody : RigidBody
{
    public float MaxSpeed { get; set; } = 6000f;
    public float Acceleration { get; set; } = 0.02f;
    public MovementController MovementController { get; set; }

    public ControllableRigidBody(Entity entity) : base(entity)
    {
        Entity.OnUpdate += Update;
        //Entity.OnDraw += Draw;
    }

    private void Draw(object sender, DrawEventArgs e)
    {
        var startDrawPoint = Entity.Position + new Vector2(64, 0);
        var spriteFont = Industrio.IndustrioGame.Instance.Content.Load<SpriteFont>("Fonts/04b03");
        e.SpriteBatch.DrawString(spriteFont, $"Name: {Entity.Name}", startDrawPoint, Color.White);
        e.SpriteBatch.DrawString(spriteFont, $"Velocity: {Velocity}", startDrawPoint + new Vector2(0, 16), Color.White);
        e.SpriteBatch.DrawString(spriteFont, $"Position: {Entity.Position}", startDrawPoint + new Vector2(0, 32), Color.White);
        e.SpriteBatch.DrawString(spriteFont, $"MaxSpeed: {MaxSpeed}", startDrawPoint + new Vector2(0, 48), Color.White);
        e.SpriteBatch.DrawString(spriteFont, $"Grounded: {IsGrounded}", startDrawPoint + new Vector2(0, 64), Color.White);
        e.SpriteBatch.DrawString(spriteFont, $"AirTime: {AirTime}", startDrawPoint + new Vector2(0, 80), Color.White);
        e.SpriteBatch.DrawString(spriteFont, $"HasPhysics: {HasPhysics}", startDrawPoint + new Vector2(0, 96), Color.White);
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        var velocity = MovementController?.Update(e.GameTime);

        if (MovementController.GetType().Equals(typeof(KeyboardMovementController)))
        {
            var keyboardMovementController = (KeyboardMovementController)MovementController;
            if (keyboardMovementController.IsJumping() && IsGrounded)
            {
                Velocity = new Vector2(Velocity.X, -10) + Velocity;
                AirTime = -25;
                IsGrounded = false;
            }
        }

        if (velocity != null)
        {
            if (IsGrounded)
                Velocity = Vector2.Min(velocity.Value * Acceleration, new Vector2(MaxSpeed, MaxSpeed));
            else Velocity = Vector2.Min(velocity.Value * Acceleration, new Vector2(MaxSpeed, MaxSpeed)) + Velocity;
        }
    }
}