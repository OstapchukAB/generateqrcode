using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GenerateQRcode
{
    public partial class FormQR : Form
    {
        Bitmap ResultImage { get; set; }
        string Filename { get; set; }
        public FormQR()
        {
            InitializeComponent();
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void buttonQRcreate_Click(object sender, EventArgs e)
        {
            CreateQRCodsFromTxt(richTextBoxStrinfForQR.Text);

        }


        private void buttonSaveQR_Click(object sender, EventArgs e)
        {
            if (ResultImage != null)
            {
                ResultImage.Save(Filename);
            }
        }

        private void buttonLoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CreateQRFromTxt(openFile.FileName);                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                MessageBox.Show("Завершено!");

            }


        }

        void CreateQRFromTxt(string filePath) 
        {
      
                var lstLargeTxt = new LoadTxtFromFile().ReadFromCSV(filePath);
                var queueRows = new Queue<FilesStructures>();
                foreach (var v in lstLargeTxt)
                    queueRows.Enqueue(v);

                ResultImage = null;

                //прочтем всю очередь по 12 подходов или пока очередь не закончится
                while (queueRows.Count > 0)
                {
                    var qrA4 = new QRCodes();
                    for (int i = 0; i < QRCodes.CNTS_IMAGES_MAX && queueRows.Count>0; i++)
                    {
                        FilesStructures _row = queueRows.Dequeue();
                        var text = string
                            .Join("\n",
                                      _row.Article,
                                      _row.Group,
                                      _row.Model,
                                      _row.SN,
                                      _row.IN,
                                      _row.Provider,
                                      _row.Owner,
                                      _row.Date
                            );
                        qrA4.LstQrcodesTxts.Add(new QrTxt(_row.Article, text));
                    }
                    ResultImage = qrA4.QRGenerate();
                    if (ResultImage != null)
                    {
                       //pictureBoxQR.Image = ResultImage;
                        Filename = $"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss_fff", null)}.bmp";
                        ResultImage.Save(Filename);
                    }
                }
                
        }


        void CreateQRCodsFromTxt(string LargTxt)
        {
            ResultImage = null;
            Filename = $"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss", null)}.bmp";

            QRCodes qrA4 = new QRCodes();
            for (int i = 0; i < QRCodes.CNTS_IMAGES_MAX; i++)
                qrA4.LstQrcodesTxts.Add(new QrTxt(DateTime.Now.ToString("F"), LargTxt));
            ResultImage = qrA4.QRGenerate();

            if (ResultImage != null)
                pictureBoxQR.Image = ResultImage;

        }

    }


}
