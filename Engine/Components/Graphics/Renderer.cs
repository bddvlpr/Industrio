using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class Renderer : Component
{
    public SpriteMap SpriteMap { get; set; }
    public int Frame { get; set; }

    public Renderer(Entity entity) : base(entity)
    {
        Entity.OnDraw += Draw;
    }

    private void Draw(object sender, DrawEventArgs drawEvent)
    {
        drawEvent.SpriteBatch.Draw(SpriteMap.Map, Entity.Position, SpriteMap.GetFrame(Frame), Color.White, 0f, Vector2.Zero, SpriteMap.Scale, SpriteEffects.None, 0f);
    }
}