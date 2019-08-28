using System.Diagnostics;
using System.Linq;


namespace SendingKey.Data
{
    public class MyProcessService
    {
        public MyProcessService()
        { }

        public Process GetProcessByName(string processName)
        { 
            return Process.GetProcessesByName(processName).FirstOrDefault();
        }
    }
}
