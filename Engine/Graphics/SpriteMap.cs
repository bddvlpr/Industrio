using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class SpriteMap
{
    public static float Scale { get; } = 2f;

    public Texture2D Map { get; set; }
    public int Frames { get { return Map.Width / 16; } }

    public SpriteMap(Texture2D map)
    {
        Map = map;
    }

    public Rectangle GetFrame(int frame)
    {
        return new Rectangle(frame * 16, 0, 16, 16);
    }

    public static SpriteMap Load(string path)
    {
        return new SpriteMap(IndustrioGame.Instance.Content.Load<Texture2D>(path));
    }
}