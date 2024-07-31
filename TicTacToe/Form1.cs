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

        stGameStatus GameStatus;
        bool IsFirstPlayerTurn = true;

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

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

        public bool CheckValues(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            if (pb1.Tag.ToString() != "?" && pb1.Tag.ToString() == pb2.Tag.ToString() && pb1.Tag.ToString() == pb3.Tag.ToString())
            {
                pb1.BackColor = Color.GreenYellow;
                pb2.BackColor = Color.GreenYellow;
                pb3.BackColor = Color.GreenYellow;

                if (pb1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        void EnableOrDisablePb(bool value)
        {
            pbBox1.Enabled = value;
            pbBox2.Enabled = value;
            pbBox3.Enabled = value;
            pbBox4.Enabled = value;
            pbBox5.Enabled = value;
            pbBox6.Enabled = value;
            pbBox7.Enabled = value;
            pbBox8.Enabled = value;
            pbBox9.Enabled = value;
        }

        void EndGame()
        {

            lblTurnName.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinnerName.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lblWinnerName.Text = "Player 2";
                    break;
                default:
                    lblWinnerName.Text = "Draw";
                    break;
            }

            EnableOrDisablePb(false);

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void CheckWinner()
        {
            //checked rows
            //check Row1
            if (CheckValues(pbBox1, pbBox2, pbBox3))
                return;

            //check Row2
            if (CheckValues(pbBox4, pbBox5, pbBox6))
                return;

            //check Row3
            if (CheckValues(pbBox7, pbBox8, pbBox9))
                return;

            //checked cols
            //check col1
            if (CheckValues(pbBox1, pbBox4, pbBox7))
                return;

            //check col2
            if (CheckValues(pbBox2, pbBox5, pbBox8))
                return;

            //check col3
            if (CheckValues(pbBox3, pbBox6, pbBox9))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(pbBox1, pbBox5, pbBox9))
                return;

            //check Diagonal2
            if (CheckValues(pbBox3, pbBox5, pbBox7))
                return;
        }

        private void Change_Img(PictureBox ClickedPb)
        {
            if (ClickedPb.Tag.ToString() == "?")
            {
                if (IsFirstPlayerTurn)
                {
                    ClickedPb.Image = Resources.X;
                    lblTurnName.Text = "Player 2";
                    GameStatus.PlayCount++;
                    ClickedPb.Tag = "X";
                    CheckWinner();
                }
                else
                {
                    ClickedPb.Image = Resources.O;
                    lblTurnName.Text = "Player 1";
                    GameStatus.PlayCount++;
                    ClickedPb.Tag = "O";
                    CheckWinner();
                }
            }
            else

            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            IsFirstPlayerTurn = !IsFirstPlayerTurn;


            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

        }

        private void RestPb(PictureBox pb)
        {
            pb.Image = Resources.QuestionMark;
            pb.Tag = "?";
            pb.BackColor = Color.Transparent;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            EnableOrDisablePb(true);

            RestPb(pbBox1);
            RestPb(pbBox2);
            RestPb(pbBox3);
            RestPb(pbBox4);
            RestPb(pbBox5);
            RestPb(pbBox6);
            RestPb(pbBox7);
            RestPb(pbBox8);
            RestPb(pbBox9);

            IsFirstPlayerTurn = true;
            lblTurnName.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinnerName.Text = "In Progress";
        }

        private void pbBox_all_Click(object sender, EventArgs e)
        {
            Change_Img((PictureBox)sender);
        }
    }
}
