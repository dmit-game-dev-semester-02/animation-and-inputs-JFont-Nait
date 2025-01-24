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
    private bool isUp;
    private float _positionX = 0, _positionY = 900;  //???
    private float _speed = 2;
    private Texture2D spriteSheet01, spriteSheet02;
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
        spriteSheet01 = Content.Load<Texture2D>("walking");
        spriteSheet02 = Content.Load<Texture2D>("businesswalk");
        // Texture2D spriteSheet01 = Content.Load<Texture2D>("walking");
        // Texture2D spriteSheet02 = Content.Load<Texture2D>("businesswalk");

        _sequence01 = new CelAnimationSequence(spriteSheet01,108, 102, 1 / 7f, 0);
        _sequence02 = new CelAnimationSequence(spriteSheet02, 61, 120, 1 / 7f, 0);

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

        #region Arrow Keys
        if(kbCurrentState.IsKeyDown(Keys.Up))
        {
            _positionY -= _speed;
            isUp = false;
            isRight = false;
            _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 2);
            // _animation01.Update(gameTime);
            _animation01.Play(_sequence01);
        }
        else if(kbCurrentState.IsKeyDown(Keys.Down))
        {
            _positionY += _speed;
            isUp = true;
            isRight = false;
            _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 0);
            // _animation01.Update(gameTime);
            _animation01.Play(_sequence01);
        }
        else if(kbCurrentState.IsKeyDown(Keys.Left))
        {
            _positionX -= _speed;  //???
            isUp = true;
            isRight = false;
            _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 1);
            // _animation01.Update(gameTime);
            _animation01.Play(_sequence01);
        }
        else if(kbCurrentState.IsKeyDown(Keys.Right))
        {
            _positionX += _speed;  //???
            isUp = true;
            isRight = true;
            _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 1);
            // _animation01.Update(gameTime);
            _animation01.Play(_sequence01);
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
            _animation01.Draw(_spriteBatch, new Vector2(_positionX, _positionY - _sequence01.CelHeight), SpriteEffects.FlipHorizontally);//None);
        }
        else
        {
            _animation01.Draw(_spriteBatch, new Vector2(_positionX, _positionY - _sequence01.CelHeight), SpriteEffects.None);//FlipHorizontally);
        }
        if (isUp == true)
        {
            _animation01.Draw(_spriteBatch, new Vector2(_positionX, _positionY - _sequence01.CelHeight), SpriteEffects.None);
        }
        else
        {
            _animation01.Draw(_spriteBatch, new Vector2(_positionX, _positionY - _sequence01.CelHeight), SpriteEffects.None);//FlipVertically);
        }
        
        _animation02.Draw(_spriteBatch, new Vector2(1400, 750 - _sequence02.CelHeight), SpriteEffects.None);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}







#region fix?
// The updated code looks much better! However, there are still a few issues that could be causing the problems you're describing with the animation:

// 1. The logic for row handling is not correct
// In the CelAnimationSequence class, you're currently calculating the row and column like this:

// csharp
// Copy
// int row = celIndex / (texture.Width / celWidth);
// int column = celIndex % (texture.Width / celWidth);
// This will only work if the spritesheet is arranged in a single row, but for multiple rows (like in most character animations), this logic should be modified to reflect how many rows exist in the spritesheet.

// If you have more than one row, you need to calculate the correct row and column, considering both the width (for columns) and height (for rows). Here’s how you could adjust it:

// csharp
// Copy
// int rows = texture.Height / celHeight;  // Calculate how many rows exist.
// int row = celIndex / (texture.Width / celWidth);
// int column = celIndex % (texture.Width / celWidth);
// return new Rectangle(column * celWidth, row * celHeight, celWidth, celHeight);
// This will properly account for multiple rows in the sprite sheet.

// 2. Incorrect Sequence Indexing
// You're currently trying to play different rows depending on the direction (Up, Down, Left, Right). This part:

// csharp
// Copy
// _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 2); // for Up
// _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 0); // for Down
// _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 1); // for Left
// _sequence01 = new CelAnimationSequence(spriteSheet01, 108, 102, 1 / 7f, 1); // for Right
// It looks like you're not updating the row index properly when moving up or down. Depending on how many rows are in the sprite sheet, you need to modify which row is shown based on the direction of movement.

// For example:

// For Up, the row index could be 2 (assuming it's the third row in your spritesheet).
// For Down, the row index could be 0 (if it's the first row).
// For Left, the row index could be 1 (second row).
// For Right, the row index could be 1 (same as left).
// So, when changing direction, you need to change the row index accordingly to show the correct sprite.

// 3. Frame Indexing and Animation Updates
// Make sure that you are properly updating the animation frames in the CelAnimationPlayer class. If the animation isn't updating, you might want to ensure that:

// The Play() method is correctly starting the animation for the given direction.
// The Update() method is advancing the frame and calling celSourceRectangle = celAnimationSequence.GetCelSourceRectangle(celIndex) correctly to reflect the change in animation frames.
// Additionally, you could make the animation play in a smoother way by ensuring that the cel time isn't too fast (i.e., the frames advance too quickly). It might help to adjust the time per frame based on the speed of the character movement.

// 4. Flipping Animation Logic
// You seem to be manually controlling the SpriteEffects.FlipHorizontally for moving left and right, which is great. But you also need to consider flipping for other movement directions if necessary, for example:

// Up and Down may need to be handled by flipping the sprite vertically in case the animation looks upside down when flipped horizontally.
// Suggested Adjustments:
// Fix Row/Column Logic: Update the row/column calculation for sprite sheets with multiple rows.

// Modify Direction Handling: Update the logic in Update() for handling different row indexes based on movement direction (up, down, left, right).

// Ensure Animation Updates: Double-check if your Update() method is correctly advancing through frames and that celSourceRectangle is properly recalculated each frame.

// Here’s an updated version of your CelAnimationSequence method that accounts for multiple rows:

// csharp
// Copy
// public Rectangle GetCelSourceRectangle(int celIndex)
// {
//     int columns = texture.Width / celWidth;  // Number of columns based on texture width.
//     int rows = texture.Height / celHeight;    // Number of rows based on texture height.

//     // Calculate row and column based on celIndex
//     int row = celIndex / columns;
//     int column = celIndex % columns;

//     return new Rectangle(column * celWidth, row * celHeight, celWidth, celHeight);
// }
// This approach should help fix the issue of getting frames from multiple rows.

// Feel free to let me know if you need further clarification or run into any more issues!
#endregion