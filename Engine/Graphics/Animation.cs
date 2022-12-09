using Microsoft.Xna.Framework;

namespace Industrio.Engine;

public class Animation
{
    public string Name { get; set; }
    public SpriteMap SpriteMap { get; set; }
    public int Frame { get; set; } = 0;
    public int[] Frames { get; set; }
    public double FrameTimer { get; set; } = 0;
    public double FrameTime { get; set; }
    public bool Loop { get; set; }
    public bool IsPlaying { get; set; } = true;

    public Animation(string name, SpriteMap spriteMap, int[] frames, double frameTime = 250, bool loop = true)
    {
        Name = name;
        SpriteMap = spriteMap;
        Frames = frames;
        FrameTime = frameTime;
        Loop = loop;
    }

    public int FrameStep(GameTime gameTime)
    {
        if (!IsPlaying) return Frames[Frame];

        FrameTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

        if (FrameTimer >= FrameTime)
        {
            FrameTimer = 0;
            Frame++;

            if (Frame >= Frames.Length)
            {
                if (Loop)
                {
                    Frame = 0;
                }
                else
                {
                    Frame--;
                    IsPlaying = false;
                }
            }
        }
        return Frames[Frame];
    }

    public void Resume()
    {
        IsPlaying = true;
    }

    public void Pause()
    {
        IsPlaying = false;
    }

    public void Reset()
    {
        IsPlaying = true;
        Frame = 0;
    }
}