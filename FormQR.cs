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
        List<DataStructureQR> DataStructureQR { get; set; }
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
                    // QRDataProcessor qrDataProcessor = new QRDataProcessor();
                    IDataProcessor dataProcessor = new QRDataProcessor();
                    IDataProvider dataProvider = new TxtCSVDataProvider(openFile.FileName);

                    if (dataProcessor.ProcessDataStart(dataProvider))
                    {
                        if (dataProvider.GetData())
                        {
                            var resultParsing = dataProvider.ParsingData();
                            if (resultParsing != null)
                            {
                                DataStructureQR = dataProcessor.ProcessCreateQR(resultParsing);
                                if (DataStructureQR != null)
                                    foreach (var dt in DataStructureQR)
                                        dt.ResultImage.Save(dt.Filename);
                            }
                        }
                    }
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                MessageBox.Show("Завершено!");

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

        private void FormQR_Load(object sender, EventArgs e)
        {

        }
    }


}
