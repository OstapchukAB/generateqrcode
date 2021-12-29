namespace GenerateQRcode
{
    partial class FormQR
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
            this.buttonQRcreate = new System.Windows.Forms.Button();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.richTextBoxStrinfForQR = new System.Windows.Forms.RichTextBox();
            this.buttonSaveQR = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQRcreate
            // 
            this.buttonQRcreate.Location = new System.Drawing.Point(436, 243);
            this.buttonQRcreate.Name = "buttonQRcreate";
            this.buttonQRcreate.Size = new System.Drawing.Size(148, 43);
            this.buttonQRcreate.TabIndex = 1;
            this.buttonQRcreate.Text = "Создать QR";
            this.buttonQRcreate.UseVisualStyleBackColor = true;
            this.buttonQRcreate.Click += new System.EventHandler(this.buttonQRcreate_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.Location = new System.Drawing.Point(6, 25);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(381, 487);
            this.pictureBoxQR.TabIndex = 2;
            this.pictureBoxQR.TabStop = false;
            // 
            // richTextBoxStrinfForQR
            // 
            this.richTextBoxStrinfForQR.Location = new System.Drawing.Point(436, 25);
            this.richTextBoxStrinfForQR.Name = "richTextBoxStrinfForQR";
            this.richTextBoxStrinfForQR.Size = new System.Drawing.Size(312, 206);
            this.richTextBoxStrinfForQR.TabIndex = 3;
            this.richTextBoxStrinfForQR.Text = "";
            // 
            // buttonSaveQR
            // 
            this.buttonSaveQR.Location = new System.Drawing.Point(600, 243);
            this.buttonSaveQR.Name = "buttonSaveQR";
            this.buttonSaveQR.Size = new System.Drawing.Size(148, 43);
            this.buttonSaveQR.TabIndex = 4;
            this.buttonSaveQR.Text = "Сохранить QR";
            this.buttonSaveQR.UseVisualStyleBackColor = true;
            this.buttonSaveQR.Click += new System.EventHandler(this.buttonSaveQR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxQR);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 524);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // FormQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSaveQR);
            this.Controls.Add(this.richTextBoxStrinfForQR);
            this.Controls.Add(this.buttonQRcreate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormQR";
            this.Text = "Create QR";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonQRcreate;
        private System.Windows.Forms.PictureBox pictureBoxQR;
        private System.Windows.Forms.RichTextBox richTextBoxStrinfForQR;
        private System.Windows.Forms.Button buttonSaveQR;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

