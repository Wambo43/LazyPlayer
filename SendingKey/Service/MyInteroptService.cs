using SendingKey.Data;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SendingKey.Service
{
    public class MyInteroptService
    {
        public Process Process { get; set; }
        // import the function in your class
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);
        public MyInteroptService()
        {  }

        public void Init(string processName)
        {
            MyProcessService myProcess = new MyProcessService();
            this.Process = myProcess.GetProcessByName(processName);
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
                        SetForegroundWindow(intPtr);
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
