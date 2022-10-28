using System;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class UpdateEventArgs : EventArgs
{
    public GameTime GameTime { get; set; }

    public UpdateEventArgs(GameTime gameTime)
    {
        GameTime = gameTime;
    }
}