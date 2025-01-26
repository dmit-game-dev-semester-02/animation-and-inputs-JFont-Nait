using System;
using System.ComponentModel;
// using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01game;
    
public class CelAnimationSequenceMultiRow
{
    #region Fields
    protected Texture2D texture;
    protected int celWidth;
    protected int celHeight;
    protected float celTime;
    protected int celColumns;
    protected int celRows;
    #endregion
    
    public CelAnimationSequenceMultiRow(Texture2D texture, int celWidth, int celHeight, float celTime)
    {
        this.texture = texture;
        this.celWidth = celWidth;
        this.celHeight = celHeight;
        this.celTime = celTime;
        this.celColumns = texture.Width / celWidth;
        this.celRows = texture.Height / celHeight;
    }

    #region Properties
    public Texture2D Texture { get { return texture; }}
    public int CelWidth { get { return celWidth; }}
    public int CelHeight { get { return celHeight; }}
    public float CelTime { get { return celTime; }}
    public int CelColumns { get { return celColumns; }}
    public int CelRows { get { return celRows; }}
    #endregion

    public Rectangle GetFrameRectangle(int row, int column)
    {
        return new Rectangle(column * celWidth, row * celHeight, celWidth, celHeight);
    }
}