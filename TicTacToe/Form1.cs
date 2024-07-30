using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        private bool IsFirstPlayerTurn = true;
        private string[] Result = new string[9];
        private Byte Clicks_Counter = 0;

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

        private void Winner_Operation()
        {
            if (IsFirstPlayerTurn)
            {
                lblTurnName.Text = "Player 1";
                lblWinnerName.Text = "Player 1";
            }
            else
            {
                lblTurnName.Text = "Player 2";
                lblWinnerName.Text = "Player 2";
            }
            lblWinnerName.ForeColor = Color.DarkGreen;

            pbBox1.Enabled = false;
            pbBox2.Enabled = false;
            pbBox3.Enabled = false;
            pbBox4.Enabled = false;
            pbBox5.Enabled = false;
            pbBox6.Enabled = false;
            pbBox7.Enabled = false;
            pbBox8.Enabled = false;
            pbBox9.Enabled = false;
        }

        private void Draw_Operation()
        {
            lblWinnerName.Text = "Draw";
            lblWinnerName.ForeColor= Color.DarkGray;

            pbBox1.Enabled = false;
            pbBox2.Enabled = false;
            pbBox3.Enabled = false;
            pbBox4.Enabled = false;
            pbBox5.Enabled = false;
            pbBox6.Enabled = false;
            pbBox7.Enabled = false;
            pbBox8.Enabled = false;
            pbBox9.Enabled = false;
        }

        private void Evaluate_Result(Byte BoxNumber, string Sign)
        {
            if (Clicks_Counter > 9)
            {
                return;
            }

            Result[BoxNumber - 1] = Sign;

            // Game Logic

            // X-axis Possibilities
            if ((Result[0] == Sign) & (Result[1] == Sign) & (Result[2] == Sign)) { Winner_Operation(); return; }
            if ((Result[3] == Sign) & (Result[4] == Sign) & (Result[5] == Sign)) { Winner_Operation(); return; }
            if ((Result[6] == Sign) & (Result[7] == Sign) & (Result[8] == Sign)) { Winner_Operation(); return; }

            // Y-axis Possibilities
            if ((Result[0] == Sign) & (Result[3] == Sign) & (Result[6] == Sign)) { Winner_Operation(); return; }
            if ((Result[1] == Sign) & (Result[4] == Sign) & (Result[7] == Sign)) { Winner_Operation(); return; }
            if ((Result[2] == Sign) & (Result[5] == Sign) & (Result[8] == Sign)) { Winner_Operation(); return; }

            // Diagonal Possibilities
            if ((Result[0] == Sign) & (Result[4] == Sign) & (Result[8] == Sign)) { Winner_Operation(); return; }
            if ((Result[2] == Sign) & (Result[4] == Sign) & (Result[6] == Sign)) { Winner_Operation(); return; }

            if (Clicks_Counter == 9) { Draw_Operation(); }
        }

        private void All_pbBox_Clicks(object sender, EventArgs e)
        {
            Clicks_Counter++;
            PictureBox CurrentPb = (PictureBox)sender;

            //if (CurrentPb.Image != Resources.QuestionMark)
            //{
            //    MessageBox.Show("This Box is Chosen Before!");
            //    return;
            //}

            if (IsFirstPlayerTurn)
            {
                CurrentPb.Image = Resources.X;
                Evaluate_Result(Convert.ToByte(CurrentPb.Tag), "X");
                lblTurnName.Text = "Player 2";
            }
            else
            {
                CurrentPb.Image = Resources.O;
                Evaluate_Result(Convert.ToByte(CurrentPb.Tag), "O");
                lblTurnName.Text = "Player 1";
            }

            CurrentPb.Enabled = false;
            IsFirstPlayerTurn = !IsFirstPlayerTurn;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            pbBox1.Image = Resources.QuestionMark;
            pbBox2.Image = Resources.QuestionMark;
            pbBox3.Image = Resources.QuestionMark;
            pbBox4.Image = Resources.QuestionMark;
            pbBox5.Image = Resources.QuestionMark;
            pbBox6.Image = Resources.QuestionMark;
            pbBox7.Image = Resources.QuestionMark;
            pbBox8.Image = Resources.QuestionMark;
            pbBox9.Image = Resources.QuestionMark;

            pbBox1.Enabled = true;
            pbBox2.Enabled = true;
            pbBox3.Enabled = true;
            pbBox4.Enabled = true;
            pbBox5.Enabled = true;
            pbBox6.Enabled = true;
            pbBox7.Enabled = true;
            pbBox8.Enabled = true;
            pbBox9.Enabled = true;

            IsFirstPlayerTurn = true;
            lblTurnName.Text = "Player 1";
            lblWinnerName.Text = "In Progress";
            lblWinnerName.ForeColor = Color.Blue;

            Result = new string[9];
            Clicks_Counter = 0;
        }

        private void pbBox1_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox2_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox3_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox4_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox5_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox6_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox7_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox8_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }

        private void pbBox9_Click(object sender, EventArgs e)
        {
            All_pbBox_Clicks(sender, e);
        }
    }
}
