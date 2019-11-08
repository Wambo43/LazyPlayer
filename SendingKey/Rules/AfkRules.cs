using System.Diagnostics;
using System.Threading;

using SendingKey.Data;
using SendingKey.Helper;
using SendingKey.Service;

namespace SendingKey.Rules
{
    public class AfkRules
    {

        public AfkRules()
        { }
        public void easyAfkWorkThread(object dataRulesContainer)
        {
            DataRulesAfkContainer dataRules = dataRulesContainer as DataRulesAfkContainer;
            var myInteropt = dataRules.MyInteroptService as MyInteroptService;
            SpecifyCharacters sC= new SpecifyCharacters();
            if (myInteropt != null)
            {
                Debug.WriteLine("Worker Thread is in progress..!");
                while (true)
                {
                    Thread.Sleep(dataRules.loopTimer); //Sleep for 2 seconds
                    myInteropt.SendKeyToProcess("a");
                    Thread.Sleep(dataRules.CommandTimer);
                    myInteropt.SendKeyToProcess(sC.GetSpace());
                }
            }
            Debug.WriteLine("Worker Thread cant start..!");
        }

        public void advancedAfkWorkThread(object dataRulesContainer)
        {
            DataRulesAfkContainer dataRules = dataRulesContainer as DataRulesAfkContainer;
            var myInteropt = dataRules.MyInteroptService as MyInteroptService;
            SpecifyCharacters sC = new SpecifyCharacters();
            if (myInteropt != null)
            {
                Debug.WriteLine("Worker Thread is in progress..!");
                while (true)
                {
                    Thread.Sleep(dataRules.loopTimer); //Sleep for 2 seconds
                    foreach (string command in dataRules.keyWords)
                    {
                        myInteropt.SendKeyToProcess(command);
                        Thread.Sleep(dataRules.CommandTimer);
                    }
                }
            }
            Debug.WriteLine("Worker Thread cant start..!");
        }
    }
}
