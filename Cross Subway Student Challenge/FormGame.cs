using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using Cross_Subway_Student_Challenge.Properties;

namespace Cross_Subway_Student_Challenge
{

    public partial class FormGame : Form
    {
        FormMenu formMenu = null;

        Random generator = new Random();

        string resourcePath = Application.StartupPath + "\\Resources\\";

        WindowsMediaPlayer loopSound = new WindowsMediaPlayer();
        WindowsMediaPlayer loopSound2 = new WindowsMediaPlayer();
        WindowsMediaPlayer normalSound = new WindowsMediaPlayer();
        WindowsMediaPlayer normalSound2 = new WindowsMediaPlayer();
        WindowsMediaPlayer ghostSound = new WindowsMediaPlayer();

        ProgressBar progressBarHealth = new ProgressBar();

        List<PictureBox> listOfTrainRight = new List<PictureBox>();
        List<PictureBox> listOfTrainLeft = new List<PictureBox>();
        List<Label> listOfLabelTrainRight = new List<Label>();
        List<Label> listOfLabelTrainLeft = new List<Label>();
        ListBox listBoxDialog = new ListBox();

        Label labelIncident = new Label();
        Label labelPause = new Label();
        Label labelScore = new Label();
        Label labelHighScore = new Label();
        Label labelHP = new Label();
        Label labelChar = new Label();
        Label labelThresholdTop = new Label();
        Label labelLeftStairRight = new Label();
        Label labelLeftStairLeft = new Label();
        Label labelRightStairLeft = new Label();
        Label labelRightStairRight = new Label();

        PictureBox pictureBoxCharDialog = new PictureBox();
        PictureBox pictureBoxGhostDialog = new PictureBox();
        PictureBox pictureBoxChar = new PictureBox();
        PictureBox pictureBoxGhost = new PictureBox();
        PictureBox pictBoxArrowClip = new PictureBox();
        PictureBox pictBoxMenu = new PictureBox();
        PictureBox pictBoxRestart = new PictureBox();
        PictureBox pictBoxResume = new PictureBox();
        PictureBox pictureBoxBlack = new PictureBox();
        PictureBox pictureBoxGameOver = new PictureBox();

        const int MAX_USER_LIVES = 100;
        const int MAX_NUMBER_OF_TRAIN = 3;
        const int charMove = 2;

        int userScore = 0;
        int listBoxInfoLine = 1;
        int blackScreenTime = 4;
        int cutSceneTime = 18;
        int cutScene = 1;
        int listBoxDialogLine = 1;
        int timeCollision = 8;
        int step = 0;
        int indexMoveLeftChar = 0;
        int indexMoveRightChar = 0;
        int indexMoveUpChar = 0;
        int indexMoveDownChar = 0;
        int indexMoveGhost = 0;
        int indexmoveLeftTrain = 0;
        int indexmoveRightTrain = 0;
        int randomTrainRight = 1;
        int randomTrainLeft = 1;
        int blackScreenWin = 4;
        int gameOver = 15;

        bool collisionTrain = false;
        bool collisionGhost = false;

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.Owner;

            normalSound2.URL = resourcePath + "Typecasting.mp3";

            this.KeyDown -= FormGame_KeyDown;
            this.KeyUp -= FormGame_KeyUp;
            this.DoubleBuffered = true;
        }


        private void timerListBoxInfo_Tick(object sender, EventArgs e)
        {
            normalSound2.URL = resourcePath + "Typecasting.mp3";
            switch (listBoxInfoLine)
            {
                case 1:
                    listBoxInfo.Items.Add("Friday, 13 October 1899");
                    break;
                case 2:
                    listBoxInfo.Items.Add("Adam and his family went to Garnet, United States.");
                    break;
                case 3:
                    listBoxInfo.Items.Add("On the way to Garnet,");
                    break;
                case 4:
                    listBoxInfo.Items.Add("The train that they ride on suddenly got malfunction.");
                    break;
                case 5:
                    listBoxInfo.Items.Add("And then the train got crashed....");
                    normalSound.close();
                    timerListBoxInfo.Enabled = false;
                    break;
            }
            listBoxInfoLine++;
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            this.loadingBar.Increment(1);
            labelLoadingPercentage.Text = loadingBar.Value.ToString() + "%";
            if (loadingBar.Value == 60)
            {
                labelLoadingPercentage.BackColor = Color.ForestGreen;
            }
            else if (loadingBar.Value == 100)
            {
                timerLoading.Enabled = false;
                timerContinue.Enabled = true;
                pictureBoxContinue.Visible = true;
            }
        }

        private void timerContinue_Tick(object sender, EventArgs e)
        {
            if (pictureBoxContinue.Visible)
            {
                pictureBoxContinue.Visible = false;
            }
            else
            {
                pictureBoxContinue.Visible = true;
            }
        }

        private void pictureBoxContinue_Click(object sender, EventArgs e)
        {
            timerListBoxInfo.Enabled = false;
            timerContinue.Enabled = false;
            pictureBoxContinue.MouseLeave -= pictureBoxContinue_MouseLeave;
            listBoxInfo.Dispose();
            pictureBoxContinue.Dispose();
            loadingBar.Dispose();
            labelLoadingPercentage.Dispose();
            normalSound2.close();
            timerBlackScreen.Enabled = true;
        }

        private void pictureBoxContinue_MouseEnter(object sender, EventArgs e)
        {
            timerContinue.Enabled = false;
            pictureBoxContinue.Visible = true;
            normalSound.URL = resourcePath + "Click.mp3";
        }

        private void pictureBoxContinue_MouseLeave(object sender, EventArgs e)
        {
            timerContinue.Enabled = true;
        }

        private void timerBlackScreen_Tick(object sender, EventArgs e)
        {
            if (blackScreenTime > 0)
            {
                blackScreenTime--;
                this.BackgroundImage = null;
                if (blackScreenTime == 3)
                {
                    labelIncident.Top = 290;
                    labelIncident.Left = 315;
                    labelIncident.AutoSize = true;
                    labelIncident.Text = "After the incident...";
                    labelIncident.Font = new Font("Papyrus", 40, FontStyle.Bold);
                    labelIncident.ForeColor = Color.White;
                    labelIncident.BackColor = Color.Transparent;
                    this.Controls.Add(labelIncident);
                }
            }
            else
            {
                timerBlackScreen.Enabled = false;
                timerCutScene.Enabled = true;
                blackScreenTime = 4;
                labelIncident.Dispose();
                this.BackgroundImage = Properties.Resources.RealMap;

                pictureBoxChar.BackColor = Color.Transparent;
                pictureBoxChar.Image = Properties.Resources.CharHurt;
                pictureBoxChar.Height = 60;
                pictureBoxChar.Width = 41;
                pictureBoxChar.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxChar.Left = 510;
                pictureBoxChar.Top = 510;
                Controls.Add(pictureBoxChar);

                labelChar.BackColor = Color.Transparent;
                labelChar.Top = 474;
                labelChar.Left = 514;
                labelChar.AutoSize = false;
                labelChar.Height = 5;
                labelChar.Width = 30;
                Controls.Add(labelChar);
            }
        }

