using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Hnc.Calorimeter.Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool isAlone;
            Mutex mutex = new Mutex(true, @"Global\Hnc.Calorimeter.Client", out isAlone);

            if (isAlone == true)
            {
                WindowsFormsSettings.ForceDirectXPaint();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    Resource.CreateLogger();
                    Application.Run(new FormClientMain());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Resource.Destroy();
                    Resource.TLog.Log((int)ELogItem.Note, "Destroy program resource");

                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show(
                    "Cannot run this program because of running it already!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
            }
        }
    }
}
