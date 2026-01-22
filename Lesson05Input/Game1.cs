using System.Numerics;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson05Input;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private SpriteFont _font;

    private string _message = "";

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _kbPreviousState = Keyboard.GetState();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        _kbPreviousState = Keyboard.GetState();

        if(_kbCurrentState.IsKeyDown(Keys.Up))
        {
            _message += "Up ";
        }

        if(_kbCurrentState.IsKeyDown(Keys.Down))
        {
            _message += "Down ";
        }

        if(_kbCurrentState.IsKeyDown(Keys.Left))
        {
            _message += "Left ";
        }

        if(_kbCurrentState.IsKeyDown(Keys.Right))
        {
            _message += "Right ";
        }
        
        _kbPreviousState = _kbCurrentState;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.DrawString(_font, _message, Vector2.Zero)

        base.Draw(gameTime);
    }
}
