using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Industrio.Engine;

public class Scene
{
    public List<Entity> Entities { get; init; } = new List<Entity>();
    public List<Entity> SpawnQueue { get; init; } = new List<Entity>();
    public List<Entity> DeletionQueue { get; init; } = new List<Entity>();

    public void PollUpdate(GameTime gameTime)
    {
        foreach (var entity in SpawnQueue)
        {
            Entities.Add(entity);
        }
        SpawnQueue.Clear();

        Entities.ForEach(entity => entity.InvokeUpdate(gameTime));

        foreach (var entity in DeletionQueue)
        {
            Entities.Remove(entity);
        }
        DeletionQueue.Clear();
    }

    public void PollDraw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Entities.ForEach(entity => entity.InvokeDraw(gameTime, spriteBatch));
    }
}