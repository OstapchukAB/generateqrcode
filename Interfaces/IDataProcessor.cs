using System.Collections.Generic;
using System.Drawing;

namespace GenerateQRcode
{
    interface  IDataProcessor
    {
        
        bool ProcessDataStart(IDataProvider dataProvider);
        void ProcessCreateQR();
        void ProcessSaveFiles(List<DataStructureQR> lstStructuresQRs);
    }
}
