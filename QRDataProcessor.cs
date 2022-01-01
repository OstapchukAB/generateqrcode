using System;
using System.Collections.Generic;

namespace GenerateQRcode
{
    class QRDataProcessor : IDataProcessor
    {
        public List<DataStructure> LstStringParsingData { get; private set; }

        public List<ReturnDataForQR> ProcessCreateQR(List<DataStructure> dataStructures)
        {
            throw new NotImplementedException();
        }

        public void ProcessData(IDataProvider dataProvider)
        {
            Console.WriteLine($"Провайдер данных: {dataProvider.GetType()}");

            if (ProcessDataStart(dataProvider))
            {
                Console.WriteLine("Старт передачи данных!");

                dataProvider.GetData();
                LstStringParsingData = dataProvider.ParsingData();
               
                //Console.WriteLine(s);
                ProcessDataSuccess(true);
            }
            else
            {
                Console.WriteLine("Нет передачи данных!");
                ProcessDataSuccess(false);
            }
            Console.WriteLine("-------------");
        }

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
