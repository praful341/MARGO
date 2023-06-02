using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MARGO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main(String[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool bNew = true;

            // There can be only one... instance of this application on a machine.
            using (Mutex mutex = new Mutex(true, "MYAPP_2D36E4C1-599F-6b07-DDA5-GE059FB77E8FT", out bNew))  //       +2 
            {
                if (bNew)
                {
                    Application.Run(new FrmMain());
                    //Application.Run(new FrmLogin());
                    Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
                }
                else
                {
                    Process me = Process.GetCurrentProcess();
                    foreach (Process proc in Process.GetProcessesByName(me.ProcessName))
                    {
                        if (proc.Id != me.Id)
                        {
                            SetForegroundWindow(proc.MainWindowHandle);
                            break;
                        }
                    }
                }  // if
            }     // using

        }
    }
}
