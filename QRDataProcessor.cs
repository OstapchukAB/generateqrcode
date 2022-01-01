using System;
using System.Collections.Generic;
using System.Drawing;

namespace GenerateQRcode
{
    class QRDataProcessor : IDataProcessor
    {
       // public List<DataStructureEntity> LstStringParsingData { get; private set; }

        public List<DataStructureQR> ProcessCreateQR(List<DataStructureEntity> dataStructures)
        {
            var queueRows = new Queue<DataStructureEntity>();
            foreach (var v in dataStructures)
                queueRows.Enqueue(v);
            List<DataStructureQR> returnData = new List<DataStructureQR>();

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
                    returnData.Add(new DataStructureQR
                    {
                        Filename = filename,
                        ResultImage = resultImage
                    });
                }
            }
            return returnData;

        }

        //public void ProcessData(IDataProvider dataProvider)
        //{
        //    Console.WriteLine($"Провайдер данных: {dataProvider.GetType()}");

        //    if (ProcessDataStart(dataProvider))
        //    {
        //        Console.WriteLine("Старт передачи данных!");

        //       // dataProvider.GetData();
        //       // LstStringParsingData = 
        //           // dataProvider.ParsingData();
        //       // ProcessDataSuccess(true);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Нет передачи данных!");
        //        ProcessDataSuccess(false);
        //    }
        //    Console.WriteLine("-------------");
        //}

        public bool ProcessDataStart(IDataProvider dataProvider)
        {
            if (dataProvider.SourceDataProviderReady())
            {
                Console.WriteLine("Источник данных готов!");
                return true;
            }
            else
            {
                Console.WriteLine("Источник данных не готов!");
                return false;
            }

        }

        public bool ProcessDataSuccess(bool eof)
        {
            if (eof)
            {
                Console.WriteLine("Данные переданы успешно!");
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка передачи данных!");
                return false;
            }

        }


    }
}
