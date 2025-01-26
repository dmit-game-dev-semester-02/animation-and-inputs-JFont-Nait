using assignment01game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01;

//Instructions:
//Space to burn the tree.
//Arrow Keys to make Imperfect Cell walk around.
//WASD Keys to makke somedude walk around (Wanted to see how long I could get another animation working after getting everything set up and working, about 10ish mins)

public class Assignment01game : Game
{
    #region Fields
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background, _tree, _walkingSheet, _fireSheet, _dudeSheet;

    private CelAnimationSequenceMultiRow _fireSequence, _walkingSequence, _dudeSequence;
    private CelAnimationPlayerMultiRow _firePlayer, _walkingPlayer, _dudePlayer;

    private Vector2 _walkingPlayerPosition, _dudePlayerPosition;
    private float _speed = 5;
    #endregion
    public Assignment01game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _background = Content.Load<Texture2D>("background");
        _tree = Content.Load<Texture2D>("tree");
        _fireSheet = Content.Load<Texture2D>("Fire");
        _walkingSheet = Content.Load<Texture2D>("walking");
        _dudeSheet = Content.Load<Texture2D>("somedude");

        _walkingPlayerPosition = new Vector2(0, 900);
        _walkingSequence = new CelAnimationSequenceMultiRow(_walkingSheet, 108, 102, 1 / 8f);
        _walkingPlayer = new CelAnimationPlayerMultiRow();
        _walkingPlayer.Play(_walkingSequence, 0);

        _dudePlayerPosition = new Vector2(1800, 875);
        _dudeSequence = new CelAnimationSequenceMultiRow(_dudeSheet, 95, 158, 1 / 12f);
        _dudePlayer = new CelAnimationPlayerMultiRow();
        _dudePlayer.Play(_dudeSequence, 0);

        _fireSequence = new CelAnimationSequenceMultiRow(_fireSheet, 87, 250, 1 / 8f);
        _firePlayer = new CelAnimationPlayerMultiRow();
        _firePlayer.Play(_fireSequence, 0);      

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        #region Walking Movement
        if (keyboardState.IsKeyDown(Keys.Up))
        {
            _walkingPlayerPosition.Y -= _speed;
        }
        if (keyboardState.IsKeyDown(Keys.Down))
        {
            _walkingPlayerPosition.Y += _speed;
        }
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            _walkingPlayerPosition.X -= _speed;
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            _walkingPlayerPosition.X += _speed;
        }
        _walkingPlayer.HandlePlayerInput(keyboardState);
        _walkingPlayer.Update(gameTime);
        #endregion

        #region SomeDudeMovement
        if (keyboardState.IsKeyDown(Keys.W))
        {
            _dudePlayerPosition.Y -= _speed;
        }
        if (keyboardState.IsKeyDown(Keys.S))
        {
            _dudePlayerPosition.Y += _speed;
        }
        if (keyboardState.IsKeyDown(Keys.A))
        {
            _dudePlayerPosition.X -= _speed;
        }
        if (keyboardState.IsKeyDown(Keys.D))
        {
            _dudePlayerPosition.X += _speed;
        }
        _dudePlayer.HandleDudeInput(keyboardState);
        _dudePlayer.Update(gameTime);
        #endregion

        _firePlayer.HandleFireInput(keyboardState);
        _firePlayer.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkGreen);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, new Rectangle(0, 0, 1920, 1080), Color.White);
        _spriteBatch.Draw(_tree, new Vector2(1400, 475), Color.White);
        _firePlayer.Draw(_spriteBatch, new Vector2(1535, 325), SpriteEffects.None);
        _firePlayer.Draw(_spriteBatch, new Vector2(1625, 450), SpriteEffects.None);
        _firePlayer.Draw(_spriteBatch, new Vector2(1425, 425), SpriteEffects.None);
        _firePlayer.Draw(_spriteBatch, new Vector2(1500, 525), SpriteEffects.None);
        _firePlayer.Draw(_spriteBatch, new Vector2(1535, 700), SpriteEffects.None);
        _walkingPlayer.Draw(_spriteBatch, _walkingPlayerPosition, SpriteEffects.None);
        _dudePlayer.Draw(_spriteBatch, _dudePlayerPosition, SpriteEffects.None);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}