using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

using SendingKey.Data;
using SendingKey.Helper;
using SendingKey.Rules;
using SendingKey.Service;

namespace SendingKey.Controller
{
    class AfkController
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
        private DataRulesAfkContainer dataRulesContainer = new DataRulesAfkContainer();

        public AfkController(string processName)
        {
            init(processName);
        }
        public void init(string processName)
        {
            this.dataRulesContainer = new DataRulesAfkContainer();
            this.dataRulesContainer.MyInteroptService = new MyInteroptService(this.dataRulesContainer.processName);
        }
        public bool StartProcess(string commandLine = "")
        {
            GetCommandLine(commandLine);
            oThread = new Thread(easyAfk);
            if (dataRulesContainer.keyWords.Count > 0)
            {
                oThread = new Thread(advancedAfk);
            }
            this.oThread.Start(this.dataRulesContainer);

            return this.oThread.IsAlive;
        }

        public bool AportProcess()
        {
            this.oThread.Abort();
            Debug.WriteLine("Worker Thread Quits..!");
            return this.oThread.IsAlive;
        }
        private void GetCommandLine(string commandLine)
        {
            if (String.IsNullOrEmpty(commandLine))
                return;
            convertCommand(commandLine.Replace("\n", "").Split('\r'));
        }

        private void convertCommand(IList<string> commandLine)
        {
            SpecifyCharacters sC = new SpecifyCharacters();
            foreach (string command in commandLine)
            {
                string c = command;
                if (command.Contains("SHIFT"))
                {
                    c = sC.GetShift(command.Replace("SHIFT ", ""));
                }
                else if (command.Contains("STRG"))
                {
                    c = sC.GetCtrl(command.Replace("STRG ", ""));
                }
                else if (command.Contains("ALT"))
                {
                    c = sC.GetAlt(command.Replace("ALT ", ""));
                }
                else if (command.Contains("Return"))
                {
                    c = sC.GetEnter();
                }

                if (!string.IsNullOrEmpty(c))
                    this.dataRulesContainer.keyWords.Add(c);
            }
        }

        private void easyAfk(object dataRulesContainer)
        {
            AfkRules afkRules = new AfkRules();
            afkRules.easyAfkWorkThread(dataRulesContainer);
        }
        private void advancedAfk(object dataRulesContainer)
        {
            AfkRules afkRules = new AfkRules();
            afkRules.advancedAfkWorkThread(dataRulesContainer);
        }
    }
}
