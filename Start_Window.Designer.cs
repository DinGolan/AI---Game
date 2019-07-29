namespace AI___Obstacle_Board
{
	partial class Start_Window
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_Window));
			this.Panel_Left_Start_Window = new System.Windows.Forms.Panel();
			this.Picture_AI = new System.Windows.Forms.PictureBox();
			this.Panel_Right_Start_Window = new System.Windows.Forms.Panel();
			this.Label_Error = new System.Windows.Forms.Label();
			this.Combo_Box_Details = new System.Windows.Forms.ComboBox();
			this.Button_Start_Game = new System.Windows.Forms.Button();
			this.Label_Value = new System.Windows.Forms.Label();
			this.Label_One = new System.Windows.Forms.Label();
			this.Panel_Left_Start_Window.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Picture_AI)).BeginInit();
			this.Panel_Right_Start_Window.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel_Left_Start_Window
			// 
			this.Panel_Left_Start_Window.BackColor = System.Drawing.SystemColors.Menu;
			this.Panel_Left_Start_Window.Controls.Add(this.Picture_AI);
			this.Panel_Left_Start_Window.Dock = System.Windows.Forms.DockStyle.Left;
			this.Panel_Left_Start_Window.Location = new System.Drawing.Point(0, 0);
			this.Panel_Left_Start_Window.Name = "Panel_Left_Start_Window";
			this.Panel_Left_Start_Window.Size = new System.Drawing.Size(462, 449);
			this.Panel_Left_Start_Window.TabIndex = 0;
			// 
			// Picture_AI
			// 
			this.Picture_AI.Image = ((System.Drawing.Image)(resources.GetObject("Picture_AI.Image")));
			this.Picture_AI.Location = new System.Drawing.Point(0, 0);
			this.Picture_AI.Name = "Picture_AI";
			this.Picture_AI.Size = new System.Drawing.Size(459, 449);
			this.Picture_AI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Picture_AI.TabIndex = 0;
			this.Picture_AI.TabStop = false;
			// 
			// Panel_Right_Start_Window
			// 
			this.Panel_Right_Start_Window.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Panel_Right_Start_Window.Controls.Add(this.Label_Error);
			this.Panel_Right_Start_Window.Controls.Add(this.Combo_Box_Details);
			this.Panel_Right_Start_Window.Controls.Add(this.Button_Start_Game);
			this.Panel_Right_Start_Window.Controls.Add(this.Label_Value);
			this.Panel_Right_Start_Window.Controls.Add(this.Label_One);
			this.Panel_Right_Start_Window.Dock = System.Windows.Forms.DockStyle.Right;
			this.Panel_Right_Start_Window.Location = new System.Drawing.Point(459, 0);
			this.Panel_Right_Start_Window.Name = "Panel_Right_Start_Window";
			this.Panel_Right_Start_Window.Size = new System.Drawing.Size(595, 449);
			this.Panel_Right_Start_Window.TabIndex = 1;
			// 
			// Label_Error
			// 
			this.Label_Error.AutoSize = true;
			this.Label_Error.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_Error.Location = new System.Drawing.Point(43, 281);
			this.Label_Error.Name = "Label_Error";
			this.Label_Error.Size = new System.Drawing.Size(175, 27);
			this.Label_Error.TabIndex = 8;
			this.Label_Error.Text = "Error - Message";
			// 
			// Combo_Box_Details
			// 
			this.Combo_Box_Details.BackColor = System.Drawing.Color.White;
			this.Combo_Box_Details.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Combo_Box_Details.Font = new System.Drawing.Font("Baskerville Old Face", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Combo_Box_Details.FormattingEnabled = true;
			this.Combo_Box_Details.Location = new System.Drawing.Point(228, 154);
			this.Combo_Box_Details.Name = "Combo_Box_Details";
			this.Combo_Box_Details.Size = new System.Drawing.Size(138, 26);
			this.Combo_Box_Details.TabIndex = 7;
			this.Combo_Box_Details.Text = "      N x N";
			// 
			// Button_Start_Game
			// 
			this.Button_Start_Game.BackColor = System.Drawing.Color.DodgerBlue;
			this.Button_Start_Game.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Button_Start_Game.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Button_Start_Game.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Button_Start_Game.Font = new System.Drawing.Font("Century", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Button_Start_Game.Location = new System.Drawing.Point(48, 339);
			this.Button_Start_Game.Name = "Button_Start_Game";
			this.Button_Start_Game.Size = new System.Drawing.Size(516, 69);
			this.Button_Start_Game.TabIndex = 5;
			this.Button_Start_Game.Text = "Start Game";
			this.Button_Start_Game.UseVisualStyleBackColor = false;
			this.Button_Start_Game.Click += new System.EventHandler(this.Button_Start_Game_Click);
			// 
			// Label_Value
			// 
			this.Label_Value.AutoSize = true;
			this.Label_Value.Font = new System.Drawing.Font("Baskerville Old Face", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_Value.Location = new System.Drawing.Point(51, 99);
			this.Label_Value.Name = "Label_Value";
			this.Label_Value.Size = new System.Drawing.Size(490, 27);
			this.Label_Value.TabIndex = 1;
			this.Label_Value.Text = "Choose The Length (N x N) Of The Surface  ";
			// 
			// Label_One
			// 
			this.Label_One.AutoSize = true;
			this.Label_One.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Label_One.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_One.Location = new System.Drawing.Point(96, 21);
			this.Label_One.Name = "Label_One";
			this.Label_One.Size = new System.Drawing.Size(386, 42);
			this.Label_One.TabIndex = 0;
			this.Label_One.Text = "Obstacle Board Game";
			this.Label_One.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Start_Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1054, 449);
			this.Controls.Add(this.Panel_Right_Start_Window);
			this.Controls.Add(this.Panel_Left_Start_Window);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Start_Window";
			this.ShowIcon = false;
			this.Text = "Start - Window";
			this.Load += new System.EventHandler(this.Start_Window_Load);
			this.Panel_Left_Start_Window.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Picture_AI)).EndInit();
			this.Panel_Right_Start_Window.ResumeLayout(false);
			this.Panel_Right_Start_Window.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel Panel_Left_Start_Window;
		private System.Windows.Forms.PictureBox Picture_AI;
		private System.Windows.Forms.Panel Panel_Right_Start_Window;
		private System.Windows.Forms.Label Label_Value;
		private System.Windows.Forms.Label Label_One;
		private System.Windows.Forms.Button Button_Start_Game;
		private System.Windows.Forms.ComboBox Combo_Box_Details;
		private System.Windows.Forms.Label Label_Error;
	}
}

