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
    public partial class FormMenu : Form
    {
        string resourcePath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer loopSound = new WindowsMediaPlayer();
        WindowsMediaPlayer normalSound = new WindowsMediaPlayer();
        double waitingPlay = 3.8;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            labelPlay.Parent = pictureBoxBackground;
            labelHowToPlay.Parent = pictureBoxBackground;
            labelExit.Parent = pictureBoxBackground;
            labelHighScore.Parent = pictureBoxBackground;
            labelHighScore.Text = "HighScore: " + Settings.Default["highScore"].ToString();
            loopSound.URL = resourcePath + "Menu SoundTrack.mp3";
            loopSound.settings.setMode("loop", true);
            this.DoubleBuffered = true;
        }

        private void labelPlay_Click(object sender, EventArgs e)
        {
            labelPlay.Visible = false;
            labelHowToPlay.Visible = false;
            labelExit.Visible = false;
            labelHighScore.Visible = false;
            this.loopSound.settings.mute = true;
            pictureBoxBackground.Image = Properties.Resources.StartGame;
            normalSound.URL = resourcePath + "TrainMenu1.mp3";
            timerPlay.Enabled = true;
        }

        private void labelPlay_MouseEnter(object sender, EventArgs e)
        {
            normalSound.URL = resourcePath + "Click.mp3";
            labelPlay.ForeColor = Color.Red;
            labelPlay.Font = new Font("Chiller", 65, FontStyle.Bold);
        }

        private void labelPlay_MouseLeave(object sender, EventArgs e)
        {
            labelPlay.ForeColor = Color.White;
            labelPlay.Font = new Font("Chiller", 60, FontStyle.Bold);
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            if (waitingPlay > 0)
            {
                waitingPlay -= 0.2;
                if (waitingPlay >= 1.78 && waitingPlay <= 1.8)
                {
                    normalSound.URL = resourcePath + "TrainMenu2.mp3";
                }
            }
            else
            {
                timerPlay.Enabled = false;
                waitingPlay = 3.8;
                this.Visible = false;
                FormGame formGame = new FormGame();
                formGame.Owner = this;
                formGame.ShowDialog();
                this.Visible = true;
                labelHighScore.Text = "HighScore: " + Settings.Default["highScore"].ToString();
                pictureBoxBackground.Image = Properties.Resources.Menu;
                labelPlay.Visible = true;
                labelHowToPlay.Visible = true;
                labelExit.Visible = true;
                labelHighScore.Visible = true;
                this.loopSound.settings.mute = false;
            }
        }

        private void labelHowToPlay_Click(object sender, EventArgs e)
        {
            FormHowToPlay formHowToPlay = new FormHowToPlay();
            formHowToPlay.Owner = this;
            this.Visible = false;
            formHowToPlay.ShowDialog();
            this.Visible = true;
        }

        private void labelHowToPlay_MouseEnter(object sender, EventArgs e)
        {
            normalSound.URL = resourcePath + "Click.mp3";
            labelHowToPlay.ForeColor = Color.Red;
            labelHowToPlay.Font = new Font("Chiller", 40, FontStyle.Bold);
        }

        private void labelHowToPlay_MouseLeave(object sender, EventArgs e)
        {
            labelHowToPlay.ForeColor = Color.White;
            labelHowToPlay.Font = new Font("Chiller", 35, FontStyle.Bold);
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            DialogResult userAnswer = MessageBox.Show("Are you sure you want to leave this game?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (userAnswer == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            normalSound.URL = resourcePath + "Click.mp3";
            labelExit.ForeColor = Color.Red;
            labelExit.Font = new Font("Chiller", 40, FontStyle.Bold);
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.White;
            labelExit.Font = new Font("Chiller", 35, FontStyle.Bold);
        }
    }
}
