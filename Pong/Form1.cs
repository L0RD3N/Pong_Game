using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		bool goUpP1 = false, goDownP1 = false, goUpP2 = false, goDownP2 = false;
		int width, height, ballSpeed = 5, playerSpeed = 5, scoreLeft = 0, scoreRight = 0, time = 0;
		Pair<int, int> ballDirection = new Pair<int, int> (-1, 0);
		SoundPlayer playerHit = new SoundPlayer(), wallHit = new SoundPlayer(), pointScore = new SoundPlayer();

		private void DrawBall()
		{
			Bitmap bmp = new Bitmap(40, 40);
			Brush brush = new SolidBrush(Color.White);
			Pen pen = new Pen(brush, 3);
			Graphics graphics = Graphics.FromImage(bmp);
			graphics.FillEllipse(brush, 0, 0, 40, 40);
			Image img = (Image)bmp;
			pBoxBall.Image = img;
		}

		private void timerGame_Tick(object sender, EventArgs e)
		{
			time++;
			if (time % 15 == 0)
			{
				ballSpeed += 2;
			}
		}

		PictureBox borderUp = new PictureBox(), borderDown = new PictureBox(), borderLeft = new PictureBox(), borderRight = new PictureBox();

		private void ResetBall()
		{
			pBoxBall.Location = new Point(564, 294);
			Random rnd = new Random();
			int nr = rnd.Next(0, 2);

			if (nr == 0)
				ballDirection.First = -1;
			else
				ballDirection.First = 1;

			nr = rnd.Next(1, 11);
			if (nr % 5 == 0)
				ballDirection.Second = rnd.Next(-1, 2);
			else if (nr % 2 == 0)
				ballDirection.Second = 1;
			else if (nr % 2 == 1)
				ballDirection.Second = -1;
		}

		private void updateLabels()
		{
			lblScore.Text = scoreLeft.ToString() + " - " + scoreRight.ToString() ;
			if (scoreLeft == 7 || scoreRight == 7)
			{
				timerGame.Stop();
				timerMove.Stop();
				timerBall.Stop();
				if (scoreLeft == 7)
					MessageBox.Show("Player 1 a castigat!", "Joc terminat");

				if (scoreRight == 7)
					MessageBox.Show("Player 2 a castigat!", "Joc terminat");

				DialogResult dr = MessageBox.Show("Jocul s-a terminat! Mai doresti sa joci o data?", "Joc terminat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					ResetBall();
					pBoxPlayer1.Left = 26;
					pBoxPlayer1.Top = 214;
					pBoxPlayer2.Left = 1149;
					pBoxPlayer2.Top = 214;
					scoreLeft = 0;
					scoreRight = 0;
					updateLabels();
					time = 0;
					timerGame.Start();
					timerMove.Start();
					timerBall.Start();
				}

				else
				{
					Application.Exit();
				}

			}

		}

		private void timerBall_Tick(object sender, EventArgs e)
		{
			pBoxBall.Left += (ballDirection.First * ballSpeed);
			pBoxBall.Top += (ballDirection.Second * ballSpeed);
			Random rnd = new Random();
			if (pBoxBall.Bounds.IntersectsWith(pBoxPlayer1.Bounds))
			{
				playerHit.Play();
				pBoxBall.Left += 10;
				ballDirection.First *= (-1);

				int nr = rnd.Next(1, 11);

				if (nr % 5 == 0)
					ballDirection.Second = rnd.Next(-1, 2);

				else if (nr % 2 == 0)
					ballDirection.Second = 1;

				else if (nr % 2 == 1)
					ballDirection.Second = -1;
			}

			if (pBoxBall.Bounds.IntersectsWith(pBoxPlayer2.Bounds))
			{
				playerHit.Play();
				pBoxBall.Left -= 10;
				ballDirection.First *= (-1);

				if (ballDirection.Second == -1)
					ballDirection.Second = 1;

				else if (ballDirection.Second == 0)
					ballDirection.Second = rnd.Next(-1, 2);

				else if (ballDirection.Second == -1)
					ballDirection.Second = 1;
			}


			if (pBoxBall.Bounds.IntersectsWith(borderLeft.Bounds))
			{ 
				pointScore.Play();
				ResetBall();
				scoreRight++; 
				updateLabels(); 
			}

			if (pBoxBall.Bounds.IntersectsWith(borderRight.Bounds))
			{ 
				pointScore.Play();
				ResetBall();
				scoreLeft++; 
				updateLabels(); 
			}

			if (pBoxBall.Bounds.IntersectsWith(borderUp.Bounds))
			{
				wallHit.Play();
				ballDirection.Second *= (-1);
			}

			if (pBoxBall.Bounds.IntersectsWith(borderDown.Bounds))
			{
				wallHit.Play();
				ballDirection.Second *= (-1);
			}
		}

		private void timerMove_Tick(object sender, EventArgs e)
		{
			if (goUpP1)
			{
				if (!pBoxPlayer1.Bounds.IntersectsWith(borderUp.Bounds))
				{
					pBoxPlayer1.Top -= playerSpeed;
				}
			}	
				
			if (goDownP1)
			{
				if (!pBoxPlayer1.Bounds.IntersectsWith(borderDown.Bounds))
					pBoxPlayer1.Top += playerSpeed;
			}
				

			if (goUpP2)
			{
				if (!pBoxPlayer2.Bounds.IntersectsWith(borderUp.Bounds))
					pBoxPlayer2.Top -= playerSpeed;
			}
				
			if (goDownP2)
			{
				if (!pBoxPlayer2.Bounds.IntersectsWith(borderDown.Bounds))
					pBoxPlayer2.Top += playerSpeed;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			MessageBox.Show("Jucatorul din stanga se misca prin tastele W si S, iar jucatorul din stanga prin sagetile Up si Down. \nCine ajunge primul la 7 puncte castiga. \nIesirea din joc se face prin apasarea tastei ESC.", "Instructiuni", MessageBoxButtons.OK, MessageBoxIcon.Information);
			timerMove.Start();
			timerBall.Start();
			timerGame.Start();
			width = this.Width;
			height = this.Height;

			playerHit.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"sounds\player_hit.wav";
			wallHit.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"sounds\wall_hit.wav";
			pointScore.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"sounds\ping.wav";
			DrawBall();
			ResetBall();

		}

		private void drawBorders()
		{
			borderUp.Location = new Point(0, 0);
			borderUp.Width = width;
			borderUp.Height = 10;
			borderUp.BackColor = Color.Yellow;
			Controls.Add(borderUp);
			borderLeft.Location = new Point(0, 0);
			borderLeft.Height = height;
			borderLeft.Width = 10;
			borderLeft.BackColor = Color.Green;
			Controls.Add(borderLeft);
			borderDown.Location = new Point(0, height - 50);
			borderDown.Width = width;
			borderDown.Height = 10;
			borderDown.BackColor = Color.Yellow;
			Controls.Add(borderDown);
			borderRight.Location = new Point(width - 25, 0);
			borderRight.Height = height;
			borderRight.Width = 10;
			borderRight.BackColor = Color.Green;
			Controls.Add(borderRight);
		}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			
			drawBorders();
			
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.W)
				goUpP1 = true;
			if (e.KeyCode == Keys.S)
				goDownP1 = true;

			if (e.KeyCode == Keys.Up)
				goUpP2 = true;
			if (e.KeyCode == Keys.Down)
				goDownP2 = true;

			if (e.KeyCode == Keys.Escape)
			{
				timerMove.Stop();
				timerBall.Stop();
				timerGame.Stop();
				DialogResult dr = MessageBox.Show("Sunteti sigur ca vreti sa iesiti din joc?", "Iesire", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					Application.Exit();
				}
				else
				{
					timerMove.Start();
					timerBall.Start();
					timerGame.Start();
				}
			}

		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.W)
				goUpP1 = false;
			if (e.KeyCode == Keys.S)
				goDownP1 = false;

			if (e.KeyCode == Keys.Up)
				goUpP2 = false;
			if (e.KeyCode == Keys.Down)
				goDownP2 = false;
		}

	}
}
