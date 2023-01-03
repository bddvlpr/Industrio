using System;
using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class CollisionEventArgs : EventArgs
{
    public GameTime GameTime { get; set; }
    public DynamicCollider MyCollider { get; set; }
    public DynamicCollider TargetCollider { get; set; }

    public CollisionEventArgs(GameTime gameTime, DynamicCollider myCollider, DynamicCollider targetCollider)
    {
        GameTime = gameTime;
        MyCollider = myCollider;
        TargetCollider = targetCollider;
    }
}