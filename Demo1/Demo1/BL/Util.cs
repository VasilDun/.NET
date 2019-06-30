using System.Windows;
using System.Windows.Forms;

namespace Demo1.BL
{ 
    public static class Util
    {    
        public static void Error(string caption, string message)
        {
            System.Windows.Forms.MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        public static void Info(string caption, string message)
        {
            System.Windows.Forms.MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
    }
}
