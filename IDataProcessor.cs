using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateQRcode
{
    interface  IDataProcessor
    {

        void ProcessData(IDataProvider dataProvider);
        bool ProcessDataSuccess(bool eof);
        bool ProcessDataStart(IDataProvider dataProvider);

        List<ReturnDataForQR> ProcessCreateQR(List<DataStructure> dataStructures);

    }
}
