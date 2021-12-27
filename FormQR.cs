using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQRcode
{
    public partial class FormQR : Form
    {
        Bitmap qrCodeImage;
        public FormQR()
        {
            InitializeComponent();
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void buttonQRcreate_Click(object sender, EventArgs e)
        {
            _QRGenerate();
        }

        void _QRGenerate()
        {
            string txt = "";
            qrCodeImage = null;

            if (richTextBoxStrinfForQR.Text != null && richTextBoxStrinfForQR.Text.Length > 0)
            {
                txt = richTextBoxStrinfForQR.Text;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(txt, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                qrCodeImage = qrCode.GetGraphic(20);
                pictureBoxQR.Image = qrCodeImage;
            }
        }

        private void buttonSaveQR_Click(object sender, EventArgs e)
        {
            if (qrCodeImage != null) {
                qrCodeImage.Save($"{richTextBoxStrinfForQR.Text}.bmp");
            
            }
        }
    }
}
