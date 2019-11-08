using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using SendingKey.Data;
using SendingKey.Rules;

namespace SendingKey.Service
{
    /// <summary>
    /// static ???? thread sicher machen
    /// </summary>
    public class MyInteroptService
    {
        public Process Process { get; set; }
        // import the function in your class
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        public MyInteroptService(string processName)
        {
            Init(processName);
        }

        public void Init(string processName)
        {
            this.Process = MyProcessService.GetProcessByName(processName);
        }

        public void SetProcessForegroundWindow()
        {
            try
            {
                IntPtr intPtr = this.Process.MainWindowHandle;
                if (intPtr != IntPtr.Zero)
                {
                    SetForegroundWindow(intPtr);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("########################################");
                Debug.WriteLine(e.Message);
            }
        }

        public void SendKeyToProcess(string key)
        {
            try
            {
                if (this.Process != null)
                {
                    IntPtr intPtr = this.Process.MainWindowHandle;
                    if (intPtr != IntPtr.Zero)
                    {
                        //SetForegroundWindow(intPtr);
                        SendKeys.SendWait(key);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("########################################");
                Debug.WriteLine(e.Message);
            }
        }
    }
}
