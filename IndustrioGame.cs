using Industrio.Engine;
using Industrio.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Industrio;

public class IndustrioGame : Game
{
    public static IndustrioGame Instance { get; private set; }

    public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
    public SpriteBatch SpriteBatch { get; set; }
    public Scene Scene { get; set; }

    public IndustrioGame()
    {
        Instance = this;
        GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        base.Initialize();
        Scene = new DebugScene();
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
        GraphicsDevice.Clear(Color.Purple);

        SpriteBatch.Begin(SpriteSortMode.Deferred,
            BlendState.AlphaBlend,
            SamplerState.PointClamp,
            DepthStencilState.None,
            RasterizerState.CullNone);
        Scene.PollDraw(gameTime, SpriteBatch);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
