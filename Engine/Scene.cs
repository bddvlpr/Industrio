using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class Scene
{
    public List<Entity> Entities { get; set; }

    public Scene()
    {
        Entities = new List<Entity>();
    }

    public void PollUpdate(GameTime gameTime)
    {
        Entities.ForEach(entity => entity.InvokeUpdate(gameTime));
    }

    public void PollDraw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Entities.ForEach(entity => entity.InvokeDraw(gameTime, spriteBatch));
    }
}