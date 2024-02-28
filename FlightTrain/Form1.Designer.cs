namespace FlightTrain
{
    partial class SpeedTrainingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			player = new Button();
			panel = new Panel();
			time = new Label();
			exit = new Button();
			start = new Button();
			StartLoseLabel = new Label();
			panel.SuspendLayout();
			SuspendLayout();
			// 
			// player
			// 
			player.Location = new Point(12, 12);
			player.Name = "player";
			player.Size = new Size(40, 40);
			player.TabIndex = 3;
			player.UseVisualStyleBackColor = true;
			player.Visible = false;
			player.MouseDown += player_MouseDown;
			player.MouseMove += player_MouseMove;
			// 
			// panel
			// 
			panel.BackColor = Color.Silver;
			panel.Controls.Add(time);
			panel.Controls.Add(exit);
			panel.Controls.Add(start);
			panel.Controls.Add(StartLoseLabel);
			panel.Location = new Point(60, 80);
			panel.Name = "panel";
			panel.Size = new Size(360, 210);
			panel.TabIndex = 4;
			// 
			// time
			// 
			time.AutoSize = true;
			time.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			time.Location = new Point(125, 60);
			time.Name = "time";
			time.Size = new Size(0, 21);
			time.TabIndex = 3;
			// 
			// exit
			// 
			exit.Font = new Font("Microsoft YaHei", 16F, FontStyle.Regular, GraphicsUnit.Point);
			exit.Location = new Point(113, 140);
			exit.Name = "exit";
			exit.Size = new Size(127, 40);
			exit.TabIndex = 2;
			exit.Text = "Выход";
			exit.UseVisualStyleBackColor = true;
			exit.Click += exit_Click;
			// 
			// start
			// 
			start.Font = new Font("Microsoft YaHei", 16F, FontStyle.Regular, GraphicsUnit.Point);
			start.Location = new Point(113, 94);
			start.Name = "start";
			start.Size = new Size(127, 40);
			start.TabIndex = 1;
			start.Text = "Старт";
			start.UseVisualStyleBackColor = true;
			start.Click += ShowHideMenu;
			// 
			// StartLoseLabel
			// 
			StartLoseLabel.AutoSize = true;
			StartLoseLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
			StartLoseLabel.Location = new Point(104, 17);
			StartLoseLabel.Name = "StartLoseLabel";
			StartLoseLabel.Size = new Size(166, 37);
			StartLoseLabel.TabIndex = 0;
			StartLoseLabel.Text = "Начать игру";
			// 
			// SpeedTrainingForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(500, 500);
			Controls.Add(panel);
			Controls.Add(player);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SpeedTrainingForm";
			Text = "FlightTrain";
			Load += Form1_Load;
			panel.ResumeLayout(false);
			panel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private Button player;
        private Panel panel;
        private Button exit;
        private Button start;
        private Label StartLoseLabel;
        private Label time;
    }
}