using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQRcode
{
    public partial class FormQR : Form
    {
        Bitmap qrCodeImage;
        Bitmap resultImage;
        public FormQR()
        {
            InitializeComponent();
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBoxQR.
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
                

                using (Bitmap bmp = new Bitmap(2100, 2970))
                {
                    RectangleF rectf = new RectangleF(40, 550, 550, 60);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(qrCodeImage, 0, 0, 550, 550);

                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.DrawString("OMZ_PRI_HP_0086", new Font("Tahoma", 38), Brushes.Black, rectf);
                        g.Flush();


                        /*
                        g.DrawImage(qrCodeImage, 0,  650, 550, 550);
                        g.DrawImage(qrCodeImage, 0, 1300, 550, 550);
                        g.DrawImage(qrCodeImage, 0, 1950, 550, 550);

                        g.DrawImage(qrCodeImage, 650, 0, 550, 550);
                        g.DrawImage(qrCodeImage, 650, 650, 550, 550);
                        g.DrawImage(qrCodeImage, 650, 1300, 550, 550);
                        g.DrawImage(qrCodeImage, 650, 1950, 550, 550);

                        g.DrawImage(qrCodeImage, 1300, 0, 550, 550);
                        g.DrawImage(qrCodeImage, 1300, 650, 550, 550);
                        g.DrawImage(qrCodeImage, 1300, 1300, 550, 550);
                        g.DrawImage(qrCodeImage, 1300, 1950, 550, 550);
                        */
                    }
                    resultImage = new Bitmap(bmp);
                }

                pictureBoxQR.Image = resultImage;
            }
        }

        private void buttonSaveQR_Click(object sender, EventArgs e)
        {
            if (resultImage != null) {
                resultImage.Save($"{richTextBoxStrinfForQR.Text}.bmp");
            
            }
        }
    }
}
