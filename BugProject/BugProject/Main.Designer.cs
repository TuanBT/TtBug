using System.Diagnostics;
namespace BugProject
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTalking = new System.Windows.Forms.Button();
            this.tmrMeet = new System.Windows.Forms.Timer(this.components);
            this.tmrEvent = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "NewBug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTalking
            // 
            this.btnTalking.Location = new System.Drawing.Point(13, 55);
            this.btnTalking.Margin = new System.Windows.Forms.Padding(2);
            this.btnTalking.Name = "btnTalking";
            this.btnTalking.Size = new System.Drawing.Size(110, 32);
            this.btnTalking.TabIndex = 4;
            this.btnTalking.Text = "New talking bug 1";
            this.btnTalking.UseVisualStyleBackColor = true;
            this.btnTalking.Click += new System.EventHandler(this.btnTalking_Click);
            // 
            // tmrMeet
            // 
            this.tmrMeet.Enabled = true;
            this.tmrMeet.Tick += new System.EventHandler(this.tmrMeet_Tick);
            // 
            // tmrEvent
            // 
            this.tmrEvent.Tick += new System.EventHandler(this.tmrEvent_Tick);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 141);
            this.Controls.Add(this.btnTalking);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTalking;
        private System.Windows.Forms.Timer tmrMeet;
        private System.Windows.Forms.Timer tmrEvent;
        private System.Windows.Forms.Timer tmrUpdate;
    }
}

