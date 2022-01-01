using System.Collections.Generic;

namespace GenerateQRcode
{
    interface  IDataProcessor
    {

        //void ProcessData(IDataProvider dataProvider);
        bool ProcessDataSuccess(bool eof);
        bool ProcessDataStart(IDataProvider dataProvider);

        List<DataStructureQR> ProcessCreateQR(List<DataStructureEntity> dataStructures);
       
    }
}
