using SendingKey.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingKey.Data
{
    class DataRulesFishingContainer
    {
        public int waitingForFish = 32000;
        public int waitingEjectAngel = 1000;
        public string EjectAngelKey;
        public string MouseInteraktKey;

        /// <summary>
        /// Service by the Procress
        /// </summary>
        private MyInteroptService myInteroptService;

        public MyInteroptService MyInteroptService
        {
            get
            {
                return myInteroptService;
            }
            set
            {
                if (myInteroptService == null)
                {
                    myInteroptService = value;
                }
            }
        }
        public Color Color => Color.FromArgb(255, 166, 91);

    }
}
