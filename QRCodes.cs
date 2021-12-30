using QRCoder;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace GenerateQRcode
{
    public class QRCodes
    {
        Bitmap QrCodeImage { get; set; }
        Bitmap ResultImage { get; set; }
        const int WITH_BITMAP = 550;
        const int HEIGH_BITMAP = 550;
        const int DELTA_IMAGES = 100;
        const int DELTA_X_SIGNATURES = 60;
        const int DELTA_Y_SIGNATURES = HEIGH_BITMAP-40;
        const int WITH_SIGNATURES = WITH_BITMAP;
        const int HEIGH_SIGNATURES = 60;
        const int SIZE_SIGNATURES = 30;
        const int PAGE_WITH = 2100;
        const int PAGE_HEIGH = 2970;
        const int IMAGES_CNTS_FOR_HEIGH = 4;
        const int IMAGES_CNTS_FOR_WITH = 3;
        public const int CNTS_IMAGES_MAX = IMAGES_CNTS_FOR_HEIGH * IMAGES_CNTS_FOR_WITH;
        public List<QrTxt> LstQrcodesTxts { get; set; } =new List<QrTxt>();

       


        public QRCodes(List<QrTxt> qrTxts)
        {
            if (qrTxts.Count == 0 || qrTxts.Count > CNTS_IMAGES_MAX)
                return;
            //LstQrcodesTxts  = new List<QrTxt>(qrTxts.Count);
            this.LstQrcodesTxts = qrTxts;
        }

        public QRCodes()
        {
        }

        public Bitmap QRGenerate()
        {
            
            QrCodeImage = null;
            ResultImage = null;

            if (LstQrcodesTxts.Count > CNTS_IMAGES_MAX || LstQrcodesTxts.Count == 0)
                return ResultImage;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            List<Bitmap> lstBitmap = new List<Bitmap>(LstQrcodesTxts.Count);

            for (int i = 0; i < LstQrcodesTxts.Count; i++)
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(LstQrcodesTxts[i].LargeText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                QrCodeImage = qrCode.GetGraphic(20);
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
                    int delta_img_x = WITH_BITMAP + DELTA_IMAGES;
                    for (int i = 0; i < IMAGES_CNTS_FOR_WITH && idx< LstQrcodesTxts.Count; i++)
                    {
                        int delta_img_y = HEIGH_BITMAP + DELTA_IMAGES;
                        for (int j = 0; j < IMAGES_CNTS_FOR_HEIGH && idx < LstQrcodesTxts.Count; j++)
                        {
                            int x = i * delta_img_x;
                            int y = j * delta_img_y;
                            g.DrawImage(lstBitmap[idx], x, y, WITH_BITMAP, HEIGH_BITMAP);
                            g.DrawString(LstQrcodesTxts[idx].Signatures,
                                new Font("Tahoma", SIZE_SIGNATURES),
                                Brushes.Black,
                                new RectangleF(x + DELTA_X_SIGNATURES, y + DELTA_Y_SIGNATURES, WITH_SIGNATURES, HEIGH_SIGNATURES));
                            idx++;
                        }
                    }
                    g.Flush();
                }
                ResultImage = new Bitmap(bmp);
            }
            return ResultImage;
        }

    }

    public class QrTxt
    {
        public QrTxt(string signatures, string txt)
        {
            //Fname = fname;
            Signatures = signatures;
            LargeText = txt;
        }

        //public string Fname { get; private set; }
        public string Signatures { get; private set; }
        public string LargeText { get; private set; }

    }


}
