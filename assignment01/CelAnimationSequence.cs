using System;
// using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01game;
    
/// <summary>
/// Represents a cel animated texture.
/// In other words, represents a spritesheet
/// </summary>
public class CelAnimationSequence
{
    // The texture containing the animation sequence...
    protected Texture2D texture;

    // The length of time a cel is displayed...
    protected float celTime;

    // Sequence metrics
    protected int celWidth;
    protected int celHeight;

    // Calculated count of cels in the sequence
    protected int celCount;
    // protected int rowIndex; //Added for Assignment01

    /// <summary>
    /// Constructs a new CelAnimationSequence.
    /// </summary>        
    public CelAnimationSequence(Texture2D texture, int celWidth, int celHeight, float celTime, int celCount = 0)   //', int celHeight' Added for Assignment01
    {
        this.texture = texture;
        this.celWidth = celWidth;
        this.celTime = celTime;
        this.celCount = celCount;   //Added for Assignment01

        this.celCount = Texture.Width / celWidth;
        this.celHeight = celHeight;
        // this.celHeight = Texture.Height / celHeight;

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
    public int CelCount
    {
        get { return celCount; }
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

    //Added for Assignment01
    public Rectangle GetCelSourceRectangle(int celIndex)
    {
        // int columns = texture.Width / celWidth;
        int row = celIndex / (texture.Width / celWidth);
        int column = celIndex % (texture.Width / celWidth);
        return new Rectangle(column * celWidth, row * celHeight, celWidth, celHeight);
        // return new Rectangle(celIndex * celWidth, celCount * celHeight, celWidth, celHeight);
    }
}






