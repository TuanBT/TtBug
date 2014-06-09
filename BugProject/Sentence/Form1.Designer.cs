namespace Sentence
{
    partial class Form1
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
            this.dgvSentence = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAuthor = new System.Windows.Forms.Label();
            this.cbbAuthor = new System.Windows.Forms.ComboBox();
            this.txtType = new System.Windows.Forms.Label();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.cbbPeople = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.lblCau = new System.Windows.Forms.Label();
            this.btnPrefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSentence)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSentence
            // 
            this.dgvSentence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSentence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSentence.Location = new System.Drawing.Point(0, 0);
            this.dgvSentence.Name = "dgvSentence";
            this.dgvSentence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSentence.Size = new System.Drawing.Size(806, 185);
            this.dgvSentence.TabIndex = 0;
            this.dgvSentence.SelectionChanged += new System.EventHandler(this.dgvSentence_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.txtAuthor);
            this.panel1.Controls.Add(this.cbbAuthor);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Controls.Add(this.cbbType);
            this.panel1.Controls.Add(this.cbbPeople);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 102);
            this.panel1.TabIndex = 1;
            // 
            // txtAuthor
            // 
            this.txtAuthor.AutoSize = true;
            this.txtAuthor.Location = new System.Drawing.Point(0, 71);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(58, 13);
            this.txtAuthor.TabIndex = 6;
            this.txtAuthor.Text = "Người viết:";
            // 
            // cbbAuthor
            // 
            this.cbbAuthor.FormattingEnabled = true;
            this.cbbAuthor.Items.AddRange(new object[] {
            ""});
            this.cbbAuthor.Location = new System.Drawing.Point(61, 68);
            this.cbbAuthor.Name = "cbbAuthor";
            this.cbbAuthor.Size = new System.Drawing.Size(140, 21);
            this.cbbAuthor.TabIndex = 9;
            // 
            // txtType
            // 
            this.txtType.AutoSize = true;
            this.txtType.Location = new System.Drawing.Point(4, 44);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(51, 13);
            this.txtType.TabIndex = 4;
            this.txtType.Text = "Loại câu:";
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            ""});
            this.cbbType.Location = new System.Drawing.Point(61, 41);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(140, 21);
            this.cbbType.TabIndex = 7;
            // 
            // cbbPeople
            // 
            this.cbbPeople.FormattingEnabled = true;
            this.cbbPeople.Items.AddRange(new object[] {
            ""});
            this.cbbPeople.Location = new System.Drawing.Point(61, 11);
            this.cbbPeople.Name = "cbbPeople";
            this.cbbPeople.Size = new System.Drawing.Size(140, 21);
            this.cbbPeople.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Con nói:";
            // 
            // txtSentence
            // 
            this.txtSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSentence.Location = new System.Drawing.Point(64, 214);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(700, 20);
            this.txtSentence.TabIndex = 3;
            this.txtSentence.TextChanged += new System.EventHandler(this.txtSentence_TextChanged);
            // 
            // lblCau
            // 
            this.lblCau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCau.AutoSize = true;
            this.lblCau.Location = new System.Drawing.Point(12, 217);
            this.lblCau.Name = "lblCau";
            this.lblCau.Size = new System.Drawing.Size(46, 13);
            this.lblCau.TabIndex = 2;
            this.lblCau.Text = "Câu nói:";
            // 
            // btnPrefresh
            // 
            this.btnPrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrefresh.Location = new System.Drawing.Point(335, 240);
            this.btnPrefresh.Name = "btnPrefresh";
            this.btnPrefresh.Size = new System.Drawing.Size(75, 23);
            this.btnPrefresh.TabIndex = 3;
            this.btnPrefresh.Text = "Hiện";
            this.btnPrefresh.UseVisualStyleBackColor = true;
            this.btnPrefresh.Click += new System.EventHandler(this.btnPrefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(528, 310);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(447, 310);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhập";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.Location = new System.Drawing.Point(689, 237);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(770, 217);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tối đa 48 ký tự";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 354);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPrefresh);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSentence);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.lblCau);
            this.Name = "Form1";
            this.Text = "Sentence TtBug";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSentence)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSentence;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtAuthor;
        private System.Windows.Forms.Label txtType;
        private System.Windows.Forms.TextBox txtSentence;
        private System.Windows.Forms.Label lblCau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnPrefresh;
        private System.Windows.Forms.ComboBox cbbAuthor;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.ComboBox cbbPeople;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
    }
}

