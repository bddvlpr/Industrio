using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine
{
    public class SpriteRenderer : Component
    {
        public SpriteMap SpriteMap { get; set; }
        public int Frame { get; set; }
        public float FrameDuration { get; set; } = float.PositiveInfinity;
        public double LastFrameTime { get; set; }

        public SpriteRenderer(Entity entity) : base(entity)
        {
            Entity.OnUpdate += Update;
            Entity.OnDraw += Draw;
        }

        private void Update(object sender, UpdateEventArgs updateEvent)
        {
            if (LastFrameTime + FrameDuration >= updateEvent.GameTime.TotalGameTime.TotalMilliseconds)
                return;

            LastFrameTime = updateEvent.GameTime.TotalGameTime.TotalMilliseconds;
            Frame++;

            if (Frame >= SpriteMap.Frames)
            {
                Frame = 0;
            }
        }

        private void Draw(object sender, DrawEventArgs drawEvent)
        {
            drawEvent.SpriteBatch.Draw(
                SpriteMap.Map,
                 Entity.Position, SpriteMap.GetFrame(Frame), Color.White, 0f, Vector2.Zero, SpriteMap.Scale, SpriteEffects.None, 0f);
        }
    }
}