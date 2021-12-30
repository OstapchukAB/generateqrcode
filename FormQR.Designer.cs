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
            this.groupBoxForPictureBox = new System.Windows.Forms.GroupBox();
            this.buttonLoadFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.groupBoxForPictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQRcreate
            // 
            this.buttonQRcreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQRcreate.Location = new System.Drawing.Point(759, 237);
            this.buttonQRcreate.Name = "buttonQRcreate";
            this.buttonQRcreate.Size = new System.Drawing.Size(163, 57);
            this.buttonQRcreate.TabIndex = 1;
            this.buttonQRcreate.Text = "Создать QR";
            this.buttonQRcreate.UseVisualStyleBackColor = true;
            this.buttonQRcreate.Click += new System.EventHandler(this.buttonQRcreate_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxQR.Location = new System.Drawing.Point(3, 22);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(531, 487);
            this.pictureBoxQR.TabIndex = 2;
            this.pictureBoxQR.TabStop = false;
            // 
            // richTextBoxStrinfForQR
            // 
            this.richTextBoxStrinfForQR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxStrinfForQR.Location = new System.Drawing.Point(563, 25);
            this.richTextBoxStrinfForQR.Name = "richTextBoxStrinfForQR";
            this.richTextBoxStrinfForQR.Size = new System.Drawing.Size(359, 206);
            this.richTextBoxStrinfForQR.TabIndex = 3;
            this.richTextBoxStrinfForQR.Text = "";
            // 
            // buttonSaveQR
            // 
            this.buttonSaveQR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveQR.Location = new System.Drawing.Point(759, 363);
            this.buttonSaveQR.Name = "buttonSaveQR";
            this.buttonSaveQR.Size = new System.Drawing.Size(163, 57);
            this.buttonSaveQR.TabIndex = 4;
            this.buttonSaveQR.Text = "Сохранить QR";
            this.buttonSaveQR.UseVisualStyleBackColor = true;
            this.buttonSaveQR.Click += new System.EventHandler(this.buttonSaveQR_Click);
            // 
            // groupBoxForPictureBox
            // 
            this.groupBoxForPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxForPictureBox.Controls.Add(this.pictureBoxQR);
            this.groupBoxForPictureBox.Location = new System.Drawing.Point(14, 16);
            this.groupBoxForPictureBox.Name = "groupBoxForPictureBox";
            this.groupBoxForPictureBox.Size = new System.Drawing.Size(537, 512);
            this.groupBoxForPictureBox.TabIndex = 5;
            this.groupBoxForPictureBox.TabStop = false;
            this.groupBoxForPictureBox.Text = "-";
            // 
            // buttonLoadFromFile
            // 
            this.buttonLoadFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFromFile.Location = new System.Drawing.Point(759, 300);
            this.buttonLoadFromFile.Name = "buttonLoadFromFile";
            this.buttonLoadFromFile.Size = new System.Drawing.Size(163, 57);
            this.buttonLoadFromFile.TabIndex = 6;
            this.buttonLoadFromFile.Text = "Загрузка из файла";
            this.buttonLoadFromFile.UseVisualStyleBackColor = true;
            this.buttonLoadFromFile.Click += new System.EventHandler(this.buttonLoadFromFile_Click);
            // 
            // FormQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 590);
            this.Controls.Add(this.buttonLoadFromFile);
            this.Controls.Add(this.groupBoxForPictureBox);
            this.Controls.Add(this.buttonSaveQR);
            this.Controls.Add(this.richTextBoxStrinfForQR);
            this.Controls.Add(this.buttonQRcreate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormQR";
            this.Text = "Create QR";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.groupBoxForPictureBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonQRcreate;
        private System.Windows.Forms.PictureBox pictureBoxQR;
        private System.Windows.Forms.RichTextBox richTextBoxStrinfForQR;
        private System.Windows.Forms.Button buttonSaveQR;
        private System.Windows.Forms.GroupBox groupBoxForPictureBox;
        private System.Windows.Forms.Button buttonLoadFromFile;
    }
}

