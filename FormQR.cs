using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace GenerateQRcode
{
    public partial class FormQR : Form
    {
        Bitmap QrCodeImage { get; set; }
        Bitmap ResultImage { get; set; }
        const int WITH_BITMAP = 550;
        const int HEIGH_BITMAP = 550;
        const int DELTA_IMAGES = 100;
        const int DELTA_X_TEXT = 40;
        const int DELTA_Y_TEXT = HEIGH_BITMAP;
        const int WITH_TEXT = WITH_BITMAP;
        const int HEIGH_TEXT = 60;
        const int SIZE_SIGNATURES = 38;
        const int PAGE_WITH = 2100;
        const int PAGE_HEIGH = 2970;
        const int IMAGES_CNTS_FOR_HEIGH = 4;
        const int IMAGES_CNTS_FOR_WITH = 3;
        const int CNTS_IMAGES = 12;
        List<QrTxt> LstQrTxt { get; set; }=new List<QrTxt>();
        public FormQR()
        {
            InitializeComponent();
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void buttonQRcreate_Click(object sender, EventArgs e)
        {
            QRGenerate();
        }

        void QRGenerate()
        {
            var filename = $"{richTextBoxStrinfForQR.Text}.bmp";
            QrCodeImage = null;

            if (richTextBoxStrinfForQR.Text != null && richTextBoxStrinfForQR.Text.Length > 0)
            {
                var txt = richTextBoxStrinfForQR.Text;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(txt, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                QrCodeImage = qrCode.GetGraphic(20);

                List<Bitmap> lstBitmap = new List<Bitmap>(CNTS_IMAGES);
               
                for (int i = 0; i < CNTS_IMAGES; i++) 
                {
                    LstQrTxt.Add(new QrTxt(filename, $"OMZ_PRI_HP_00{i}",txt));   
                    lstBitmap.Add(QrCodeImage);
                
                }
                using (Bitmap bmp = new Bitmap(PAGE_WITH, PAGE_HEIGH))
                {
                   
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        int idx = 0;
                        int delta_img_x = WITH_BITMAP+DELTA_IMAGES;
                        for (int i = 0; i < IMAGES_CNTS_FOR_WITH; i++)
                        {
                            int delta_img_y = HEIGH_BITMAP+DELTA_IMAGES;
                            for (int j = 0; j < IMAGES_CNTS_FOR_HEIGH; j++)
                            {
                                int x = i * delta_img_x;
                                int y = j * delta_img_y;
                                g.DrawImage(lstBitmap[idx], x, y, WITH_BITMAP, HEIGH_BITMAP);
                                g.DrawString(LstQrTxt[idx].Signatures, 
                                    new Font("Tahoma", SIZE_SIGNATURES),
                                    Brushes.Black,
                                    new RectangleF(x+DELTA_X_TEXT, y+DELTA_Y_TEXT, WITH_TEXT, HEIGH_TEXT));
                                idx++;
                            }

                        }
                      
                        g.Flush();

                    }
                    ResultImage = new Bitmap(bmp);
                }

                pictureBoxQR.Image = ResultImage;
            }
        }

        private void buttonSaveQR_Click(object sender, EventArgs e)
        {
            if (ResultImage != null) {
                ResultImage.Save($"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss",null)}.bmp");
            
            }
        }

        
    }
    public class QrTxt
    {
        public QrTxt(string fname, string signatures, string txt)
        {
            Fname = fname;
            Signatures = signatures;
            LargeText = txt;
        }

        public string Fname { get; private set; }
        public string Signatures { get; private set; }
        public string LargeText { get; private set; }

    }

}
