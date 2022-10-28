using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class DrawEventArgs : EventArgs
{
    public GameTime GameTime { get; set; }
    public SpriteBatch SpriteBatch { get; set; }

    public DrawEventArgs(GameTime gameTime, SpriteBatch spriteBatch)
    {
        GameTime = gameTime;
        SpriteBatch = spriteBatch;
    }
}