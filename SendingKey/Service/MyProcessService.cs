using System.Diagnostics;
using System.Linq;


namespace SendingKey.Data
{
    public static class MyProcessService
    {
        
        public static Process GetProcessByName(string processName)
        {
            var p = Process.GetProcesses();
            return Process.GetProcessesByName(processName).FirstOrDefault();
        }
        public static Process[] GetProcess()
        {
            return Process.GetProcesses();
        }
    }
}
