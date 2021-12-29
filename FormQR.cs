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

                int _cnts_images = 12;
                List<Bitmap> lstBitmap = new List<Bitmap>(_cnts_images);
                List<string> lstTxt = new List<string>(_cnts_images);
                for (int i = 0; i < _cnts_images; i++) 
                {
                    lstBitmap.Add(qrCodeImage);
                    lstTxt.Add($"OMZ_PRI_HP_00{i}");
                
                }

                int w_img = 550;
                int h_img = 550;
                int delta_images = 100;
                int delta_x_text = 40;
                int delta_y_text = h_img;
                int w_text = w_img;
                int h_text = 60;
                int size_txt = 38;
                int page_w = 2100;
                int page_h = 2970;
                int h_cnts_images = 4;
                int w_cnts_images = 3;
                using (Bitmap bmp = new Bitmap(page_w, page_h))
                {
                   
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        int idx = 0;
                        int delta_img_x = w_img+delta_images;
                        for (int i = 0; i < w_cnts_images; i++)
                        {
                            int delta_img_y = h_img+delta_images;
                            for (int j = 0; j < h_cnts_images; j++)
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
