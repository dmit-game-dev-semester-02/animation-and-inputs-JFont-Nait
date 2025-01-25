using System;
// using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01game;
    
/// <summary>
/// Represents a cel animated texture.
/// In other words, represents a spritesheet
/// </summary>
public class CelAnimationSequenceMultiRow
{
    // The texture containing the animation sequence...
    protected Texture2D texture;

    // The length of time a cel is displayed...
    protected float celTime;

    // Sequence metrics
    protected int celWidth;
    protected int celHeight;

    // Calculated count of cels in the sequence
    protected int celColumnCount;
    protected int celRowCount;
    public int rowToAnimate;
    // protected int rowIndex; //Added for Assignment01

    /// <summary>
    /// Constructs a new CelAnimationSequence.
    /// </summary>        
    // public CelAnimationSequenceMultiRow(Texture2D texture, int celWidth, int celHeight, float celTime, int celRowCount)//rowToAnimate)   //', int celHeight' Added for Assignment01
    public CelAnimationSequenceMultiRow(Texture2D texture, int celWidth, int celHeight, int celRowCount, int celColumnCount, float celTime, int rowToAnimate)//rowToAnimate)   //', int celHeight' Added for Assignment01
    {
        this.texture = texture;
        this.celWidth = celWidth;
        this.celHeight = celHeight;
        this.celTime = celTime;

        celHeight = Texture.Height;

        #region SITUATION ONE: ONE ANIMATION, MULTIPLE ROWS
        // this.celHeight = celHeight; (celHeight has to be passed as a parameter)
        // celColumnCount = Texture.Width / celWidth;
        // celRowCount = Texture.Height / celHeight;
        #endregion


        #region SITUATION TWO: MULTIPLE ANIMATIONS & ROWS
        this.rowToAnimate = rowToAnimate;
        celRowCount = CelRowCount;
        celColumnCount = CelColumnCount;


        #endregion
    }

    /// <summary>
    /// All frames in the animation arranged horizontally.
    /// </summary>
    public Texture2D Texture
    {
        get { return texture; }
    }

    /// <summary>
    /// Duration of time to show each cel.
    /// </summary>
    public float CelTime
    {
        get { return celTime; }
    }

    /// <summary>
    /// Gets the number of cels in the animation.
    /// </summary>
    public int CelColumnCount
    {
        get { return celColumnCount; }
    }
    public int CelRowCount
    {
        get { return celRowCount; }
    }

    /// <summary>
    /// Gets the width of a frame in the animation.
    /// </summary>
    public int CelWidth
    {
        get { return celWidth; }
    }

    /// <summary>
    /// Gets the height of a frame in the animation.
    /// </summary>
    public int CelHeight
    {
        get { return celHeight; }
    }
    public int RowToAnimate
    {
        get { return rowToAnimate; }
    }
    //Added for Assignment01
    public Rectangle GetCelSourceRectangle(int celIndex)
    {
        return new Rectangle(celColumnCount * celWidth, celRowCount * celHeight, celWidth, celHeight);
        // return new Rectangle(celIndex * celWidth, celCount * celHeight, celWidth, celHeight);
    }
}






