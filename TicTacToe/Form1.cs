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
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label[] squares;
        public string player;
        public int turn_number;
        private bool isGameOver;

        private static  int[,] Winners = new int[,]
                                                    {

                                                    {0,1,2},

                                                    {3,4,5},

                                                    {6,7,8},

                                                    {0,3,6},

                                                    {1,4,7},

                                                    {2,5,8},

                                                    {0,4,8},

                                                    {2,4,6}

                                                    };

        public Form1()
        {
            InitializeComponent();
            init();
          
        }

        private void init()
        {
            this.isGameOver = false;
            turn_number = 0;
            squares = new Label[9] { sq1, sq2, sq3, sq4, sq5, sq6, sq7, sq8, sq9 };
            this.box.Enabled = false;
            lblMsg.Text = "Click Start new game";
            box.Enabled = false;
            sq1.Enabled = false;
            sq2.Enabled = false;
            sq3.Enabled = false;
            sq4.Enabled = false;
            sq5.Enabled = false;
            sq6.Enabled = false;
            sq7.Enabled = false;
            sq8.Enabled = false;
            sq9.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                new_game();
                for (int i = 0; i < 9; i++)
                {
                    this.squares[i].Click += new System.EventHandler(this.ClickHandler);
                    this.squares[i].MouseMove += new MouseEventHandler(this.MouseMoveHandler);
                    this.squares[i].MouseLeave += new System.EventHandler(this.MouseLeaveHandler);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void new_game()
        {
            this.box.Enabled = true;
            lblMsg.Text = "";
            turn_number = 0;
            if (xplayer.Checked == true)
            {
                player = "x";
                lblMsg.Text = "Player 1's turn";
            }
            else
            {
                player = "o";
                lblMsg.Text = "Player 2's turn";
            }

            for (int i = 0; i < 9; i++)
            {

                squares[i].Text = "";

                squares[i].ForeColor = Color.Black;

                squares[i].BackColor = Color.Transparent;

                squares[i].Enabled = true;
            }
        }

        private void ClickHandler(object sender, System.EventArgs e)
        {
            Label tmp = (Label)sender;

            turn_number += 1;

            if (tmp.Text != "")
            {
                return;
            }

            if (player == "x")
            {
                tmp.ForeColor = Color.Red;
                tmp.Text = "X";
                player = "o";
                lblMsg.Text = "Player 2's turn";
                lblMsg.ForeColor = Color.Purple;
            }
            else
            {
                tmp.ForeColor = Color.Purple;
                tmp.Text = "O";
                player = "x";
                lblMsg.Text = "Player 1's turn";
                lblMsg.ForeColor = Color.Red;
            }

            tmp.BackColor = Color.Transparent;

            this.isGameOver = CheckWinner(squares);

            if (isGameOver)
            {
               
                init();
            }

            if (turn_number == 9 && !isGameOver)
            {
                MessageBox.Show("Draw", "game over", MessageBoxButtons.OK);
                lblMsg.Text = "";
                init();
            }
        }



        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            Label tmp = (Label)sender;

            if (tmp.Text != "")
            {
                return;
            }

            if (player == "x")
            {
                tmp.BackColor = Color.PowderBlue;
            }
            else
            {
                tmp.BackColor = Color.PeachPuff;
            }
        }

        private void MouseLeaveHandler(object sender, EventArgs e)
        {
            Label tmp = (Label)sender;

            if (tmp.Text != "")
            {
                return;
            }
            else
            {
                tmp.BackColor = Color.Transparent;
            }

        }

        private static bool CheckWinner(Label[] ctrls)
        {
            
            bool gameOver = false;

            for (int i = 0; i < 8; i++)
            {

                int a = Winners[i, 0], b = Winners[i, 1], c = Winners[i, 2];

                Label lb1 = ctrls[a], lb2 = ctrls[b], lb3 = ctrls[c];

                if (lb1.Text == "" || lb2.Text == "" || lb3.Text == "")

                    continue;

                if (lb1.Text == lb2.Text && lb2.Text == lb3.Text)
                {

                    lb1.BackColor = lb2.BackColor = lb3.BackColor = Color.Silver;

                    gameOver = true;

                    MessageBox.Show("Player: " + lb1.Text + " wins ", "Game Over", MessageBoxButtons.OK);
                    
                    break;

                }

            }
            
            return gameOver;

        }
    }
}
