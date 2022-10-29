using System;

namespace Industrio.Engine;

public class AnimatedRenderer : StaticRenderer
{
    public Animation Animation { get; set; }

    public AnimatedRenderer(Entity entity) : base(entity)
    {
        Entity.OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        var currentFrame = Animation.FrameStep(e.GameTime);
        if (currentFrame != Frame)
        {
            Frame = currentFrame;
        }
    }
}