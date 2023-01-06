using Industrio.Engine;
using Industrio.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Industrio;

public class IndustrioGame : Game
{
    public static IndustrioGame Instance { get; private set; }

    public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
    public SpriteBatch SpriteBatch { get; set; }
    public Scene Scene { get; set; }
    public SpriteFont Font { get; private set; }
    public SoundEffect RobotDeathSound { get; private set; }
    public SoundEffect GameOverSound { get; private set; }
    public SoundEffect JumpSound { get; private set; }
    public SoundEffect HitSound { get; private set; }

    public IndustrioGame()
    {
        Instance = this;
        GraphicsDeviceManager = new GraphicsDeviceManager(this);
        //GraphicsDeviceManager.IsFullScreen = true;
        GraphicsDeviceManager.PreferredBackBufferWidth = 960;
        GraphicsDeviceManager.PreferredBackBufferHeight = 540;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        Font = Content.Load<SpriteFont>("Fonts/04b03");
        RobotDeathSound = Content.Load<SoundEffect>("Sounds/RobotDeath");
        GameOverSound = Content.Load<SoundEffect>("Sounds/GameOver");
        JumpSound = Content.Load<SoundEffect>("Sounds/Jump");
        HitSound = Content.Load<SoundEffect>("Sounds/Hit");
        Scene = new MainMenuScene();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Scene.PollUpdate(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(29, 33, 45));

        SpriteBatch.Begin(SpriteSortMode.FrontToBack,
            BlendState.AlphaBlend,
            SamplerState.PointClamp);
        Scene.PollDraw(gameTime, SpriteBatch);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
