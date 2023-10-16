using System;
using System.IO;
using System.Windows.Forms;

using Forms;

namespace NetworkBlackjackGUI
{
    
    static class NetworkBlackjackGUI
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectMode());
        }
    }
}
