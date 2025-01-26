using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01game;
    
public class CelAnimationPlayerMultiRow
{
    #region Fields
    private CelAnimationSequenceMultiRow celAnimationSequenceMultiRow;
    private int celCurrentRow;
    private int celCurrentColumn;
    private float celTimeElapsed;
    private Rectangle celCurrentFrame;
    private bool celPlaying;
    private KeyboardState previousKeyboardState;

    private int idleUp = 2;
    private int idleDown = 0;
    private int idleLeft = 1;
    private int idleRight = 3;
    #endregion

    public CelAnimationPlayerMultiRow()
    {
        celCurrentRow = 0;
        celCurrentColumn = 0;
        celTimeElapsed = 0f;
        celPlaying = false;
        previousKeyboardState = Keyboard.GetState();
    }

    public void Play(CelAnimationSequenceMultiRow celAnimationSequenceMultiRow, int row)
    {
        this.celAnimationSequenceMultiRow = celAnimationSequenceMultiRow;
        celCurrentRow = row;
        celCurrentColumn = 1;
        celTimeElapsed = 0f;
        celCurrentFrame = celAnimationSequenceMultiRow.GetFrameRectangle(celCurrentRow, celCurrentColumn);
        celPlaying = true;
    }

    public void Stop()
    {
        celPlaying = false;
    }

    public void Update(GameTime gameTime)
    {
        if (celAnimationSequenceMultiRow != null && celPlaying)
        {
            celTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (celTimeElapsed >= celAnimationSequenceMultiRow.CelTime)
            {
                celTimeElapsed -= celAnimationSequenceMultiRow.CelTime;
                celCurrentColumn = (celCurrentColumn + 1) % celAnimationSequenceMultiRow.CelColumns;
                celCurrentFrame = celAnimationSequenceMultiRow.GetFrameRectangle(celCurrentRow, celCurrentColumn);
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
    {
        if (celAnimationSequenceMultiRow != null)
        {
            spriteBatch.Draw(celAnimationSequenceMultiRow.Texture, position, celCurrentFrame, Color.White, 0.0f, Vector2.Zero, 1.0f, spriteEffects, 0.0f);
        }
    }

    public void HandlePlayerInput(KeyboardState keyboardState)
    {
        int targetRow = celCurrentRow;

        #region Walking Animations
        if (keyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Up))
        {
            targetRow = 2;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        else if (keyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyUp(Keys.Down))
        {
            targetRow = 0;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        else if (keyboardState.IsKeyDown(Keys.Left) && previousKeyboardState.IsKeyUp(Keys.Left))
        {
            targetRow = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        else if (keyboardState.IsKeyDown(Keys.Right) && previousKeyboardState.IsKeyUp(Keys.Right))
        {
            targetRow = 3;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        #endregion

        #region Walking Default Positions
        if (keyboardState.IsKeyUp(Keys.Up) && celCurrentRow == 2)
        {
            targetRow = idleUp;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        if (keyboardState.IsKeyUp(Keys.Down) && celCurrentRow == 0)
        {
            targetRow = idleDown;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        if (keyboardState.IsKeyUp(Keys.Left) && celCurrentRow == 1)
        {
            targetRow = idleLeft;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        if (keyboardState.IsKeyUp(Keys.Right) && celCurrentRow == 3)
        {
            targetRow = idleRight;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        #endregion

            if (keyboardState.GetPressedKeys().Length == 0)
        {
            Stop();
        }

        previousKeyboardState = keyboardState;
    }
   
    public void HandleDudeInput(KeyboardState keyboardState)
    {
        int targetRow = celCurrentRow;
            
        #region SomeDude Animations
        if (keyboardState.IsKeyDown(Keys.W) && previousKeyboardState.IsKeyUp(Keys.W))
        {
            targetRow = 2;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        else if (keyboardState.IsKeyDown(Keys.S) && previousKeyboardState.IsKeyUp(Keys.S))
        {
            targetRow = 0;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        else if (keyboardState.IsKeyDown(Keys.A) && previousKeyboardState.IsKeyUp(Keys.A))
        {
            targetRow = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        else if (keyboardState.IsKeyDown(Keys.D) && previousKeyboardState.IsKeyUp(Keys.D))
        {
            targetRow = 3;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        #endregion

        #region SomeDude Default Positions
        if (keyboardState.IsKeyUp(Keys.W) && celCurrentRow == 2)
        {
            targetRow = idleUp;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        if (keyboardState.IsKeyUp(Keys.S) && celCurrentRow == 0)
        {
            targetRow = idleDown;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        if (keyboardState.IsKeyUp(Keys.A) && celCurrentRow == 1)
        {
            targetRow = idleLeft;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        if (keyboardState.IsKeyUp(Keys.D) && celCurrentRow == 3)
        {
            targetRow = idleRight;
            celCurrentColumn = 1;
            Play(celAnimationSequenceMultiRow, targetRow);
        }
        #endregion

        if (keyboardState.GetPressedKeys().Length == 0)
        {
            Stop();
        }

        previousKeyboardState = keyboardState;
    }

    public void HandleFireInput(KeyboardState keyboardState)
    {
        int targetRow = celCurrentRow;

        if (keyboardState.IsKeyDown(Keys.Space))
        {
            if (!celPlaying)
            {
                Play(celAnimationSequenceMultiRow, targetRow);
            }
        }
        else
        {
            targetRow = -1;
            Stop();
        }
    }
}