namespace Cross_Subway_Student_Challenge
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.labelPlay = new System.Windows.Forms.Label();
            this.labelHowToPlay = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.labelHighScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxBackground.Image = global::Cross_Subway_Student_Challenge.Properties.Resources.Menu;
            this.pictureBoxBackground.Location = new System.Drawing.Point(-1, -5);
            this.pictureBoxBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(1451, 827);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 0;
            this.pictureBoxBackground.TabStop = false;
            // 
            // labelPlay
            // 
            this.labelPlay.AutoSize = true;
            this.labelPlay.BackColor = System.Drawing.Color.Transparent;
            this.labelPlay.Font = new System.Drawing.Font("Chiller", 60F, System.Drawing.FontStyle.Bold);
            this.labelPlay.ForeColor = System.Drawing.Color.White;
            this.labelPlay.Location = new System.Drawing.Point(591, 405);
            this.labelPlay.Name = "labelPlay";
            this.labelPlay.Size = new System.Drawing.Size(224, 116);
            this.labelPlay.TabIndex = 1;
            this.labelPlay.Text = "PLAY";
            this.labelPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPlay.Click += new System.EventHandler(this.labelPlay_Click);
            this.labelPlay.MouseEnter += new System.EventHandler(this.labelPlay_MouseEnter);
            this.labelPlay.MouseLeave += new System.EventHandler(this.labelPlay_MouseLeave);
            // 
            // labelHowToPlay
            // 
            this.labelHowToPlay.AutoSize = true;
            this.labelHowToPlay.BackColor = System.Drawing.Color.Transparent;
            this.labelHowToPlay.Font = new System.Drawing.Font("Chiller", 35F, System.Drawing.FontStyle.Bold);
            this.labelHowToPlay.ForeColor = System.Drawing.Color.White;
            this.labelHowToPlay.Location = new System.Drawing.Point(544, 556);
            this.labelHowToPlay.Name = "labelHowToPlay";
            this.labelHowToPlay.Size = new System.Drawing.Size(311, 69);
            this.labelHowToPlay.TabIndex = 2;
            this.labelHowToPlay.Text = "HOW TO PLAY";
            this.labelHowToPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHowToPlay.Click += new System.EventHandler(this.labelHowToPlay_Click);
            this.labelHowToPlay.MouseEnter += new System.EventHandler(this.labelHowToPlay_MouseEnter);
            this.labelHowToPlay.MouseLeave += new System.EventHandler(this.labelHowToPlay_MouseLeave);
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.BackColor = System.Drawing.Color.Transparent;
            this.labelExit.Font = new System.Drawing.Font("Chiller", 35F, System.Drawing.FontStyle.Bold);
            this.labelExit.ForeColor = System.Drawing.Color.White;
            this.labelExit.Location = new System.Drawing.Point(637, 682);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(123, 78);
            this.labelExit.TabIndex = 3;
            this.labelExit.Text = "EXIT";
            this.labelExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelExit.UseCompatibleTextRendering = true;
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            this.labelExit.MouseEnter += new System.EventHandler(this.labelExit_MouseEnter);
            this.labelExit.MouseLeave += new System.EventHandler(this.labelExit_MouseLeave);
            // 
            // timerPlay
            // 
            this.timerPlay.Interval = 200;
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.BackColor = System.Drawing.Color.Transparent;
            this.labelHighScore.Font = new System.Drawing.Font("Chiller", 18F, System.Drawing.FontStyle.Bold);
            this.labelHighScore.ForeColor = System.Drawing.Color.Red;
            this.labelHighScore.Location = new System.Drawing.Point(556, 9);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(102, 42);
            this.labelHighScore.TabIndex = 4;
            this.labelHighScore.Text = "HighScore";
            this.labelHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHighScore.UseCompatibleTextRendering = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1445, 814);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.labelHowToPlay);
            this.Controls.Add(this.labelPlay);
            this.Controls.Add(this.pictureBoxBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cross Subway";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Label labelPlay;
        private System.Windows.Forms.Label labelHowToPlay;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.Label labelHighScore;
    }
}

