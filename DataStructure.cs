using System.Drawing;

namespace GenerateQRcode
{
    public class DataStructure
    {
        public string Article { get; set; }
        public string Group { get; set; }
        public string Provider { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public string IN { get; set; }
        public string Owner { get; set; }
        public string Date { get; set; }
    }
    public class ReturnDataForQR {
        public Bitmap ResultImage { get; set; }
        public string Filename { get; set; }


    }
}
