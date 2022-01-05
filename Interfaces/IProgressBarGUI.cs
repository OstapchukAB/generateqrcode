using System.Windows.Forms;

namespace GenerateQRcode
{
    interface IProgressBarGUI
    {
        void Progress(int count);
    }
}
