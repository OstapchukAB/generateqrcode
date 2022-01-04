﻿using System;
using System.Drawing;

namespace GenerateQRcode
{
    class RichTextBoxDataProvider : IDataProvider, IDataProcessor
    {
        public Bitmap ResultImage { get; private set; }
        public string LargTxt { get; private set; }
        public RichTextBoxDataProvider(string txt)
        {
            LargTxt = txt;
        }

        public bool GetData()
        {
            return true;
        }

        public bool ParsingData()
        {
            return true;
        }

        public bool ProcessCreateQR()
        {
            QRCodes qrA4 = new QRCodes();
            for (int i = 0; i < QRCodes.CNTS_IMAGES_MAX; i++)
                qrA4.LstQrcodesTxts.Add(new QrTxt(DateTime.Now.ToString("F"), LargTxt));
            ResultImage = qrA4.QRGenerate();
            return true;
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

        public bool SourceDataProviderReady()
        {
           return LargTxt != null && LargTxt.Length>0;
        }
    }
}