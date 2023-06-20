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

namespace Cross_Subway_Student_Challenge
{
    public partial class FormHowToPlay : Form
    {
        FormMenu formMenu = null;
        string resourcePath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer normalSound = new WindowsMediaPlayer();
        double waitingClose = 1.5;

        public FormHowToPlay()
        {
            InitializeComponent();
        }

        private void FormHowToPlay_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            formMenu = (FormMenu)this.Owner;
            listBoxInfo.Items.Add("1. In this game, ");
            listBoxInfo.Items.Add("   you as Adam need to escape from subway station. ");
            listBoxInfo.Items.Add("   You also need to run from ghost that follows you.");
            listBoxInfo.Items.Add("2. To move your character:");
            listBoxInfo.Items.Add("   - Press up arrow to move forward");
            listBoxInfo.Items.Add("   - Press down arrow to move back off");
            listBoxInfo.Items.Add("   - Press right arrow to move right");
            listBoxInfo.Items.Add("   - Press left arrow to move left");
            listBoxInfo.Items.Add("3. You must not get crashed by the train and");
            listBoxInfo.Items.Add("   also you must not get caught by the ghost.");
            listBoxInfo.Items.Add("4. If the train or the ghost hit you,");
            listBoxInfo.Items.Add("   your health will be decreased.");
            listBoxInfo.Items.Add("5. To escape from the ghost you need to go to the stair");
            listBoxInfo.Items.Add("   On the left side or the right side of the map.");
            listBoxInfo.Items.Add("6. Get as many score as you can!");
            listBoxInfo.Items.Add("7. Enjoy the game ;)");
        }

        private void labelUnderstand_Click(object sender, EventArgs e)
        {
            labelUnderstand.ForeColor = Color.Red;
            labelUnderstand.Font = new Font("Chiller", 40, FontStyle.Strikeout);
            labelUnderstand.MouseLeave -= labelUnderstand_MouseLeave;
            pictureBoxApproved.Visible = true;
            normalSound.URL = resourcePath + "Understand.mp3";
            timerClose.Enabled = true;
        }

        private void labelUnderstand_MouseEnter(object sender, EventArgs e)
        {
            normalSound.URL = resourcePath + "Click.mp3";
            labelUnderstand.Font = new Font("Chiller", 40, FontStyle.Bold);
        }

        private void labelUnderstand_MouseLeave(object sender, EventArgs e)
        {
            labelUnderstand.Font = new Font("Chiller", 35, FontStyle.Bold);
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (waitingClose > 0)
            {
                waitingClose -= 0.5;
            }
            else
            {
                timerClose.Enabled = false;
                this.Close();
            }
        }
    }
}
