using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01game;
    
/// <summary>
/// Controls playback of a CelAnimationSequence.
/// </summary>
public class CelAnimationPlayerMultiRow
{
    private CelAnimationSequenceMultiRow celAnimationSequenceMultiRow;
    private int celIndex;
    private int celIndexColumn;
    private int celIndexRow;
    private float celTimeElapsed;
    private Rectangle celSourceRectangle;

    /// <summary>
    /// Begins or continues playback of a CelAnimationSequence.
    /// Note: A CelAnimationPlayer can only play ONE animation at a time. 
    /// </summary>
    public void Play(CelAnimationSequenceMultiRow celAnimationSequenceMultiRow)
    {
        if (celAnimationSequenceMultiRow == null)
        {
            throw new Exception("CelAnimationPlayer.PlayAnimation received null CelAnimationSequence");
        }
        // If this animation is already running, do not restart it...
        if (celAnimationSequenceMultiRow != this.celAnimationSequenceMultiRow)
        {
            this.celAnimationSequenceMultiRow = celAnimationSequenceMultiRow;
            
            #region SITUATION ONE: ONE ANIMATION, MULTIPLE ROWS
            // celIndexColumn;
            // celIndexRow;
            #endregion


            celIndex = 0;
            celTimeElapsed = 0.0f;

            celSourceRectangle.X = 0;//celAnimationSequenceMultiRow.RowToAnimate * celAnimationSequenceMultiRow.CelWidth;
            celSourceRectangle.Y = celAnimationSequenceMultiRow.RowToAnimate * celAnimationSequenceMultiRow.CelHeight;
            celSourceRectangle.Width = this.celAnimationSequenceMultiRow.CelWidth;
            celSourceRectangle.Height = this.celAnimationSequenceMultiRow.CelHeight;
            // celSourceRectangle = celAnimationSequence.GetCelSourceRectangle(celIndex);  //Added for Assignment01, above comments were class work.
        }
    }

    /// <summary>
    /// Update the state of the CelAnimationPlayer.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public void Update(GameTime gameTime)
    {
        if (celAnimationSequenceMultiRow != null)
        {
            celTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (celTimeElapsed >= celAnimationSequenceMultiRow.CelTime)
            {
                celTimeElapsed -= celAnimationSequenceMultiRow.CelTime;

                // Advance the frame index looping as appropriate...
                celIndexColumn = (celIndex + 1) % celAnimationSequenceMultiRow.CelColumnCount; //One Animation Many Row
                // celIndexRow = (celIndex + 1) % celAnimationSequence.CelRowCount; //One Animation Many Row


                // celSourceRectangle.X = celIndex * celSourceRectangle.Width;
                celSourceRectangle = celAnimationSequenceMultiRow.GetCelSourceRectangle(celIndex);  //Added for Assignment01, above comments were class work.
            }
        }
    }

    /// <summary>
    /// Draws the current cel of the animation.
    /// </summary>
    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
    {
        if (celAnimationSequenceMultiRow != null)
        {
            spriteBatch.Draw(celAnimationSequenceMultiRow.Texture, position, celSourceRectangle, Color.White, 0.0f, Vector2.Zero, 1.0f, spriteEffects, 0.0f);
        }
    }
}

