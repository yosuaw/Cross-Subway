namespace Cross_Subway_Student_Challenge
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.labelLoadingPercentage = new System.Windows.Forms.Label();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.timerContinue = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxContinue = new System.Windows.Forms.PictureBox();
            this.timerBlackScreen = new System.Windows.Forms.Timer(this.components);
            this.timerListBoxInfo = new System.Windows.Forms.Timer(this.components);
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.timerTrainRight = new System.Windows.Forms.Timer(this.components);
            this.timerGhost = new System.Windows.Forms.Timer(this.components);
            this.timerBlinkChar = new System.Windows.Forms.Timer(this.components);
            this.timerBlinkGhost = new System.Windows.Forms.Timer(this.components);
            this.timerCollisionTrain = new System.Windows.Forms.Timer(this.components);
            this.timerCollisionGhost = new System.Windows.Forms.Timer(this.components);
            this.timerMoveLeft = new System.Windows.Forms.Timer(this.components);
            this.timerMoveDown = new System.Windows.Forms.Timer(this.components);
            this.timerMoveRight = new System.Windows.Forms.Timer(this.components);
            this.timerMoveUp = new System.Windows.Forms.Timer(this.components);
            this.timerCutScene = new System.Windows.Forms.Timer(this.components);
            this.timerTrainLeft = new System.Windows.Forms.Timer(this.components);
            this.timerTrainMoveLeft = new System.Windows.Forms.Timer(this.components);
            this.timerTrainMoveRight = new System.Windows.Forms.Timer(this.components);
            this.timerWin = new System.Windows.Forms.Timer(this.components);
            this.timerGhostSound = new System.Windows.Forms.Timer(this.components);
            this.timerGameOver = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingBar
            // 
            this.loadingBar.ForeColor = System.Drawing.Color.Goldenrod;
            this.loadingBar.Location = new System.Drawing.Point(69, 742);
            this.loadingBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(1325, 34);
            this.loadingBar.TabIndex = 0;
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.BackColor = System.Drawing.Color.Black;
            this.listBoxInfo.Font = new System.Drawing.Font("Chiller", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxInfo.ForeColor = System.Drawing.Color.White;
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 52;
            this.listBoxInfo.Location = new System.Drawing.Point(328, 82);
            this.listBoxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxInfo.Size = new System.Drawing.Size(795, 472);
            this.listBoxInfo.TabIndex = 1;
            // 
            // labelLoadingPercentage
            // 
            this.labelLoadingPercentage.AutoSize = true;
            this.labelLoadingPercentage.BackColor = System.Drawing.Color.White;
            this.labelLoadingPercentage.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoadingPercentage.Location = new System.Drawing.Point(697, 747);
            this.labelLoadingPercentage.Name = "labelLoadingPercentage";
            this.labelLoadingPercentage.Size = new System.Drawing.Size(28, 24);
            this.labelLoadingPercentage.TabIndex = 2;
            this.labelLoadingPercentage.Text = "0";
            // 
            // timerLoading
            // 
            this.timerLoading.Enabled = true;
            this.timerLoading.Interval = 150;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // timerContinue
            // 
            this.timerContinue.Interval = 800;
            this.timerContinue.Tick += new System.EventHandler(this.timerContinue_Tick);
            // 
            // pictureBoxContinue
            // 
            this.pictureBoxContinue.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxContinue.Image = global::Cross_Subway_Student_Challenge.Properties.Resources.ContinueToGame;
            this.pictureBoxContinue.Location = new System.Drawing.Point(308, 625);
            this.pictureBoxContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxContinue.Name = "pictureBoxContinue";
            this.pictureBoxContinue.Size = new System.Drawing.Size(815, 86);
            this.pictureBoxContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxContinue.TabIndex = 5;
            this.pictureBoxContinue.TabStop = false;
            this.pictureBoxContinue.Visible = false;
            this.pictureBoxContinue.Click += new System.EventHandler(this.pictureBoxContinue_Click);
            this.pictureBoxContinue.MouseEnter += new System.EventHandler(this.pictureBoxContinue_MouseEnter);
            this.pictureBoxContinue.MouseLeave += new System.EventHandler(this.pictureBoxContinue_MouseLeave);
            // 
            // timerBlackScreen
            // 
            this.timerBlackScreen.Interval = 1000;
            this.timerBlackScreen.Tick += new System.EventHandler(this.timerBlackScreen_Tick);
            // 
            // timerListBoxInfo
            // 
            this.timerListBoxInfo.Enabled = true;
            this.timerListBoxInfo.Interval = 5000;
            this.timerListBoxInfo.Tick += new System.EventHandler(this.timerListBoxInfo_Tick);
            // 
            // timerGame
            // 
            this.timerGame.Interval = 40;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // timerTrainRight
            // 
            this.timerTrainRight.Interval = 1000;
            this.timerTrainRight.Tick += new System.EventHandler(this.timerTrainRight_Tick);
            // 
            // timerGhost
            // 
            this.timerGhost.Interval = 250;
            this.timerGhost.Tick += new System.EventHandler(this.timerGhost_Tick);
            // 
            // timerBlinkChar
            // 
            this.timerBlinkChar.Interval = 250;
            this.timerBlinkChar.Tick += new System.EventHandler(this.timerBlinkChar_Tick);
            // 
            // timerBlinkGhost
            // 
            this.timerBlinkGhost.Interval = 250;
            this.timerBlinkGhost.Tick += new System.EventHandler(this.timerBlinkGhost_Tick);
            // 
            // timerCollisionTrain
            // 
            this.timerCollisionTrain.Interval = 250;
            this.timerCollisionTrain.Tick += new System.EventHandler(this.timerCollisionTrain_Tick);
            // 
            // timerCollisionGhost
            // 
            this.timerCollisionGhost.Interval = 250;
            this.timerCollisionGhost.Tick += new System.EventHandler(this.timerCollisionGhost_Tick);
            // 
            // timerMoveLeft
            // 
            this.timerMoveLeft.Interval = 750;
            this.timerMoveLeft.Tick += new System.EventHandler(this.timerMoveLeft_Tick);
            // 
            // timerMoveDown
            // 
            this.timerMoveDown.Interval = 750;
            this.timerMoveDown.Tick += new System.EventHandler(this.timerMoveDown_Tick);
            // 
            // timerMoveRight
            // 
            this.timerMoveRight.Interval = 750;
            this.timerMoveRight.Tick += new System.EventHandler(this.timerMoveRight_Tick);
            // 
            // timerMoveUp
            // 
            this.timerMoveUp.Interval = 750;
            this.timerMoveUp.Tick += new System.EventHandler(this.timerMoveUp_Tick);
            // 
            // timerCutScene
            // 
            this.timerCutScene.Interval = 1500;
            this.timerCutScene.Tick += new System.EventHandler(this.timerCutScene_Tick);
            // 
            // timerTrainLeft
            // 
            this.timerTrainLeft.Interval = 1000;
            this.timerTrainLeft.Tick += new System.EventHandler(this.timerTrainLeft_Tick);
            // 
            // timerTrainMoveLeft
            // 
            this.timerTrainMoveLeft.Interval = 1000;
            this.timerTrainMoveLeft.Tick += new System.EventHandler(this.timerTrainMoveLeft_Tick);
            // 
            // timerTrainMoveRight
            // 
            this.timerTrainMoveRight.Interval = 1000;
            this.timerTrainMoveRight.Tick += new System.EventHandler(this.timerTrainMoveRight_Tick);
            // 
            // timerWin
            // 
            this.timerWin.Interval = 250;
            this.timerWin.Tick += new System.EventHandler(this.timerWin_Tick);
            // 
            // timerGhostSound
            // 
            this.timerGhostSound.Interval = 15000;
            this.timerGhostSound.Tick += new System.EventHandler(this.timerGhostSound_Tick);
            // 
            // timerGameOver
            // 
            this.timerGameOver.Interval = 200;
            this.timerGameOver.Tick += new System.EventHandler(this.timerGameOver_Tick);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Cross_Subway_Student_Challenge.Properties.Resources.How_to_play;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1445, 814);
            this.Controls.Add(this.pictureBoxContinue);
            this.Controls.Add(this.labelLoadingPercentage);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.loadingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cross Subway";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGame_FormClosed);
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Label labelLoadingPercentage;
        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.Timer timerContinue;
        private System.Windows.Forms.PictureBox pictureBoxContinue;
        private System.Windows.Forms.Timer timerBlackScreen;
        private System.Windows.Forms.Timer timerListBoxInfo;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Timer timerTrainRight;
        private System.Windows.Forms.Timer timerGhost;
        private System.Windows.Forms.Timer timerBlinkGhost;
        private System.Windows.Forms.Timer timerCollisionTrain;
        private System.Windows.Forms.Timer timerCollisionGhost;
        private System.Windows.Forms.Timer timerMoveLeft;
        private System.Windows.Forms.Timer timerMoveDown;
        private System.Windows.Forms.Timer timerMoveRight;
        private System.Windows.Forms.Timer timerMoveUp;
        private System.Windows.Forms.Timer timerCutScene;
        private System.Windows.Forms.Timer timerTrainLeft;
        private System.Windows.Forms.Timer timerTrainMoveLeft;
        private System.Windows.Forms.Timer timerTrainMoveRight;
        private System.Windows.Forms.Timer timerWin;
        private System.Windows.Forms.Timer timerBlinkChar;
        private System.Windows.Forms.Timer timerGhostSound;
        private System.Windows.Forms.Timer timerGameOver;
    }
}