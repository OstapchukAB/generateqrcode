namespace GenerateQRcode
{
    interface IDataProvider
    {
        bool SourceDataProviderReady();
        bool GetData();
        bool ParsingData();
    }
}
