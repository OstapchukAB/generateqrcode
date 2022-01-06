using System.Drawing;

namespace GenerateQRcode
{
    interface IFormGUI
    {
        void Progress(int count);
        void PictureBoxQR(Bitmap bitmap);
    }
}
