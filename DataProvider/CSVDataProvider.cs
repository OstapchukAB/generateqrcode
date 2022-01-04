using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GenerateQRcode
{
    class CSVDataProvider : IDataProvider, IDataProcessor

    {
        string PathFile { get; set; }
        public List<string> LstStringData { get; set; } = new List<string>();
        public List<DataStructureEntity> LstParsingData { get; private set; } = new List<DataStructureEntity>();
       // public List<DataStructureQR> LstStructureQRs { get; private set; }= new List<DataStructureQR>();


        public CSVDataProvider(string PathFile)
        {
            this.PathFile = PathFile;

        }

        public bool SourceDataProviderReady()
        {
            if (PathFile != null && PathFile.Length > 0)
                return true;
            else
                return false;
        }

        bool IDataProvider.GetData()
        {
           LstStringData= File.ReadAllLines(PathFile)
               .Skip(1)
               .Where(row => row.Length > 0)
               .ToList();
            return true;
        }

        bool IDataProvider.ParsingData()
        {
            LstParsingData.Clear();
            string patern = @",(?=(?:[^']*'[^']*')*[^']*$)";


            var lststringData = LstStringData.Select(x => Regex.Split(x.Replace("\"", "'"), patern));
            
            //List<DataStructureEntity> data = new List<DataStructureEntity>();
            foreach (var columns in lststringData)
            {
                
                
                LstParsingData.Add(new DataStructureEntity
                {

                    Article = $"Article: {columns[0]}",
                    Group = $"Group: {columns[1].Replace("\'","")}",
                    Vendor= $"Vendor: {columns[2]}",
                    Provider = $"Provider: {columns[3].Replace("\'", "")}",
                    Model = $"Model: {columns[4].Replace("\'", "")}",
                    SN = $"SN: {columns[5].Replace("\'", "")}",
                    IN = $"IN: {columns[6].Replace("\'", "")}",
                    Owner = $"Owner: {columns[7].Replace("\'", "")}",
                    Date = DateTime.Now.ToString("D"),

                });
            }
           // LstParsingData = data;
            return true;
        }

        List<DataStructureQR> IDataProcessor.ProcessCreateQR()
        {
            var LstStructureQRs = new List<DataStructureQR>();
            var queueRows = new Queue<DataStructureEntity>();
            foreach (var v in LstParsingData)
                queueRows.Enqueue(v);
            //List<DataStructureQR> returnData = new List<DataStructureQR>();

            Bitmap resultImage;
            string filename;

            //прочтем всю очередь по 12 подходов или пока очередь не закончится
            while (queueRows.Count > 0)
            {

                var qrA4 = new QRCodes();
                for (int i = 0; i < QRCodes.CNTS_IMAGES_MAX && queueRows.Count > 0; i++)
                {
                    DataStructureEntity _row = queueRows.Dequeue();
                    var text = string
                        .Join("\n",
                                  _row.Article,
                                  _row.Group,
                                  _row.Vendor,
                                  _row.Model,
                                  _row.SN,
                                  _row.IN,
                                  _row.Provider,
                                  _row.Owner,
                                  _row.Date
                        );
                    qrA4.LstQrcodesTxts.Add(new QrTxt(_row.Article, text));
                }
                resultImage = qrA4.QRGenerate();
                if (resultImage != null)
                {
                    //pictureBoxQR.Image = ResultImage;
                    filename = $"QR_CODE_{DateTime.Now.ToString("yyyyddMM_HHmmss_fff", null)}.bmp";
                    //ResultImage.Save(Filename);
                    LstStructureQRs.Add(new DataStructureQR
                    {
                        Filename = filename,
                        ResultImage = resultImage
                    });
                }
            }

            return LstStructureQRs;
        }

        public bool ProcessDataStart(IDataProvider dataProvider)
        {
            if (dataProvider.SourceDataProviderReady())
            {
                Console.WriteLine("Источник данных готов!");
                Console.WriteLine("Можно начинать передачу!");
                return true;
            }
            else
            {
                Console.WriteLine("Источник данных не готов!");
                return false;
            }
        }

       
    }


}
