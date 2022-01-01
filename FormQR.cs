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
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var csv = new CSVDataProvider(openFile.FileName);
                    IDataProvider dataProvider = csv;
                    IDataProcessor dataProcessor = csv;

                    if (dataProcessor.ProcessDataStart(dataProvider))
                        if (dataProvider.GetData())
                            if (dataProvider.ParsingData())
                                if (dataProcessor.ProcessCreateQR())
                                    if (csv.LstStructureQRs != null)
                                        foreach (var dt in csv.LstStructureQRs)
                                            dt.ResultImage.Save(dt.Filename);
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
            try
            {
                pictureBoxQR.Image = null;
               Filename = $"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss", null)}.bmp";
                var richTextBox = new RichTextBoxDataProvider(LargTxt);
                IDataProvider dataProvider = richTextBox;
                IDataProcessor dataProcessor = richTextBox;

                if (dataProcessor.ProcessDataStart(dataProvider))
                    if (dataProcessor.ProcessCreateQR())
                        if (richTextBox.ResultImage != null)
                        {
                            ResultImage= richTextBox.ResultImage;
                            pictureBoxQR.Image = ResultImage;
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }

        }

        private void FormQR_Load(object sender, EventArgs e)
        {

        }
    }


}
