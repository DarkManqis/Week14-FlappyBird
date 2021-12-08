using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipeSpeed = 6;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            PipeTop.Left -= pipeSpeed;
            PipeBottom.Left -= pipeSpeed;
            scoreLabel.Text = $"score: {score}";

            if(PipeTop.Left < -100)
            {
                PipeTop.Left = 600;
                score++;
            }

            if(PipeBottom.Left < -100)
            {
                PipeBottom.Left = 600;
                score++;
            }

            if(bird.Top < -25)
            {
                gameOver();
            }


            if(bird.Bounds.IntersectsWith(PipeTop.Bounds) || bird.Bounds.IntersectsWith(PipeBottom.Bounds) || bird.Bounds.IntersectsWith(grounds.Bounds))
            {
                gameOver();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void bird_Click(object sender, EventArgs e)
        {

        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text = $"GAME OVER!";
            playAgain.Visible = true;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Form1 Newform = new Form1();
            Newform.Show();
            this.Dispose(false);
        }
    }
}
