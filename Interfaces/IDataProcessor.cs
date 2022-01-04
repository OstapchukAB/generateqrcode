using System.Collections.Generic;
using System.Windows.Forms;

namespace GenerateQRcode
{
    interface  IDataProcessor
    {
        bool ProcessDataStart(IDataProvider dataProvider);
        List<DataStructureQR> ProcessCreateQR(FormQR frm);
        void Progress(int count,FormQR frm);

        //List<DataStructureQR> ProcessCreateQR();
    }
}
