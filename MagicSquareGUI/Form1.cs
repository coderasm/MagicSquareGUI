using System;
using System.Windows.Forms;

namespace MagicSquareGUI
{
  public partial class magicSquares : Form
  {
    private int nSquares = 1;
    int[,] grid;
    public magicSquares()
    {
      InitializeComponent();
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
          var magicSquare = MagicSquare.Create(nSquares);
          drawGrid(magicSquare.Grid);
        }
      }
    }

    private void drawGrid(int[,] grid)
    {

    }

    private void prompForNewN(object sender, System.EventArgs e)
    {
      promptForNSquares();
    }
  }
}
