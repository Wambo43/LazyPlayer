using SendingKey.Data;
using SendingKey.Rules;
using SendingKey.Service;
using System.Diagnostics;
using System.Threading;

namespace SendingKey.Controller
{
    public class FishingController
    {
        
        public bool ThreadIsAlive
        {
            get
            {
                if (oThread != null)
                {
                    return this.oThread.IsAlive;
                }
                return false;
            }
        }

        private Thread oThread;
        private DataRulesFishingContainer dataRules;
        public FishingController(string porcessName,string EjectAngel, string MouseInteraktiv)
        {
            Init(porcessName, EjectAngel, MouseInteraktiv);
        }

        public void Init(string porcessName,string EjectAngel, string MouseInteraktiv)
        {
            this.dataRules = new DataRulesFishingContainer();
            this.dataRules.MyInteroptService = new MyInteroptService(porcessName);
            this.dataRules.EjectAngelKey = EjectAngel;
            this.dataRules.MouseInteraktKey = MouseInteraktiv;
        }

        public bool StartProces()
        {
            this.oThread = new Thread(Fishing);
            this.oThread.Start(this.dataRules);
            return this.oThread.IsAlive;
        }
        public bool AportProcess()
        {
            this.oThread.Abort();
            Debug.WriteLine("Worker Thread Quits..!");
            return this.oThread.IsAlive;
        }

        private void Fishing(object dataRulesContainer)
        {
            FischingRules fischingRules = new FischingRules();
            fischingRules.Fisching(dataRulesContainer);
        }
    }
}
