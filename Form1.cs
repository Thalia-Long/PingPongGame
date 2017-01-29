using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongGame
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int points = 0;
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide(); //Hide the cursor

            this.FormBorderStyle = FormBorderStyle.None; // remove any border
            this.TopMost = true; // Bring the form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds; //Make it fullscreen

            racket.Top = playground.Bottom - (playground.Bottom / 10);//set the position of the racket

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2); //position to center
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false; //Hide the game over label, only display when the ball fall

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2); //Set the center of the racket to the position of the cursor

            ball.Left += speed_left; //Move the ball
            ball.Top += speed_top;

            if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) //Racket Collision
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top; //change direction
                points += 1;
                points_lbl.Text = points.ToString();
                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));//Get a random RGB color background
            }
            if(ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if(ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if(ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if(ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                gameover_lbl.Visible = true;
            }
        }


        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
                playground.BackColor = Color.White;
            }
        }
    }
}
