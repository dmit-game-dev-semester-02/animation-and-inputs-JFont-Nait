using assignment01game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01;

public class Assignment01game : Game
{
    private const int _windowWidth = 1920;
    private const int _windowHeight = 1080;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _background, _tree;
    private CelAnimationSequence _sequence01, _sequence02;
    private CelAnimationPlayer _animation01, _animation02;
    private KeyboardState _kbPreviousState;
    private bool isRight;
    private float _positionX = 0, _positionY = 900;  //???
    private float _speed = 2;
    public Assignment01game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _windowWidth;
        _graphics.PreferredBackBufferHeight = _windowHeight;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _background = Content.Load<Texture2D>("background");
        _tree = Content.Load<Texture2D>("tree");
        Texture2D spriteSheet01 = Content.Load<Texture2D>("businesswalk");
        Texture2D spriteSheet02 = Content.Load<Texture2D>("walking");

        _sequence01 = new CelAnimationSequence(spriteSheet01, 61, 1 / 7f);
        _sequence02 = new CelAnimationSequence(spriteSheet02, 84, 1 / 7f);

        _animation01 = new CelAnimationPlayer();
        _animation02 = new CelAnimationPlayer();

        _animation01.Play(_sequence01);
        _animation02.Play(_sequence02);

        // _positionX = new Vector2(); //???
    }

    protected override void Update(GameTime gameTime)
    {
        // _animation01.Update(gameTime);
        _animation02.Update(gameTime);

        KeyboardState kbCurrentState = Keyboard.GetState();
        // _message = "";

        #region Arrow Keys
        if(kbCurrentState.IsKeyDown(Keys.Up))
        {
            
        }
        if(kbCurrentState.IsKeyDown(Keys.Down))
        {
            
        }
        if(kbCurrentState.IsKeyDown(Keys.Left))
        {
            _positionX += -_speed;  //???
            isRight = false;
            _animation01.Update(gameTime);
        }
        if(kbCurrentState.IsKeyDown(Keys.Right))
        {
            _positionX += _speed;  //???
            isRight = true;
            _animation01.Update(gameTime);
        }
        #endregion

        #region Key Down Event
        if(_kbPreviousState.IsKeyUp(Keys.Space) && kbCurrentState.IsKeyDown(Keys.Space))
        {
            // _message += "-------------------------------\n";
            // _message += "-------------------------------\n";
            // _message += "-------------------------------\n";
            // _message += "-------------------------------\n";
            // _message += "-------------------------------\n";
            // _message += "-------------------------------\n";
        }
        #endregion
      
        #region Key Up Event
        else if(kbCurrentState.IsKeyDown(Keys.Space))
        {
            // _message +=" Space";
        }      
        else if(_kbPreviousState.IsKeyDown(Keys.Space)) 
        {
            //The space key is not being held downright now
            //But, it was being held down on the last call to update()
            //So, this is a "key up" event
            // _message += "###############################\n";
            // _message += "###############################\n";
            // _message += "###############################\n";
        }
        #endregion

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkGreen);
        _spriteBatch.Begin();

        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_tree, new Vector2(1400, 475), Color.White);

        if (isRight == true)
        {
            _animation01.Draw(_spriteBatch, new Vector2(_positionX, _positionY - _sequence01.CelHeight), SpriteEffects.None);
        }
        else
        {
            _animation01.Draw(_spriteBatch, new Vector2(_positionX, _positionY - _sequence01.CelHeight), SpriteEffects.FlipHorizontally);
        }
        
        _animation02.Draw(_spriteBatch, new Vector2(1400, 750 - _sequence02.CelHeight), SpriteEffects.None);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
