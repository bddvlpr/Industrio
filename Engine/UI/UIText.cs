using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine.UI;

public class UIText : UIElement
{
    public string Text { get; set; }
    public Color Color { get; set; } = Color.White;

    public UIText(string text)
    {
        Text = text;
        Name = $"UIText[{text}]";

        OnDraw += Draw;
    }

    public override bool IsHovered()
    {
        var mouseState = Mouse.GetState();
        var textSize = IndustrioGame.Instance.Font.MeasureString(Name);
        return mouseState.X >= Position.X && mouseState.X <= Position.X + textSize.X &&
               mouseState.Y >= Position.Y && mouseState.Y <= Position.Y + textSize.Y;
    }

    private void Draw(object sender, DrawEventArgs e)
    {
        var targetColor = Color;
        if (IsHovered())
        {
            targetColor = Color.Yellow;
        }

        e.SpriteBatch.DrawString(IndustrioGame.Instance.Font, Text, Position, targetColor, 0, Vector2.Zero, Scale, SpriteEffects.None, 1f);
    }
}