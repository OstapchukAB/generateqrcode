namespace GenerateQRcode
{
    interface  IDataProcessor
    {
        bool ProcessDataStart(IDataProvider dataProvider);
        bool ProcessCreateQR();

    }
}
