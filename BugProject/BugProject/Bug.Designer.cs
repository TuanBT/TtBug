namespace BugProject
{
    partial class Bug
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
            this.picNormal = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrTalk = new System.Windows.Forms.Timer(this.components);
            this.tmrCountDown = new System.Windows.Forms.Timer(this.components);
            this.tmrHeart = new System.Windows.Forms.Timer(this.components);
            this.tmrStandLove = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picNormal)).BeginInit();
            this.SuspendLayout();
            // 
            // picNormal
            // 
            this.picNormal.Location = new System.Drawing.Point(0, 0);
            this.picNormal.Name = "picNormal";
            this.picNormal.Size = new System.Drawing.Size(35, 35);
            this.picNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNormal.TabIndex = 0;
            this.picNormal.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrTalk
            // 
            this.tmrTalk.Interval = 10;
            this.tmrTalk.Tick += new System.EventHandler(this.tmrTalk_Tick);
            // 
            // tmrCountDown
            // 
            this.tmrCountDown.Tick += new System.EventHandler(this.tmrCountDown_Tick);
            // 
            // tmrHeart
            // 
            this.tmrHeart.Tick += new System.EventHandler(this.tmrHeart_Tick);
            // 
            // tmrStandLove
            // 
            this.tmrStandLove.Tick += new System.EventHandler(this.tmrStandLove_Tick);
            // 
            // Bug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(40, 41);
            this.ControlBox = false;
            this.Controls.Add(this.picNormal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bug";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bug_FormClosing);
            this.Load += new System.EventHandler(this.Bug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNormal)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.PictureBox picNormal;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmrTalk;
        private System.Windows.Forms.Timer tmrCountDown;
        private System.Windows.Forms.Timer tmrHeart;
        private System.Windows.Forms.Timer tmrStandLove;
    }
}