using System;
using System.Windows.Forms;

namespace MagicSquareGUI
{
  public partial class EntryForm : Form
  {
    public int nSquares { get; set; } = 1;
    public EntryForm()
    {
      InitializeComponent();
    }

    private void onSubmit(object sender, EventArgs e)
    {
      var nSquares = 1;
      var isInt = int.TryParse(textBox1.Text, out nSquares);
      if (isInt && nSquares % 2 != 0)
      {
        this.nSquares = nSquares;
        DialogResult = DialogResult.OK;
        Close();
      }
      else
        errorLabel.Visible = true;
    }

    private void onCancel(object sender, EventArgs e)
    {
      DialogResult = DialogResult.None;
      Close();
    }
  }
}
