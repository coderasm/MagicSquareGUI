using System.Windows.Forms;

namespace MagicSquare
{
  public partial class magicSquares : Form
  {
    private int nSquares = 1;
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
          generateGrid();
          drawGrid();
        }
      }
    }

    private void generateGrid()
    {
      int[,] grid = new int[nSquares, nSquares];
      if (nSquares % 4 == 0)
        populateWithDoublyEvenMethod(grid);
      else if (nSquares % 2 == 0)
        populateWithSinglyEvenMethod(grid);
      else
        populateWithOddMethod(grid);
    }

    private void populateWithOddMethod(int[,] grid)
    {
      //place one
      var currentColumn = nSquares / 2;
      var currentRow = 0;
      grid[currentRow, currentColumn] = 1;
      var iterations = nSquares * nSquares - 1;
      for (int i = 0; i < iterations; i++)
      {
        //check up and right

      }
    }

    private void populateWithDoublyEvenMethod(int[,] grid)
    {

    }

    private void populateWithSinglyEvenMethod(int[,] grid)
    {

    }

    private void drawGrid()
    {

    }

    private void toolStripLabel1_Click(object sender, System.EventArgs e)
    {

    }

    private void prompForNewN(object sender, System.EventArgs e)
    {
      promptForNSquares();
    }
  }
}
