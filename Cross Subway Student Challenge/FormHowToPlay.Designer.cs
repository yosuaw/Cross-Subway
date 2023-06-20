namespace Cross_Subway_Student_Challenge
{
    partial class FormHowToPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHowToPlay));
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.labelUnderstand = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxApproved = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxApproved)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.BackColor = System.Drawing.Color.Black;
            this.listBoxInfo.Font = new System.Drawing.Font("Chiller", 25F, System.Drawing.FontStyle.Italic);
            this.listBoxInfo.ForeColor = System.Drawing.Color.Red;
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 49;
            this.listBoxInfo.Location = new System.Drawing.Point(251, 63);
            this.listBoxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(805, 445);
            this.listBoxInfo.TabIndex = 0;
            // 
            // labelUnderstand
            // 
            this.labelUnderstand.AutoSize = true;
            this.labelUnderstand.BackColor = System.Drawing.Color.Transparent;
            this.labelUnderstand.Font = new System.Drawing.Font("Chiller", 35F, System.Drawing.FontStyle.Bold);
            this.labelUnderstand.ForeColor = System.Drawing.Color.White;
            this.labelUnderstand.Location = new System.Drawing.Point(361, 575);
            this.labelUnderstand.Name = "labelUnderstand";
            this.labelUnderstand.Size = new System.Drawing.Size(538, 69);
            this.labelUnderstand.TabIndex = 1;
            this.labelUnderstand.Text = "I Understand The Gameplay";
            this.labelUnderstand.Click += new System.EventHandler(this.labelUnderstand_Click);
            this.labelUnderstand.MouseEnter += new System.EventHandler(this.labelUnderstand_MouseEnter);
            this.labelUnderstand.MouseLeave += new System.EventHandler(this.labelUnderstand_MouseLeave);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 300;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // pictureBoxApproved
            // 
            this.pictureBoxApproved.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxApproved.Image = global::Cross_Subway_Student_Challenge.Properties.Resources.Approved;
            this.pictureBoxApproved.Location = new System.Drawing.Point(749, 346);
            this.pictureBoxApproved.Name = "pictureBoxApproved";
            this.pictureBoxApproved.Size = new System.Drawing.Size(285, 132);
            this.pictureBoxApproved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxApproved.TabIndex = 2;
            this.pictureBoxApproved.TabStop = false;
            this.pictureBoxApproved.Visible = false;
            // 
            // FormHowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cross_Subway_Student_Challenge.Properties.Resources.How_to_play;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.pictureBoxApproved);
            this.Controls.Add(this.labelUnderstand);
            this.Controls.Add(this.listBoxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormHowToPlay";
            this.Text = "Cross Subway";
            this.Load += new System.EventHandler(this.FormHowToPlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxApproved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Label labelUnderstand;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.PictureBox pictureBoxApproved;
    }
}