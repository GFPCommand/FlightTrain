namespace FlightTrain
{
    partial class Form1
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
            this.enemy1 = new System.Windows.Forms.Button();
            this.enemy2 = new System.Windows.Forms.Button();
            this.enemy3 = new System.Windows.Forms.Button();
            this.player = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.StartLoseLabel = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enemy1
            // 
            this.enemy1.BackColor = System.Drawing.Color.Red;
            this.enemy1.Enabled = false;
            this.enemy1.Location = new System.Drawing.Point(12, 12);
            this.enemy1.Name = "enemy1";
            this.enemy1.Size = new System.Drawing.Size(40, 40);
            this.enemy1.TabIndex = 0;
            this.enemy1.Text = "1";
            this.enemy1.UseVisualStyleBackColor = false;
            this.enemy1.Visible = false;
            // 
            // enemy2
            // 
            this.enemy2.BackColor = System.Drawing.Color.Red;
            this.enemy2.Enabled = false;
            this.enemy2.Location = new System.Drawing.Point(58, 12);
            this.enemy2.Name = "enemy2";
            this.enemy2.Size = new System.Drawing.Size(40, 40);
            this.enemy2.TabIndex = 1;
            this.enemy2.Text = "2";
            this.enemy2.UseVisualStyleBackColor = false;
            this.enemy2.Visible = false;
            // 
            // enemy3
            // 
            this.enemy3.BackColor = System.Drawing.Color.Red;
            this.enemy3.Enabled = false;
            this.enemy3.Location = new System.Drawing.Point(104, 12);
            this.enemy3.Name = "enemy3";
            this.enemy3.Size = new System.Drawing.Size(40, 40);
            this.enemy3.TabIndex = 2;
            this.enemy3.Text = "3";
            this.enemy3.UseVisualStyleBackColor = false;
            this.enemy3.Visible = false;
            // 
            // player
            // 
            this.player.Location = new System.Drawing.Point(150, 12);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(40, 40);
            this.player.TabIndex = 3;
            this.player.UseVisualStyleBackColor = true;
            this.player.Visible = false;
            this.player.MouseDown += new System.Windows.Forms.MouseEventHandler(this.player_MouseDown);
            this.player.MouseMove += new System.Windows.Forms.MouseEventHandler(this.player_MouseMove);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Silver;
            this.panel.Controls.Add(this.time);
            this.panel.Controls.Add(this.exit);
            this.panel.Controls.Add(this.start);
            this.panel.Controls.Add(this.StartLoseLabel);
            this.panel.Location = new System.Drawing.Point(60, 80);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(360, 210);
            this.panel.TabIndex = 4;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.time.Location = new System.Drawing.Point(125, 60);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 21);
            this.time.TabIndex = 3;
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exit.Location = new System.Drawing.Point(113, 140);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(127, 40);
            this.exit.TabIndex = 2;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start.Location = new System.Drawing.Point(113, 94);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(127, 40);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.ShowHideMenu);
            // 
            // StartLoseLabel
            // 
            this.StartLoseLabel.AutoSize = true;
            this.StartLoseLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartLoseLabel.Location = new System.Drawing.Point(104, 17);
            this.StartLoseLabel.Name = "StartLoseLabel";
            this.StartLoseLabel.Size = new System.Drawing.Size(145, 37);
            this.StartLoseLabel.TabIndex = 0;
            this.StartLoseLabel.Text = "Start game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.player);
            this.Controls.Add(this.enemy3);
            this.Controls.Add(this.enemy2);
            this.Controls.Add(this.enemy1);
            this.Name = "Form1";
            this.Text = "FlightTrain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button enemy1;
        private Button enemy2;
        private Button enemy3;
        private Button player;
        private Panel panel;
        private Button exit;
        private Button start;
        private Label StartLoseLabel;
        private Label time;
    }
}