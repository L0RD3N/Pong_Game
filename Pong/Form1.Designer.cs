namespace Pong
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pBoxPlayer1 = new System.Windows.Forms.PictureBox();
			this.pBoxPlayer2 = new System.Windows.Forms.PictureBox();
			this.timerMove = new System.Windows.Forms.Timer(this.components);
			this.pBoxBall = new System.Windows.Forms.PictureBox();
			this.lblScore = new System.Windows.Forms.Label();
			this.timerBall = new System.Windows.Forms.Timer(this.components);
			this.timerGame = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pBoxPlayer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pBoxPlayer2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pBoxBall)).BeginInit();
			this.SuspendLayout();
			// 
			// pBoxPlayer1
			// 
			this.pBoxPlayer1.BackColor = System.Drawing.Color.MediumTurquoise;
			this.pBoxPlayer1.Location = new System.Drawing.Point(26, 214);
			this.pBoxPlayer1.Name = "pBoxPlayer1";
			this.pBoxPlayer1.Size = new System.Drawing.Size(30, 180);
			this.pBoxPlayer1.TabIndex = 0;
			this.pBoxPlayer1.TabStop = false;
			// 
			// pBoxPlayer2
			// 
			this.pBoxPlayer2.BackColor = System.Drawing.Color.OrangeRed;
			this.pBoxPlayer2.Location = new System.Drawing.Point(1149, 214);
			this.pBoxPlayer2.Name = "pBoxPlayer2";
			this.pBoxPlayer2.Size = new System.Drawing.Size(30, 180);
			this.pBoxPlayer2.TabIndex = 1;
			this.pBoxPlayer2.TabStop = false;
			// 
			// timerMove
			// 
			this.timerMove.Interval = 15;
			this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
			// 
			// pBoxBall
			// 
			this.pBoxBall.BackColor = System.Drawing.Color.Transparent;
			this.pBoxBall.Location = new System.Drawing.Point(564, 294);
			this.pBoxBall.Name = "pBoxBall";
			this.pBoxBall.Size = new System.Drawing.Size(45, 45);
			this.pBoxBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pBoxBall.TabIndex = 2;
			this.pBoxBall.TabStop = false;
			// 
			// lblScore
			// 
			this.lblScore.AutoSize = true;
			this.lblScore.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScore.ForeColor = System.Drawing.Color.White;
			this.lblScore.Location = new System.Drawing.Point(549, 21);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(63, 35);
			this.lblScore.TabIndex = 3;
			this.lblScore.Text = "0 - 0";
			// 
			// timerBall
			// 
			this.timerBall.Interval = 5;
			this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
			// 
			// timerGame
			// 
			this.timerGame.Interval = 1000;
			this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1198, 612);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.pBoxBall);
			this.Controls.Add(this.pBoxPlayer2);
			this.Controls.Add(this.pBoxPlayer1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pong";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pBoxPlayer1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pBoxPlayer2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pBoxBall)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pBoxPlayer1;
		private System.Windows.Forms.PictureBox pBoxPlayer2;
		private System.Windows.Forms.Timer timerMove;
		private System.Windows.Forms.PictureBox pBoxBall;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.Timer timerBall;
		private System.Windows.Forms.Timer timerGame;
	}
}

