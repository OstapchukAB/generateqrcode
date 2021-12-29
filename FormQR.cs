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
                using (Bitmap bmp = new Bitmap(2100, 2970))
                {
                   
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                            
                        g.DrawImage(lstBitmap[0], 0,    0,     w_img, h_img);
                        g.DrawString(  lstTxt[0],new Font("Tahoma", size_txt),Brushes.Black,new RectangleF(delta_x_text, delta_y_text, w_text, h_text));
                        
                        g.DrawImage(lstBitmap[1], 0,  650,     w_img, h_img);
                        g.DrawString(  lstTxt[1], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(delta_x_text, 650+delta_y_text, w_text, h_text));

                        g.DrawImage(lstBitmap[2], 0, 1300,     w_img, h_img);
                        g.DrawString(  lstTxt[2], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(delta_x_text, 1300 + delta_y_text, w_text, h_text));
                        
                        g.DrawImage(lstBitmap[3], 0, 1950,     w_img, h_img);
                        g.DrawString(  lstTxt[3], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(delta_x_text, 1950 + delta_y_text, w_text, h_text));

                        //****************************
                        g.DrawImage(lstBitmap[4], 650, 0,      w_img, h_img);
                        g.DrawString(  lstTxt[4], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(650+delta_x_text, delta_y_text, w_text, h_text));
                        
                        g.DrawImage(lstBitmap[5], 650, 650,    w_img, h_img);
                        g.DrawString(lstTxt[5], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(650 + delta_x_text, 650+delta_y_text, w_text, h_text));
                        
                        g.DrawImage(lstBitmap[6], 650, 1300,   w_img, h_img);
                        g.DrawString(  lstTxt[6], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(650 + delta_x_text,1300+ delta_y_text, w_text, h_text));
                        
                        g.DrawImage(lstBitmap[7], 650, 1950,   w_img, h_img);
                        g.DrawString(  lstTxt[7], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(650 + delta_x_text, 1950+delta_y_text, w_text, h_text));

                        //*****************************************
                        g.DrawImage(lstBitmap[8], 1300, 0,     w_img, h_img);
                        g.DrawString(  lstTxt[8], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(1300 + delta_x_text, delta_y_text, w_text, h_text));

                        g.DrawImage(lstBitmap[9], 1300, 650,   w_img, h_img);
                        g.DrawString(  lstTxt[9], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(1300 + delta_x_text, 650+delta_y_text, w_text, h_text));

                        g.DrawImage(lstBitmap[10], 1300, 1300, w_img, h_img);
                        g.DrawString(  lstTxt[10], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(1300 + delta_x_text, 1300+delta_y_text, w_text, h_text));

                        g.DrawImage(lstBitmap[11], 1300, 1950, w_img, h_img);
                        g.DrawString(  lstTxt[11], new Font("Tahoma", size_txt), Brushes.Black, new RectangleF(1300 + delta_x_text, 1950+delta_y_text, w_text, h_text));

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
