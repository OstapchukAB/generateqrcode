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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    List<FilesStructures> lstTxt = new LoadTxtFromFile().ReadFromCSV(filePath);
                        ResultImage = null;
                        Filename = $"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss", null)}.bmp";

                        QRCodes qrA4 = new QRCodes();
                        for (int i = 0; i < QRCodes.CNTS_IMAGES_MAX; i++)
                        {
                            var text = string.Join("\n", 
                                lstTxt[i].Article,
                                lstTxt[i].Group,
                                lstTxt[i].Model,
                                lstTxt[i].SN,
                                lstTxt[i].IN,
                                lstTxt[i].Provider,
                                lstTxt[i].Owner,
                                lstTxt[i].Date
                                );
                            qrA4.LstQrcodesTxts.Add(new QrTxt(lstTxt[i].Article, text));
                        }
                        ResultImage = qrA4.QRGenerate();

                        if (ResultImage != null)
                            pictureBoxQR.Image = ResultImage;
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
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
