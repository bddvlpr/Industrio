using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine.UI;

public class UITexture : UIElement
{
    public Texture2D Texture { get; set; }
    public Color Color { get; set; } = Color.White;

    public UITexture(Texture2D texture)
    {
        Texture = texture;
        Name = $"UITexture[{texture.Name}]";

        OnDraw += Draw;
    }

    public override bool IsHovered()
    {
        var mouseState = Mouse.GetState();
        var textureSize = Texture.Bounds.Size.ToVector2();
        return mouseState.X >= Position.X && mouseState.X <= Position.X + textureSize.X &&
               mouseState.Y >= Position.Y && mouseState.Y <= Position.Y + textureSize.Y;
    }

    private void Draw(object sender, DrawEventArgs e)
    {
        e.SpriteBatch.Draw(Texture, Position, null, Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 1f);
    }
}