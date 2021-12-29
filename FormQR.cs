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

                int cnts = 12;
                List<Bitmap> lstBitmap = new List<Bitmap>(cnts);
                List<string> lstTxt = new List<string>(cnts);
                for (int i = 0; i < cnts; i++) 
                {
                    lstBitmap.Add(qrCodeImage);
                    lstTxt.Add($"OMZ_PRI_HP_00{i}");
                
                }

                //int x_img = 0;
                //int delta_x_img = 650;
                //int delta_y_img=
                //int y_img = 0;
                int w_img = 550;
                int h_img = 550;
                int delta_x_text = 40;
                int delta_y_text = 550;
                int w_text = w_img;
                int h_text = 60;
                int size_txt = 38;
                int page_w = 2100;
                int page_h = 2970;
                using (Bitmap bmp = new Bitmap(page_w, page_h))
                {
                   
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        int idx = 0;
                        int delta_img_x = 650;
                        for (int i = 0; i < 3; i++)
                        {
                            int delta_img_y = 650;
                            for (int j = 0; j < 4; j++)
                            {
                                int x = i * delta_img_x;
                                int y = j * delta_img_y;
                                g.DrawImage(lstBitmap[idx], x, y, w_img, h_img);
                                g.DrawString(lstTxt[idx], 
                                    new Font("Tahoma", size_txt),
                                    Brushes.Black,
                                    new RectangleF(x+delta_x_text, y+delta_y_text, w_text, h_text));
                                idx++;
                            }

                        }
                      
                        g.Flush();

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
