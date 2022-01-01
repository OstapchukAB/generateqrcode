using System.Collections.Generic;

namespace GenerateQRcode
{
    interface IDataProvider
    {
        bool SourceDataProviderReady();
        bool GetData();
        List<DataStructureEntity> ParsingData();
       

    }
}
