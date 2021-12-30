using System;
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
            ResultImage = null;
            Filename= $"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss", null)}.bmp";
            var LargTxt = richTextBoxStrinfForQR.Text;
           
            QRCodes qrA4 = new QRCodes();
            for(int i=0;i<QRCodes.CNTS_IMAGES_MAX;i++)
                qrA4.LstQrcodesTxts.Add(new QrTxt(Filename, DateTime.Now.ToString(), LargTxt));
            ResultImage = qrA4.QRGenerate();

            if (ResultImage != null)
                pictureBoxQR.Image = ResultImage;

        }


        private void buttonSaveQR_Click(object sender, EventArgs e)
        {
            if (ResultImage != null) {
                ResultImage.Save(Filename);
            }
        }

        
    }
    

}
