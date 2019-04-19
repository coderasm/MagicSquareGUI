using System;
using System.Drawing;
using System.Windows.Forms;

namespace MagicSquareGUI
{
  public partial class magicSquares : Form
  {
    private int nSquares = 1;
    int[,] grid;
    private int clientDimension = 300;
    public magicSquares()
    {
      InitializeComponent();
      ClientSize = new Size(clientDimension, clientDimension + menuStrip1.Height);
      MinimumSize = ClientSize;
      promptForNSquares();
    }

    private void promptForNSquares()
    {
      using (var nSquaresPrompt = new EntryForm())
      {
        var result = nSquaresPrompt.ShowDialog();
        if (result == DialogResult.OK)
        {
          nSquares = nSquaresPrompt.nSquares;
          grid = MagicSquare.Create(nSquares).Grid;
          Invalidate();
        }
      }
    }

    private void prompForNewN(object sender, System.EventArgs e)
    {
      promptForNSquares();
    }

    private void onPaint(object sender, PaintEventArgs e)
    {
      if (grid != null)
        drawGrid(e);
    }

    private void drawGrid(PaintEventArgs e)
    {
      var x = 0;
      var y = menuStrip1.Height;
      //size all elements
      var spacingPercentage = .20;
      var spacingFix = nSquares > 3 ? 1 : 5;
      var smallSquarePercentage = 1 - spacingPercentage;
      var availableHeight = ClientSize.Height - menuStrip1.Height;
      var smallSquareWidth = (int)Math.Floor(ClientSize.Width * smallSquarePercentage / nSquares);
      var smallSquareHeight = (int)Math.Floor(availableHeight * smallSquarePercentage / nSquares);
      var spacingRight = (int)Math.Floor(ClientSize.Width * spacingPercentage / nSquares) - spacingFix;
      var spacingBottom = (int)Math.Floor(availableHeight * spacingPercentage / nSquares) - spacingFix;
      var largeSquareWidth = nSquares * smallSquareWidth + (nSquares + 1) * spacingRight;
      var largeSquareHeight = nSquares * smallSquareHeight + (nSquares + 1) * spacingBottom;
      var pen = new Pen(Color.Black);
      var brush = new SolidBrush(Color.Black);

      //make outer square
      var largeRect = new Rectangle(x, y, largeSquareWidth, largeSquareHeight);
      e.Graphics.DrawRectangle(pen, largeRect);
      e.Graphics.FillRectangle(brush, largeRect);

      pen.Color = Color.LimeGreen;
      brush.Color = Color.LimeGreen;
      //move to first square/cell
      x = spacingRight;
      y += spacingBottom;
      for (int i = 0; i < grid.GetLength(0); i++)
      {
        for (int p = 0; p < grid.GetLength(1); p++)
        {
          //draw small square/cell
          var smallRect = new Rectangle(x, y, smallSquareWidth, smallSquareHeight);
          e.Graphics.DrawRectangle(pen, smallRect);
          e.Graphics.FillRectangle(brush, smallRect);
          //draw number
          brush.Color = Color.Black;
          var font = new Font("Arial", smallSquareHeight * .50F);
          var textX = x + smallSquareWidth / (grid[i, p] > 9 ? 10 : 4);
          var textY = y + smallSquareHeight / 5;
          var format = new StringFormat();
          e.Graphics.DrawString(grid[i, p].ToString(), font, brush, textX, textY, format);
          brush.Color = Color.LimeGreen;
          //move to next cell
          x = x + smallSquareWidth + spacingRight;
        }
        //move to next row
        x = spacingRight;
        y = y + smallSquareHeight + spacingBottom;
      }
    }

    private void onResize(object sender, System.EventArgs e)
    {
      //Resize window to square of largest dimension
      clientDimension = ClientSize.Height > ClientSize.Width ? ClientSize.Height : ClientSize.Width;
      ClientSize = new Size(clientDimension, clientDimension);
      Invalidate();
    }
  }
}