        private void timerCutScene_Tick(object sender, EventArgs e)
        {
            switch (cutScene)
            {
                case 1:
                    pictureBoxChar.Image = Properties.Resources.CharMovesDown;
                    break;
                case 2:
                    pictureBoxChar.Image = Properties.Resources.CharMovesUp;
                    break;
                case 3:
                    if (cutSceneTime > 0)
                    {
                        timerMoveUp.Enabled = true;
                        timerCutScene.Interval = 150;
                        cutSceneTime -= 1;
                        pictureBoxChar.Top -= 5;
                        cutScene--;
                    }
                    else
                    {
                        timerMoveUp.Enabled = false;
                        timerCutScene.Interval = 1500;
                        pictureBoxChar.Image = Properties.Resources.CharMovesUp;
                    }
                    break;
                case 4:
                    pictureBoxChar.Image = Properties.Resources.CharMovesLeft;
                    break;
                case 5:
                    pictureBoxChar.Image = Properties.Resources.CharMovesRight;
                    break;
                case 6:
                    pictureBoxChar.Image = Properties.Resources.CharMovesUp;
                    break;
                case 7:
                    timerCutScene.Enabled = false;
                    pictBoxArrowClip.Image = Properties.Resources.Arrow;
                    pictBoxArrowClip.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictBoxArrowClip.Width = 30;
                    pictBoxArrowClip.Height = 15;
                    pictBoxArrowClip.Top = 620;
                    pictBoxArrowClip.Left = 950;
                    pictBoxArrowClip.BackColor = Color.Black;
                    pictBoxArrowClip.BringToFront();
                    Controls.Add(pictBoxArrowClip);

                    listBoxDialog.SelectionMode = SelectionMode.None;
                    listBoxDialog.Font = new Font("Corbel", 18, FontStyle.Regular);
                    listBoxDialog.BackColor = Color.Black;
                    listBoxDialog.ForeColor = Color.GhostWhite;
                    listBoxDialog.Width = 900;
                    listBoxDialog.Height = 108;
                    listBoxDialog.Top = 550;
                    listBoxDialog.Left = 90;
                    listBoxDialog.SendToBack();
                    Controls.Add(listBoxDialog);
                    listBoxDialog.Items.Add("Arrghh... Where am I?");
                    listBoxDialog.Click += new System.EventHandler(this.listBoxDialog_Click);
                    listBoxDialog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxDialog_KeyDown);
                    listBoxDialog.Focus();

                    pictureBoxCharDialog.Image = Properties.Resources.CharLooking;
                    pictureBoxCharDialog.BackColor = Color.Transparent;
                    pictureBoxCharDialog.Width = 180;
                    pictureBoxCharDialog.Height = 180;
                    pictureBoxCharDialog.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxCharDialog.Top = 393;
                    pictureBoxCharDialog.Left = 803;
                    Controls.Add(pictureBoxCharDialog);
                    break;
            }
            cutScene++;
        }

        private void listBoxDialog_Click(object sender, EventArgs e)
        {
            listBoxDialog.Items.Clear();
            normalSound.URL = resourcePath + "Click.mp3";
            switch (listBoxDialogLine)
            {
                case 1:
                    listBoxDialog.Items.Add("Mom..... Dad..... Where are you? I'm scared!");
                    break;
                case 2:
                    listBoxDialog.Items.Add("Is there anyone here? Please help me.");
                    break;
                case 3:
                    listBoxDialog.Items.Add("*checking phone......*");
                    break;
                case 4:
                    pictureBoxCharDialog.Image = Properties.Resources.CharAngry;
                    listBoxDialog.Items.Add("Arrghh........");
                    listBoxDialog.Items.Add("There is no signal here.");
                    break;
                case 5:
                    pictureBoxGhostDialog.Image = Properties.Resources.Ghost;
                    pictureBoxGhostDialog.BackColor = Color.Transparent;
                    pictureBoxGhostDialog.Width = 180;
                    pictureBoxGhostDialog.Height = 180;
                    pictureBoxGhostDialog.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxGhostDialog.Top = 393;
                    pictureBoxGhostDialog.Left = 90;
                    Controls.Add(pictureBoxGhostDialog);
                    pictureBoxCharDialog.Image = Properties.Resources.CharAngryDark;
                    listBoxDialog.Items.Add("*strange sound......*");
                    normalSound.URL = resourcePath + "GhostSound.mp3";
                    normalSound.settings.volume = 50;
                    break;
                case 6:
                    pictureBoxCharDialog.Image = Properties.Resources.CharLooking;
                    pictureBoxGhostDialog.Image = Properties.Resources.GhostDark;
                    pictureBoxChar.Image = Properties.Resources.CharMovesDown;
                    normalSound.close();
                    normalSound.settings.volume = 100;
                    listBoxDialog.Items.Add("What is that sound?");
                    listBoxDialog.Items.Add("*looking to where the noise come from.*");
                    break;
                case 7:
                    pictureBoxCharDialog.Image = Properties.Resources.CharShock;
                    listBoxDialog.Font = new Font("Informal Roman", 36, FontStyle.Italic);
                    listBoxDialog.Items.Add("Arrghh.......");
                    break;
                case 8:
                    timerGame.Enabled = true;
                    timerGhost.Enabled = true;
                    timerGhostSound.Enabled = true;
                    //timerTrainMoveLeft.Enabled = true;
                    //timerTrainMoveRight.Enabled = true;

                    listBoxDialog.Dispose();
                    pictureBoxCharDialog.Dispose();
                    pictureBoxGhostDialog.Dispose();
                    pictBoxArrowClip.Dispose();
                    this.KeyDown += FormGame_KeyDown;
                    this.KeyUp += FormGame_KeyUp;

                    loopSound.URL = resourcePath + "InGame SoundTrack.mp3";
                    loopSound.settings.setMode("loop", true);
                    loopSound.settings.volume = 30;
                    loopSound2.URL = resourcePath + "TrainMoveSound.mp3";
                    loopSound2.settings.setMode("loop", true);
                    loopSound2.settings.volume = 80;

                    labelPause.Text = "||";
                    labelPause.AutoSize = true;
                    labelPause.TextAlign = ContentAlignment.TopCenter;
                    labelPause.Font = new Font("Comic Sans MS", 19, FontStyle.Bold);
                    labelPause.BackColor = Color.Silver;
                    labelPause.ForeColor = Color.Red;
                    labelPause.Width = 44;
                    labelPause.Height = 36;
                    labelPause.Top = 12;
                    labelPause.Left = 12;
                    Controls.Add(labelPause);
                    labelPause.Click += new System.EventHandler(this.labelPause_Click);

                    labelHP.ForeColor = Color.White;
                    labelHP.Top = 20;
                    labelHP.Left = 65;
                    labelHP.Font = new Font("Forte", 14, FontStyle.Bold);
                    labelHP.AutoSize = true;
                    labelHP.Text = "HP";
                    labelHP.BackColor = Color.Transparent;
                    Controls.Add(labelHP);

                    progressBarHealth.Value = MAX_USER_LIVES;
                    progressBarHealth.ForeColor = Color.Red;
                    progressBarHealth.Maximum = 100;
                    progressBarHealth.Minimum = 0;
                    progressBarHealth.Top = 18;
                    progressBarHealth.Left = 105;
                    progressBarHealth.Width = 202;
                    progressBarHealth.Height = 25;
                    Controls.Add(progressBarHealth);

                    labelHighScore.ForeColor = Color.FromArgb(255, 192, 64, 0);
                    labelHighScore.Top = 12;
                    labelHighScore.Left = 505;
                    labelHighScore.Font = new Font("Franklin Gothic", 20, FontStyle.Regular);
                    labelHighScore.AutoSize = true;
                    labelHighScore.Text = "HI: " + Settings.Default["highScore"].ToString();
                    labelHighScore.BackColor = Color.Transparent;
                    Controls.Add(labelHighScore);

                    labelScore.ForeColor = Color.FromArgb(255, 192, 64, 0);
                    labelScore.Top = 12;
                    labelScore.Left = 800;
                    labelScore.Font = new Font("Franklin Gothic", 20, FontStyle.Regular);
                    labelScore.AutoSize = true;
                    labelScore.BackColor = Color.Transparent;
                    Controls.Add(labelScore);

                    labelThresholdTop.BackColor = Color.Transparent;
                    labelThresholdTop.AutoSize = false;
                    labelThresholdTop.Top = 80;
                    labelThresholdTop.Left = 0;
                    labelThresholdTop.Height = 1;
                    labelThresholdTop.Width = this.ClientSize.Width;
                    Controls.Add(labelThresholdTop);

                    labelLeftStairRight.BackColor = Color.Transparent;
                    labelLeftStairRight.AutoSize = false;
                    labelLeftStairRight.Top = 80;
                    labelLeftStairRight.Left = 80;
                    labelLeftStairRight.Height = 36;
                    labelLeftStairRight.Width = 1;
                    Controls.Add(labelLeftStairRight);

                    labelRightStairLeft.BackColor = Color.Transparent;
                    labelRightStairLeft.AutoSize = false;
                    labelRightStairLeft.Top = 80;
                    labelRightStairLeft.Left = 1000;
                    labelRightStairLeft.Height = 36;
                    labelRightStairLeft.Width = 1;
                    Controls.Add(labelRightStairLeft);

                    labelLeftStairLeft.BackColor = Color.Transparent;
                    labelLeftStairLeft.AutoSize = false;
                    labelLeftStairLeft.Top = 170;
                    labelLeftStairLeft.Left = 0;
                    labelLeftStairLeft.Height = 18;
                    labelLeftStairLeft.Width = 80;
                    Controls.Add(labelLeftStairLeft);

                    labelRightStairRight.BackColor = Color.Transparent;
                    labelRightStairRight.AutoSize = false;
                    labelRightStairRight.Top = 170;
                    labelRightStairRight.Left = 996;
                    labelRightStairRight.Height = 18;
                    labelRightStairRight.Width = 80;
                    Controls.Add(labelRightStairRight);

                    pictureBoxGhost.BackColor = Color.Transparent;
                    pictureBoxGhost.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxGhost.Image = Properties.Resources.GhostMovesUp;
                    pictureBoxGhost.Height = 60;
                    pictureBoxGhost.Width = 41;
                    pictureBoxGhost.Top = 580;
                    pictureBoxGhost.Left = 510;
                    Controls.Add(pictureBoxGhost);
                    break;
            }
            listBoxDialogLine++;
        }

        private void listBoxDialog_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    listBoxDialog.Items.Clear();
                    normalSound.URL = resourcePath + "Click.mp3";
                    switch (listBoxDialogLine)
                    {
                        case 1:
                            listBoxDialog.Items.Add("Mom..... Dad..... Where are you? I'm scared!");
                            break;
                        case 2:
                            listBoxDialog.Items.Add("Is there anyone here? Please help me.");
                            break;
                        case 3:
                            listBoxDialog.Items.Add("*checking phone......*");
                            break;
                        case 4:
                            pictureBoxCharDialog.Image = Properties.Resources.CharAngry;
                            listBoxDialog.Items.Add("Arrghh........");
                            listBoxDialog.Items.Add("There is no signal here.");
                            break;
                        case 5:
                            pictureBoxGhostDialog.Image = Properties.Resources.Ghost;
                            pictureBoxGhostDialog.BackColor = Color.Transparent;
                            pictureBoxGhostDialog.Width = 180;
                            pictureBoxGhostDialog.Height = 180;
                            pictureBoxGhostDialog.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBoxGhostDialog.Top = 393;
                            pictureBoxGhostDialog.Left = 90;
                            Controls.Add(pictureBoxGhostDialog);
                            pictureBoxCharDialog.Image = Properties.Resources.CharAngryDark;
                            listBoxDialog.Items.Add("*strange sound......*");
                            normalSound.URL = resourcePath + "GhostSound.mp3";
                            normalSound.settings.volume = 50;
                            break;
                        case 6:
                            pictureBoxCharDialog.Image = Properties.Resources.CharLooking;
                            pictureBoxGhostDialog.Image = Properties.Resources.GhostDark;
                            pictureBoxChar.Image = Properties.Resources.CharMovesDown;
                            normalSound.close();
                            normalSound.settings.volume = 100;
                            listBoxDialog.Items.Add("What is that sound?");
                            listBoxDialog.Items.Add("*looking to where the noise come from.*");
                            break;
                        case 7:
                            pictureBoxCharDialog.Image = Properties.Resources.CharShock;
                            listBoxDialog.Font = new Font("Informal Roman", 36, FontStyle.Italic);
                            listBoxDialog.Items.Add("Arrghh.......");
                            break;
                        case 8:
                            timerGame.Enabled = true;
                            timerGhost.Enabled = true;
                            timerGhostSound.Enabled = true;
                            //timerTrainMoveLeft.Enabled = true;
                            //timerTrainMoveRight.Enabled = true;

                            listBoxDialog.Dispose();
                            pictureBoxCharDialog.Dispose();
                            pictureBoxGhostDialog.Dispose();
                            pictBoxArrowClip.Dispose();
                            this.KeyDown += FormGame_KeyDown;
                            this.KeyUp += FormGame_KeyUp;

                            loopSound.URL = resourcePath + "InGame SoundTrack.mp3";
                            loopSound.settings.setMode("loop", true);
                            loopSound.settings.volume = 30;
                            loopSound2.URL = resourcePath + "TrainMoveSound.mp3";
                            loopSound2.settings.setMode("loop", true);
                            loopSound2.settings.volume = 80;

                            labelPause.Text = "||";
                            labelPause.AutoSize = true;
                            labelPause.TextAlign = ContentAlignment.TopCenter;
                            labelPause.Font = new Font("Comic Sans MS", 19, FontStyle.Bold);
                            labelPause.BackColor = Color.Silver;
                            labelPause.ForeColor = Color.Red;
                            labelPause.Width = 44;
                            labelPause.Height = 36;
                            labelPause.Top = 12;
                            labelPause.Left = 12;
                            Controls.Add(labelPause);
                            labelPause.Click += new System.EventHandler(this.labelPause_Click);

                            labelHP.ForeColor = Color.White;
                            labelHP.Top = 20;
                            labelHP.Left = 65;
                            labelHP.Font = new Font("Forte", 14, FontStyle.Bold);
                            labelHP.AutoSize = true;
                            labelHP.Text = "HP";
                            labelHP.BackColor = Color.Transparent;
                            Controls.Add(labelHP);

                            progressBarHealth.Value = MAX_USER_LIVES;
                            progressBarHealth.ForeColor = Color.Red;
                            progressBarHealth.Maximum = 100;
                            progressBarHealth.Minimum = 0;
                            progressBarHealth.Top = 18;
                            progressBarHealth.Left = 105;
                            progressBarHealth.Width = 202;
                            progressBarHealth.Height = 25;
                            Controls.Add(progressBarHealth);

                            labelHighScore.ForeColor = Color.FromArgb(255, 192, 64, 0);
                            labelHighScore.Top = 12;
                            labelHighScore.Left = 505;
                            labelHighScore.Font = new Font("Franklin Gothic", 20, FontStyle.Regular);
                            labelHighScore.AutoSize = true;
                            labelHighScore.Text = "HI: " + Settings.Default["highScore"].ToString();
                            labelHighScore.BackColor = Color.Transparent;
                            Controls.Add(labelHighScore);

                            labelScore.ForeColor = Color.FromArgb(255, 192, 64, 0);
                            labelScore.Top = 12;
                            labelScore.Left = 800;
                            labelScore.Font = new Font("Franklin Gothic", 20, FontStyle.Regular);
                            labelScore.AutoSize = true;
                            labelScore.BackColor = Color.Transparent;
                            Controls.Add(labelScore);

                            labelThresholdTop.BackColor = Color.Transparent;
                            labelThresholdTop.AutoSize = false;
                            labelThresholdTop.Top = 80;
                            labelThresholdTop.Left = 0;
                            labelThresholdTop.Height = 1;
                            labelThresholdTop.Width = this.ClientSize.Width;
                            Controls.Add(labelThresholdTop);

                            labelLeftStairRight.BackColor = Color.Transparent;
                            labelLeftStairRight.AutoSize = false;
                            labelLeftStairRight.Top = 80;
                            labelLeftStairRight.Left = 80;
                            labelLeftStairRight.Height = 36;
                            labelLeftStairRight.Width = 1;
                            Controls.Add(labelLeftStairRight);

                            labelRightStairLeft.BackColor = Color.Transparent;
                            labelRightStairLeft.AutoSize = false;
                            labelRightStairLeft.Top = 80;
                            labelRightStairLeft.Left = 1000;
                            labelRightStairLeft.Height = 36;
                            labelRightStairLeft.Width = 1;
                            Controls.Add(labelRightStairLeft);

                            labelLeftStairLeft.BackColor = Color.Transparent;
                            labelLeftStairLeft.AutoSize = false;
                            labelLeftStairLeft.Top = 170;
                            labelLeftStairLeft.Left = 0;
                            labelLeftStairLeft.Height = 18;
                            labelLeftStairLeft.Width = 80;
                            Controls.Add(labelLeftStairLeft);

                            labelRightStairRight.BackColor = Color.Transparent;
                            labelRightStairRight.AutoSize = false;
                            labelRightStairRight.Top = 170;
                            labelRightStairRight.Left = 996;
                            labelRightStairRight.Height = 18;
                            labelRightStairRight.Width = 80;
                            Controls.Add(labelRightStairRight);

                            pictureBoxGhost.BackColor = Color.Transparent;
                            pictureBoxGhost.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBoxGhost.Image = Properties.Resources.GhostMovesUp;
                            pictureBoxGhost.Height = 60;
                            pictureBoxGhost.Width = 41;
                            pictureBoxGhost.Top = 580;
                            pictureBoxGhost.Left = 510;
                            Controls.Add(pictureBoxGhost);
                            break;
                    }
                    listBoxDialogLine++;
                    break;
            }
        }

        private void labelPause_Click(object sender, EventArgs e)
        {
            pictBoxResume.Image = Properties.Resources.ButtonResume;
            pictBoxResume.SizeMode = PictureBoxSizeMode.StretchImage;
            pictBoxResume.Width = 224;
            pictBoxResume.Height = 116;
            pictBoxResume.Top = 160;
            pictBoxResume.Left = 440;
            pictBoxResume.BackColor = Color.Transparent;
            pictBoxResume.BringToFront();
            this.Controls.Add(pictBoxResume);
            pictBoxResume.Visible = true;
            pictBoxResume.Click += new System.EventHandler(this.pictBoxResume_Click);
            pictBoxResume.MouseEnter += new System.EventHandler(this.pictBoxResume_MouseEnter);
            pictBoxResume.MouseLeave += new System.EventHandler(this.pictBoxResume_MouseLeave);

            pictBoxRestart.Image = Properties.Resources.ButtonRestart;
            pictBoxRestart.SizeMode = PictureBoxSizeMode.StretchImage;
            pictBoxRestart.Width = 224;
            pictBoxRestart.Height = 116;
            pictBoxRestart.Top = 270;
            pictBoxRestart.Left = 440;
            pictBoxRestart.BackColor = Color.Transparent;
            pictBoxRestart.BringToFront();
            this.Controls.Add(pictBoxRestart);
            pictBoxRestart.Visible = true;
            pictBoxRestart.Click += new System.EventHandler(this.pictBoxRestart_Click);
            pictBoxRestart.MouseEnter += new System.EventHandler(this.pictBoxRestart_MouseEnter);
            pictBoxRestart.MouseLeave += new System.EventHandler(this.pictBoxRestart_MouseLeave);

            pictBoxMenu.Image = Properties.Resources.ButtonMenu;
            pictBoxMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pictBoxMenu.Width = 224;
            pictBoxMenu.Height = 116;
            pictBoxMenu.Top = 380;
            pictBoxMenu.Left = 440;
            pictBoxMenu.BackColor = Color.Transparent;
            pictBoxMenu.BringToFront();
            this.Controls.Add(pictBoxMenu);
            pictBoxMenu.Visible = true;
            pictBoxMenu.Click += new System.EventHandler(this.pictBoxMenu_Click);
            pictBoxMenu.MouseEnter += new System.EventHandler(this.pictBoxMenu_MouseEnter);
            pictBoxMenu.MouseLeave += new System.EventHandler(this.pictBoxMenu_MouseLeave);

            this.KeyDown -= FormGame_KeyDown;

            pictBoxResume.BringToFront();
            pictBoxRestart.BringToFront();
            pictBoxMenu.BringToFront();

            labelPause.Visible = false;
            loopSound.settings.mute = true;
            loopSound2.settings.mute = true;
            ghostSound.settings.mute = true;
            timerGame.Stop();
            timerGhost.Stop();
            timerGhostSound.Stop();
            timerTrainLeft.Stop();
            timerTrainRight.Stop();
            //timerTrainMoveLeft.Stop();
            //timerTrainMoveRight.Stop();
        }

        private void pictBoxResume_Click(object sender, EventArgs e)
        {
            pictBoxResume.Visible = false;
            pictBoxRestart.Visible = false;
            pictBoxMenu.Visible = false;
            labelPause.Visible = true;
            loopSound.settings.mute = false;
            loopSound2.settings.mute = false;
            ghostSound.settings.mute = false;
            timerGame.Start();
            timerGhost.Start();
            timerGhostSound.Start();
            timerTrainLeft.Start();
            timerTrainRight.Start();
            //timerTrainMoveLeft.Start();
            //timerTrainMoveRight.Start();

            this.KeyDown += FormGame_KeyDown;
        }

        private void pictBoxResume_MouseEnter(object sender, EventArgs e)
        {
            pictBoxResume.Width = 234;
            pictBoxResume.Height = 126;
            normalSound.URL = resourcePath + "Click.mp3";
        }

        private void pictBoxResume_MouseLeave(object sender, EventArgs e)
        {
            pictBoxResume.Width = 224;
            pictBoxResume.Height = 116;
        }

        private void pictBoxRestart_Click(object sender, EventArgs e)
        {
            timerGame.Enabled = false;
            timerGhost.Enabled = false;
            timerGhostSound.Enabled = false;
            timerTrainLeft.Enabled = false;
            timerTrainRight.Enabled = false;
     
            if ((int)Settings.Default["highScore"] < userScore)
            {
                Settings.Default["highScore"] = userScore;
                labelHighScore.Text = "HI: " + Settings.Default["highScore"].ToString();
                Settings.Default.Save();
            }

            for (int i = 0; i < listOfTrainRight.Count; i++)
            {
                listOfTrainRight[i].Dispose();
                listOfLabelTrainRight[i].Dispose();
            }
            listOfTrainRight.Clear();
            listOfLabelTrainRight.Clear();

            for (int i = 0; i < listOfTrainLeft.Count; i++)
            {
                listOfTrainLeft[i].Dispose();
                listOfLabelTrainLeft[i].Dispose();
            }
            listOfTrainLeft.Clear();
            listOfLabelTrainLeft.Clear();

            pictureBoxChar.Left = 510;
            pictureBoxChar.Top = 425;
            labelChar.Top = 478;
            labelChar.Left = 514;

            pictureBoxChar.Image = Properties.Resources.CharMovesUp;

            pictureBoxGhost.Top = 580;
            pictureBoxGhost.Left = 510;

            userScore = 0;
            progressBarHealth.Value = 100;
            labelScore.Text = userScore.ToString();

            timerGame.Enabled = true;
            timerGhost.Enabled = true;
            timerGhostSound.Enabled = true;
            timerTrainLeft.Enabled = true;
            timerTrainRight.Enabled = true;

            pictBoxResume.Visible = false;
            pictBoxRestart.Visible = false;
            pictBoxMenu.Visible = false;
            labelPause.Visible = true;
            loopSound.settings.mute = false;
            loopSound2.settings.mute = false;
            ghostSound.settings.mute = false;
        }

        private void pictBoxRestart_MouseEnter(object sender, EventArgs e)
        {
            pictBoxRestart.Width = 234;
            pictBoxRestart.Height = 126;
            normalSound.URL = resourcePath + "Click.mp3";
        }

        private void pictBoxRestart_MouseLeave(object sender, EventArgs e)
        {
            pictBoxRestart.Width = 224;
            pictBoxRestart.Height = 116;
        }

        private void pictBoxMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictBoxMenu_MouseEnter(object sender, EventArgs e)
        {
            pictBoxMenu.Width = 234;
            pictBoxMenu.Height = 126;
            normalSound.URL = resourcePath + "Click.mp3";
        }

        private void pictBoxMenu_MouseLeave(object sender, EventArgs e)
        {
            pictBoxMenu.Width = 224;
            pictBoxMenu.Height = 116;
        }

        private void timerGhostSound_Tick(object sender, EventArgs e)
        {
            int ghostSoundType = generator.Next(1, 4);
            switch (ghostSoundType)
            {
                case 1:
                    ghostSound.URL = resourcePath + "GhostSoundInGame1.mp3";
                    break;
                case 2:
                    ghostSound.URL = resourcePath + "GhostSoundInGame2.mp3";
                    break;
                case 3:
                    ghostSound.URL = resourcePath + "GhostSoundInGame3.mp3";
                    break;
            }
        }

        private void timerGhost_Tick(object sender, EventArgs e)
        {
            pictureBoxGhost.Tag = 5;
            pictureBoxGhost.Top -= (int)pictureBoxGhost.Tag;
            if (indexMoveGhost == 0)
            {
                pictureBoxGhost.Image = Properties.Resources.GhostMovesUpR;
                indexMoveGhost++;
            }
            else if (indexMoveGhost == 1)
            {
                pictureBoxGhost.Image = Properties.Resources.GhostMovesUp;
                indexMoveGhost++;
            }
            else
            {
                pictureBoxGhost.Image = Properties.Resources.GhostMovesUpL;
                indexMoveGhost -= 2;
            }
        }

        private void timerTrainRight_Tick(object sender, EventArgs e)
        {
            PictureBox pictureBoxTrainRight = new PictureBox();
            Label labelTrainRight = new Label();

            pictureBoxTrainRight.BackColor = Color.Transparent;
            pictureBoxTrainRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTrainRight.Image = Properties.Resources.TrainRightSingleCart1;
            pictureBoxTrainRight.Height = 120;
            pictureBoxTrainRight.Width = 225;
            pictureBoxTrainRight.Left = -150;

            labelTrainRight.AutoSize = false;
            labelTrainRight.BackColor = Color.Transparent;
            labelTrainRight.Height = 30;
            labelTrainRight.Width = 225;
            labelTrainRight.Left = -150;

            switch (randomTrainRight)
            {
                case 1:
                    pictureBoxTrainRight.Top = 185;
                    labelTrainRight.Top = pictureBoxTrainRight.Top + 90;
                    randomTrainRight += 2;
                    break;
                case 2:
                    pictureBoxTrainRight.Top = 315;
                    labelTrainRight.Top = pictureBoxTrainRight.Top + 90;
                    randomTrainRight--;
                    break;
                case 3:
                    pictureBoxTrainRight.Top = 470;
                    labelTrainRight.Top = pictureBoxTrainRight.Top + 90;
                    randomTrainRight--;
                    break;
            }

            pictureBoxTrainRight.Tag = generator.Next(8, 11);
            labelTrainRight.Tag = pictureBoxTrainRight.Tag;

            listOfTrainRight.Add(pictureBoxTrainRight);
            listOfLabelTrainRight.Add(labelTrainRight);
            this.Controls.Add(pictureBoxTrainRight);
            this.Controls.Add(labelTrainRight);

            if (listOfTrainRight.Count >= MAX_NUMBER_OF_TRAIN)
            {
                timerTrainRight.Enabled = false;
            }
        }

        private void timerTrainLeft_Tick(object sender, EventArgs e)
        {
            PictureBox pictureBoxTrainLeft = new PictureBox();
            Label labelTrainLeft = new Label();

            pictureBoxTrainLeft.BackColor = Color.Transparent;
            pictureBoxTrainLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTrainLeft.Image = Properties.Resources.TrainLeftSingleCart1;
            pictureBoxTrainLeft.Height = 120;
            pictureBoxTrainLeft.Width = 225;
            pictureBoxTrainLeft.Left = 1200;

            labelTrainLeft.AutoSize = false;
            labelTrainLeft.BackColor = Color.Transparent;
            labelTrainLeft.Height = 30;
            labelTrainLeft.Width = 225;
            labelTrainLeft.Left = 1200;

            switch (randomTrainLeft)
            {
                case 1:
                    pictureBoxTrainLeft.Top = 145;
                    labelTrainLeft.Top = pictureBoxTrainLeft.Top + 90;
                    randomTrainLeft++;
                    break;
                case 2:
                    pictureBoxTrainLeft.Top = 270;
                    labelTrainLeft.Top = pictureBoxTrainLeft.Top + 90;
                    randomTrainLeft++;
                    break;
                case 3:
                    pictureBoxTrainLeft.Top = 425;
                    labelTrainLeft.Top = pictureBoxTrainLeft.Top + 90;
                    randomTrainLeft -= 2;
                    break;
            }

            pictureBoxTrainLeft.Tag = generator.Next(8, 11);
            labelTrainLeft.Tag = pictureBoxTrainLeft.Tag;

            listOfTrainLeft.Add(pictureBoxTrainLeft);
            listOfLabelTrainLeft.Add(labelTrainLeft);
            this.Controls.Add(pictureBoxTrainLeft);
            this.Controls.Add(labelTrainLeft);
            
            if (listOfTrainLeft.Count >= MAX_NUMBER_OF_TRAIN)
            {
                timerTrainLeft.Enabled = false;
            }
        }

       

        private void timerGame_Tick(object sender, EventArgs e)
        {
            userScore++;
            labelScore.Text = "Score: " + userScore.ToString();

            for (int i = 0; i < listOfTrainRight.Count; i++)
            {
                listOfTrainRight[i].Left += (int)listOfTrainRight[i].Tag;
                listOfLabelTrainRight[i].Left += (int)listOfLabelTrainRight[i].Tag;
            }

            for (int i = listOfTrainRight.Count - 1; i >= 0; i--)
            {
                if (listOfTrainRight[i].Left > 1194 && listOfLabelTrainRight[i].Left > 1194)
                {
                    listOfTrainRight[i].Dispose();
                    listOfLabelTrainRight[i].Dispose();

                    listOfTrainRight.RemoveAt(i);
                    listOfLabelTrainRight.RemoveAt(i);
                }
            }

            if (listOfTrainRight.Count < MAX_NUMBER_OF_TRAIN)
            {
                timerTrainRight.Enabled = true;
            }

            for (int i = 0; i < listOfTrainRight.Count; i++)
            {
                if (labelChar.Bounds.IntersectsWith(listOfLabelTrainRight[i].Bounds))
                {
                    collisionTrain = true;
                    break;
                }
                if (pictureBoxChar.Bounds.IntersectsWith(listOfTrainRight[i].Bounds))
                {
                    pictureBoxChar.BringToFront();
                    break;
                }
                for (int j = 0; j < listOfTrainLeft.Count; j++)
                {
                    if (listOfTrainRight[i].Bounds.IntersectsWith(listOfTrainLeft[j].Bounds))
                    {
                        listOfTrainRight[i].BringToFront();
                    }
                }
            }

            for (int i = 0; i < listOfTrainLeft.Count; i++)
            {
                listOfTrainLeft[i].Left -= (int)listOfTrainLeft[i].Tag;
                listOfLabelTrainLeft[i].Left -= (int)listOfLabelTrainLeft[i].Tag;
            }

            for (int i = listOfTrainLeft.Count - 1; i >= 0; i--)
            {
                if (listOfTrainLeft[i].Left < -150 && listOfLabelTrainLeft[i].Left < -150)
                {
                    listOfTrainLeft[i].Dispose();
                    listOfLabelTrainLeft[i].Dispose();

                    listOfTrainLeft.RemoveAt(i);
                    listOfLabelTrainLeft.RemoveAt(i);
                }
            }

            if (listOfTrainLeft.Count < MAX_NUMBER_OF_TRAIN)
            {
                timerTrainLeft.Enabled = true;
            }

            for (int i = 0; i < listOfTrainLeft.Count; i++)
            {
                if (labelChar.Bounds.IntersectsWith(listOfLabelTrainLeft[i].Bounds))
                {
                    collisionTrain = true;
                    break;
                }
                if (pictureBoxChar.Bounds.IntersectsWith(listOfTrainLeft[i].Bounds))
                {
                    listOfTrainLeft[i].BringToFront();
                    break;
                }
            }

            if (collisionTrain)
            {
                timerCollisionTrain.Enabled = true;
                timerBlinkChar.Enabled = true;
            }

            pictureBoxGhost.SendToBack();
            labelThresholdTop.SendToBack();
            labelLeftStairLeft.SendToBack();
            labelRightStairRight.SendToBack();
            labelLeftStairRight.SendToBack();
            labelRightStairLeft.SendToBack();

            if (labelChar.Bounds.IntersectsWith(pictureBoxGhost.Bounds))
            {
                collisionGhost = true;
            }

            if (collisionGhost)
            {
                timerCollisionGhost.Enabled = true;
                timerBlinkChar.Enabled = true;
                timerBlinkGhost.Enabled = true;
            }

            if (progressBarHealth.Value == 0)
            {
                timerGhost.Enabled = false;
                timerGhostSound.Enabled = false;
                timerGame.Enabled = false;
                timerTrainRight.Enabled = false;
                timerTrainLeft.Enabled = false;
                timerMoveUp.Enabled = false;
                timerMoveDown.Enabled = false;
                timerMoveRight.Enabled = false;
                timerMoveLeft.Enabled = false;
                //timerTrainMoveLeft.Enabled = false;
                //timerTrainMoveRight.Enabled = false;

                this.KeyDown -= FormGame_KeyDown;

                DialogResult userAnswer = MessageBox.Show("You lose. Do you want to play again?", "End Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userAnswer == DialogResult.Yes)
                {
                    if ((int)Settings.Default["highScore"] < userScore)
                    {
                        Settings.Default["highScore"] = userScore;
                        labelHighScore.Text = "HI: " + Settings.Default["highScore"].ToString();
                        Settings.Default.Save();
                    }

                    for (int i = 0; i < listOfTrainRight.Count; i++)
                    {
                        listOfTrainRight[i].Dispose();
                        listOfLabelTrainRight[i].Dispose();
                    }
                    listOfTrainRight.Clear();
                    listOfLabelTrainRight.Clear();

                    for (int i = 0; i < listOfTrainLeft.Count; i++)
                    {
                        listOfTrainLeft[i].Dispose();
                        listOfLabelTrainLeft[i].Dispose();
                    }
                    listOfTrainLeft.Clear();
                    listOfLabelTrainLeft.Clear();

                    pictureBoxChar.Left = 510;
                    pictureBoxChar.Top = 425;
                    labelChar.Top = 478;
                    labelChar.Left = 514;

                    pictureBoxChar.Image = Properties.Resources.CharMovesUp;

                    pictureBoxGhost.Top = 580;
                    pictureBoxGhost.Left = 510;

                    userScore = 0;
                    progressBarHealth.Value = 100;
                    labelScore.Text = userScore.ToString();

                    timerGhost.Enabled = true;
                    timerGhostSound.Enabled = true;
                    timerGame.Enabled = true;
                    timerTrainRight.Enabled = true;
                    timerTrainLeft.Enabled = true;
                    timerTrainMoveLeft.Enabled = true;
                    timerTrainMoveRight.Enabled = true;
                    timerMoveUp.Enabled = false;
                    timerMoveDown.Enabled = false;
                    timerMoveRight.Enabled = false;
                    timerMoveLeft.Enabled = false;

                    this.KeyDown += FormGame_KeyDown;
                }
                else
                {
                    if ((int)Settings.Default["highScore"] < userScore)
                    {
                        Settings.Default["highScore"] = userScore;
                        labelHighScore.Text = Settings.Default["highScore"].ToString();
                        Settings.Default.Save();
                    }
                    timerGameOver.Enabled = true;
                }
            }
        }

        private void timerBlinkChar_Tick(object sender, EventArgs e)
        {
            if (pictureBoxChar.Visible)
            {
                pictureBoxChar.Visible = false;
            }
            else
            {
                pictureBoxChar.Visible = true;
            }
        }

        private void timerBlinkGhost_Tick(object sender, EventArgs e)
        {
            timerGhost.Stop();
            pictureBoxGhost.Image = Properties.Resources.GhostFreeze;
        }

        private void timerCollisionTrain_Tick(object sender, EventArgs e)
        {
            if (step == 0)
            {
                if (progressBarHealth.Value >= 50)
                {
                    progressBarHealth.Value -= 50;
                }
                else
                {
                    progressBarHealth.Value = 0;
                }
                normalSound2.URL = resourcePath + "CharDamagedSound.mp3";
                ghostSound.URL = resourcePath + "GhostSoundCharHurt.mp3";
            }
            if (timeCollision > 0)
            {
                timeCollision--;
                step++;
                collisionTrain = false;
            }
            else
            {
                timerCollisionTrain.Enabled = false;
                timerBlinkChar.Enabled = false;
                pictureBoxChar.Visible = true;
                step = 0;
                timeCollision = 8;
            }
        }

        private void timerCollisionGhost_Tick(object sender, EventArgs e)
        {
            if (step == 0)
            {
                if (progressBarHealth.Value >= 20)
                {
                    progressBarHealth.Value -= 20;
                }
                else
                {
                    progressBarHealth.Value = 0;
                }
                normalSound2.URL = resourcePath + "CharDamagedSound.mp3";
                ghostSound.URL = resourcePath + "GhostSoundCharHurt.mp3";
            }
            if (timeCollision > 0)
            {
                timeCollision--;
                step++;
                collisionGhost = false;
            }
            else
            {
                timerCollisionGhost.Enabled = false;
                timerBlinkChar.Enabled = false;
                timerBlinkGhost.Enabled = false;
                pictureBoxChar.Visible = true;
                timerGhost.Start();
                step = 0;
                timeCollision = 8;
            }
        }

        private void timerWin_Tick(object sender, EventArgs e)
        {
            if (blackScreenWin > 0)
            {
                timerGame.Stop();
                timerGhost.Stop();
                timerTrainLeft.Stop();
                timerTrainRight.Stop();

                blackScreenWin--;
            }
            else
            {
                timerGame.Start();
                timerGhost.Start();
                timerTrainLeft.Start();
                timerTrainRight.Start();

                blackScreenWin = 4;

                pictureBoxBlack.Visible = false;
                labelChar.Visible = true;
                labelHighScore.Visible = true;
                labelScore.Visible = true;
                labelPause.Visible = true;
                labelHP.Visible = true;
                progressBarHealth.Visible = true;
                pictureBoxChar.Visible = true;
                pictureBoxGhost.Visible = true;
                for (int i = 0; i < listOfTrainLeft.Count; i++)
                {
                    listOfTrainLeft[i].Visible = true;
                    listOfLabelTrainLeft[i].Visible = true;
                }
                for (int i = 0; i < listOfTrainRight.Count; i++)
                {
                    listOfTrainRight[i].Visible = true;
                    listOfLabelTrainRight[i].Visible = true;
                }

                timerWin.Enabled = false;
                this.KeyDown += FormGame_KeyDown;
            }
        }

        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            if (step == 0)
            {
                pictureBoxGameOver.Image = Properties.Resources.GameOver;
                pictureBoxGameOver.BackColor = Color.Transparent;
                pictureBoxGameOver.Height = 640;
                pictureBoxGameOver.Width = 1080;
                pictureBoxGameOver.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxGameOver.Left = 0;
                pictureBoxGameOver.Top = 0;
                Controls.Add(pictureBoxGameOver);
                ghostSound.URL = resourcePath + "GhostSound.mp3";
            }
            if (gameOver > 0)
            {
                step++;
                gameOver--;
                pictureBoxGameOver.BringToFront();
            }
            else
            {
                timerGameOver.Enabled = false;
                step = 0;
                gameOver = 15;
                Close();
            }
        }

        private void timerMoveLeft_Tick(object sender, EventArgs e)
        {
            if (indexMoveLeftChar == 0)
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesLeftR;
                indexMoveLeftChar++;
            }
            else
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesLeftL;
                indexMoveLeftChar--;
            }
            normalSound.URL = resourcePath + "Footstep.mp3";
        }

        private void timerMoveRight_Tick(object sender, EventArgs e)
        {
            if (indexMoveRightChar == 0)
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesRightR;
                indexMoveRightChar++;
            }
            else
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesRightL;
                indexMoveRightChar--;
            }
            normalSound.URL = resourcePath + "Footstep.mp3";
        }

        private void timerMoveUp_Tick(object sender, EventArgs e)
        {
            if (indexMoveUpChar == 0)
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesUpR;
                indexMoveUpChar++;
            }
            else
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesUpL;
                indexMoveUpChar--;
            }
            normalSound.URL = resourcePath + "Footstep.mp3";
        }

        private void timerMoveDown_Tick(object sender, EventArgs e)
        {
            if (indexMoveDownChar == 0)
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesDownR;
                indexMoveDownChar++;
            }
            else
            {
                pictureBoxChar.Image = Properties.Resources.CharMovesDownL;
                indexMoveDownChar--;
            }
            normalSound.URL = resourcePath + "Footstep.mp3";
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (labelChar.Left == 30 && (labelChar.Top >= 75 && labelChar.Top <= 140))
                    {
                        ghostSound.URL = resourcePath + "GhostSoundCharWin.mp3";
                        userScore += 500;
                        labelScore.Text = "Score: " + userScore.ToString();

                        pictureBoxGhost.Top = (pictureBoxGhost.Top - pictureBoxChar.Top) + 576;
                        pictureBoxGhost.Left = 1044;

                        pictureBoxChar.Top = 576;
                        pictureBoxChar.Left = 1042;
                        labelChar.Top = 630;
                        labelChar.Left = 1044;

                        pictureBoxChar.Image = Properties.Resources.CharMovesRight;

                        pictureBoxBlack.BackColor = Color.Black;
                        pictureBoxBlack.Top = 0;
                        pictureBoxBlack.Left = 0;
                        pictureBoxBlack.Height = ClientSize.Height;
                        pictureBoxBlack.Width = ClientSize.Width;
                        pictureBoxBlack.BringToFront();
                        Controls.Add(pictureBoxBlack);

                        pictureBoxBlack.Visible = true;
                        labelChar.Visible = false;
                        labelHighScore.Visible = false;
                        labelScore.Visible = false;
                        labelPause.Visible = false;
                        labelHP.Visible = false;
                        progressBarHealth.Visible = false;
                        pictureBoxChar.Visible = false;
                        pictureBoxGhost.Visible = false;
                        for (int i = 0; i < listOfTrainLeft.Count; i++)
                        {
                            listOfTrainLeft[i].Visible = false;
                            listOfLabelTrainLeft[i].Visible = false;
                        }
                        for (int i = 0; i < listOfTrainRight.Count; i++)
                        {
                            listOfTrainRight[i].Visible = false;
                            listOfLabelTrainRight[i].Visible = false;
                        }

                        this.KeyDown -= FormGame_KeyDown;

                        timerWin.Enabled = true;
                    }
                    if (labelChar.Left == 0 || labelChar.Bounds.IntersectsWith(labelLeftStairLeft.Bounds) || labelChar.Bounds.IntersectsWith(labelLeftStairRight.Bounds))
                    {
                        pictureBoxChar.Left -= 0;
                        labelChar.Left -= 0;
                    }
                    else if (labelChar.Top >= 110 && labelChar.Top <= 180 && labelChar.Left <= 80)
                    {
                        pictureBoxChar.Top -= 1;
                        pictureBoxChar.Left -= charMove;
                        labelChar.Top -= 1;
                        labelChar.Left -= charMove;
                        pictureBoxGhost.Left -= charMove;
                        timerMoveLeft.Enabled = true;
                    }
                    else if (labelChar.Top <= 140 && labelChar.Left >= 1000)
                    {
                        pictureBoxChar.Top += 1;
                        pictureBoxChar.Left -= charMove;
                        labelChar.Top += 1;
                        labelChar.Left -= charMove;
                        pictureBoxGhost.Left -= charMove;
                        timerMoveLeft.Enabled = true;
                    }
                    else
                    {
                        pictureBoxChar.Left -= charMove;
                        labelChar.Left -= charMove;
                        pictureBoxGhost.Left -= charMove;
                        timerMoveLeft.Enabled = true;
                    }
                    break;
                case Keys.Right:
                    if (labelChar.Left == 1014 && (labelChar.Top >= 75 && labelChar.Top <= 140))
                    {
                        ghostSound.URL = resourcePath + "GhostSoundCharWin.mp3";
                        userScore += 500;
                        labelScore.Text = "Score: " + userScore.ToString();

                        pictureBoxGhost.Top = (pictureBoxGhost.Top - pictureBoxChar.Top) + 576;
                        pictureBoxGhost.Left = 2;

                        pictureBoxChar.Top = 576;
                        pictureBoxChar.Left = 0;
                        labelChar.Top = 630;
                        labelChar.Left = 2;

                        pictureBoxChar.Image = Properties.Resources.CharMovesLeft;

                        pictureBoxBlack.BackColor = Color.Black;
                        pictureBoxBlack.Top = 0;
                        pictureBoxBlack.Left = 0;
                        pictureBoxBlack.Height = ClientSize.Height;
                        pictureBoxBlack.Width = ClientSize.Width;
                        pictureBoxBlack.BringToFront();
                        Controls.Add(pictureBoxBlack);

                        pictureBoxBlack.Visible = true;
                        labelChar.Visible = false;
                        labelHighScore.Visible = false;
                        labelScore.Visible = false;
                        labelPause.Visible = false;
                        labelHP.Visible = false;
                        progressBarHealth.Visible = false;
                        pictureBoxChar.Visible = false;
                        pictureBoxGhost.Visible = false;
                        for (int i = 0; i < listOfTrainLeft.Count; i++)
                        {
                            listOfTrainLeft[i].Visible = false;
                            listOfLabelTrainLeft[i].Visible = false;
                        }
                        for (int i = 0; i < listOfTrainRight.Count; i++)
                        {
                            listOfTrainRight[i].Visible = false;
                            listOfLabelTrainRight[i].Visible = false;
                        }

                        this.KeyDown -= FormGame_KeyDown;

                        timerWin.Enabled = true;
                    }
                    if (labelChar.Left == 1044 || labelChar.Bounds.IntersectsWith(labelRightStairRight.Bounds) || labelChar.Bounds.IntersectsWith(labelRightStairLeft.Bounds))
                    {
                        pictureBoxChar.Left += 0;
                        labelChar.Left += 0;
                    }
                    else if (labelChar.Top >= 110 && labelChar.Top <= 180 && labelChar.Left >= 964)
                    {
                        pictureBoxChar.Top -= 1;
                        pictureBoxChar.Left += charMove;
                        labelChar.Top -= 1;
                        labelChar.Left += charMove;
                        pictureBoxGhost.Left += charMove;
                        timerMoveRight.Enabled = true;
                    }
                    else if (labelChar.Top <= 140 && labelChar.Left <= 80)
                    {
                        pictureBoxChar.Top += 1;
                        pictureBoxChar.Left += charMove;
                        labelChar.Top += 1;
                        labelChar.Left += charMove;
                        pictureBoxGhost.Left += charMove;
                        timerMoveRight.Enabled = true;
                    }
                    else
                    {
                        pictureBoxChar.Left += charMove;
                        labelChar.Left += charMove;
                        pictureBoxGhost.Left += charMove;
                        timerMoveRight.Enabled = true;
                    }
                    break;
                case Keys.Up:
                    if (labelChar.Bounds.IntersectsWith(labelThresholdTop.Bounds) || labelChar.Bounds.IntersectsWith(labelLeftStairLeft.Bounds) || labelChar.Bounds.IntersectsWith(labelRightStairRight.Bounds))
                    {
                        pictureBoxChar.Top += 0;
                        labelChar.Top += 0;
                    }
                    else
                    {
                        pictureBoxChar.Top -= charMove;
                        labelChar.Top -= charMove;
                        timerMoveUp.Enabled = true;
                    }
                    break;
                case Keys.Down:
                    if (labelChar.Top == 636 || labelChar.Top == 100 && labelChar.Left <= 80 || labelChar.Top == 100 && labelChar.Left >= 964 || labelChar.Bounds.IntersectsWith(pictureBoxGhost.Bounds))
                    {
                        pictureBoxChar.Top -= 0;
                        labelChar.Top -= 0;
                    }
                    else
                    {
                        pictureBoxChar.Top += charMove;
                        labelChar.Top += charMove;
                        timerMoveDown.Enabled = true;
                    }
                    break;
            }
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    timerMoveLeft.Enabled = false;
                    pictureBoxChar.Image = Properties.Resources.CharMovesLeft;
                    break;
                case Keys.Right:
                    timerMoveRight.Enabled = false;
                    pictureBoxChar.Image = Properties.Resources.CharMovesRight;
                    break;
                case Keys.Up:
                    timerMoveUp.Enabled = false;
                    pictureBoxChar.Image = Properties.Resources.CharMovesUp;
                    break;
                case Keys.Down:
                    timerMoveDown.Enabled = false;
                    pictureBoxChar.Image = Properties.Resources.CharMovesDown;
                    break;
            }
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerListBoxInfo.Enabled = false;
            timerMoveLeft.Enabled = false;
            timerMoveRight.Enabled = false;
            timerMoveUp.Enabled = false;
            timerMoveDown.Enabled = false;
            timerGhost.Enabled = false;
            timerGhostSound.Enabled = false;
            timerGame.Enabled = false;
            timerTrainRight.Enabled = false;
            timerTrainLeft.Enabled = false;
            for (int i = 0; i < listOfTrainRight.Count; i++)
            {
                listOfTrainRight[i].Dispose();
                listOfLabelTrainRight[i].Dispose();
            }
            listOfTrainRight.Clear();
            listOfLabelTrainRight.Clear();

            for (int i = 0; i < listOfLabelTrainLeft.Count; i++)
            {
                listOfTrainLeft[i].Dispose();
                listOfLabelTrainLeft[i].Dispose();
            }
            listOfTrainLeft.Clear();
            listOfLabelTrainLeft.Clear();

            pictureBoxChar.Dispose();
            pictureBoxGhost.Dispose();

            userScore = 0;
            progressBarHealth.Value = 100;
            labelScore.Text = userScore.ToString();
            this.KeyDown -= FormGame_KeyDown;
            loopSound.close();
            loopSound2.close();
            normalSound.close();
            normalSound2.close();
            ghostSound.close();
        }

        private void timerTrainMoveLeft_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < listOfTrainLeft.Count; i++)
            {
                if (indexmoveLeftTrain == 0)
                {
                    listOfTrainLeft[i].Image = Properties.Resources.TrainLeftSingleCart2;
                    indexmoveLeftTrain++;
                }
                else
                {
                    listOfTrainLeft[i].Image = Properties.Resources.TrainLeftSingleCart3;
                    indexmoveLeftTrain--;
                }
                normalSound.URL = resourcePath + ".mp3";
            }
        }

        private void timerTrainMoveRight_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < listOfTrainRight.Count; i++)
            {
                if (indexmoveRightTrain == 0)
                {
                    listOfTrainRight[i].Image = Properties.Resources.TrainRightSingleCart2;
                    indexmoveRightTrain++;
                }
                else
                {
                    listOfTrainRight[i].Image = Properties.Resources.TrainRightSingleCart3;
                    indexmoveRightTrain--;
                }
                normalSound.URL = resourcePath + ".mp3";
            }
        }
    }
}
