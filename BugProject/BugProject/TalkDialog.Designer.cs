namespace BugProject
{
    partial class TalkDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalkDialog));
            this.ptbTalkBaloon = new System.Windows.Forms.PictureBox();
            this.lbTalk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTalkBaloon)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbTalkBaloon
            // 
            this.ptbTalkBaloon.BackColor = System.Drawing.Color.White;
            this.ptbTalkBaloon.Image = ((System.Drawing.Image)(resources.GetObject("ptbTalkBaloon.Image")));
            this.ptbTalkBaloon.Location = new System.Drawing.Point(0, 0);
            this.ptbTalkBaloon.Margin = new System.Windows.Forms.Padding(2);
            this.ptbTalkBaloon.Name = "ptbTalkBaloon";
            this.ptbTalkBaloon.Size = new System.Drawing.Size(137, 109);
            this.ptbTalkBaloon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbTalkBaloon.TabIndex = 0;
            this.ptbTalkBaloon.TabStop = false;
            // 
            // lbTalk
            // 
            this.lbTalk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.lbTalk.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTalk.ForeColor = System.Drawing.Color.Black;
            this.lbTalk.Location = new System.Drawing.Point(19, 22);
            this.lbTalk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTalk.Name = "lbTalk";
            this.lbTalk.Size = new System.Drawing.Size(99, 51);
            this.lbTalk.TabIndex = 1;
            this.lbTalk.Text = "Max is 48 character";
            this.lbTalk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TalkDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(142, 115);
            this.ControlBox = false;
            this.Controls.Add(this.lbTalk);
            this.Controls.Add(this.ptbTalkBaloon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TalkDialog";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TalkDialog";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.TalkDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTalkBaloon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbTalkBaloon;
        private System.Windows.Forms.Label lbTalk;

    }
}