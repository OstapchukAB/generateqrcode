using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQRcode
{
    public partial class FormQR : Form
    {

        public FormQR()
        {
            InitializeComponent();
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void buttonQRcreate_Click(object sender, EventArgs e)
        {
            pictureBoxQR.Image = null;
            var LargTxt = richTextBoxStrinfForQR.Text;
            var richTextBox = new RichTextBoxDataProvider(LargTxt);
            CreateQRCods(richTextBox, richTextBox);

        }




        private void buttonLoadFromFile_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (CSV)|*.csv;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                var csv = new CSVDataProvider(openFile.FileName);
                CreateQRCods(csv, csv);
            }
        }

        async void CreateQRCods(IDataProvider _dataProvider, IDataProcessor _dataProcessor)
        {
           // progressBar1.Minimum = 0;
           // progressBar1.Maximum = 100;
            await Task.Run(() =>
                {
                    try
                    {
                        IDataProvider dataProvider = _dataProvider;
                        IDataProcessor dataProcessor = _dataProcessor;

                        if (dataProcessor.ProcessDataStart(dataProvider))
                            if (dataProvider.GetData())
                                if (dataProvider.ParsingData())
                                {
                                    var LstQR = dataProcessor.ProcessCreateQR(this);
                                    //var cnts = LstQR.Count;
                                    //var j = 0;
                                    //Progress(j);

                                    if (LstQR != null)
                                        foreach (var dt in LstQR)
                                        {
                                            //j++;
                                            dt.ResultImage.Save(dt.Filename);
                                           // Progress((int)(j * 100 / cnts));
                                            
                                            PictureBoxQR(dt.ResultImage);
                                        }
                                }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                });
            MessageBox.Show("Завершено!");
        }



        private void FormQR_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            //progressBar1.Maximum = 100;
        }

        private void PictureBoxQR(Bitmap bitmap)
        {
            Action action = () =>
            {
                pictureBoxQR.Image = bitmap;
            };
            if (InvokeRequired)
                BeginInvoke(action);
            else
                action();
        }

        public void Progress(int v,int max)
        {
            Action action = () =>
            {
                progressBar1.Maximum = max;
                progressBar1.Value = v;
                labelProgressBar.Text = v.ToString() + "%";
                //labelProgressText.Text = s;
            };
            if (InvokeRequired)
                BeginInvoke(action);
            else
                action();
        }
    }
}
