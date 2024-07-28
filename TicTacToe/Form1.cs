using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        private void TicTacToeForm_Paint(object sender, PaintEventArgs e)
        {
            Color MyColor = Color.Black;

            Pen MyPen = new Pen(MyColor, 5);

            MyPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            MyPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(MyPen, 500, 200, 970, 200);
            e.Graphics.DrawLine(MyPen, 500, 350, 970, 350);

            e.Graphics.DrawLine(MyPen, 640, 20, 640, 500);
            e.Graphics.DrawLine(MyPen, 825, 20, 825, 500);
        }
    }
}
