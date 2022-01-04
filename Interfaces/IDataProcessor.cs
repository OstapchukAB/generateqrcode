using System.Collections.Generic;

namespace GenerateQRcode
{
    interface  IDataProcessor
    {
        bool ProcessDataStart(IDataProvider dataProvider);
        List<DataStructureQR> ProcessCreateQR();

    }
}
