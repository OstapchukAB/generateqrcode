using System.Collections.Generic;

namespace GenerateQRcode
{
    interface IDataProvider
    {
        bool SourceDataProviderReady();
        List<string> GetData();
        List<DataStructure> ParsingData();
       

    }
}
