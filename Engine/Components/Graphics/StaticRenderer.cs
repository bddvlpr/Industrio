using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class StaticRenderer : Component
{
    public SpriteMap SpriteMap { get; set; }
    public Color Color { get; set; } = Color.White;
    public int Frame { get; set; } = 0;
    public float Depth { get; set; } = 0.9f;

    public StaticRenderer(Entity entity) : base(entity)
    {
        Entity.OnDraw += Draw;
    }

    private void Draw(object sender, DrawEventArgs drawEvent)
    {
        if (SpriteMap == null) return;

        var scale = Entity.Scale * SpriteMap.Scale;
        var effects = SpriteEffects.None;
        if (Entity.FlippedHorizontally) effects |= SpriteEffects.FlipHorizontally;
        if (Entity.FlippedVertically) effects |= SpriteEffects.FlipVertically;

        drawEvent.SpriteBatch.Draw(SpriteMap.Map, Entity.Position, SpriteMap.GetFrame(Frame), Color, 0f, Vector2.Zero, scale, effects, Depth);
    }
}
