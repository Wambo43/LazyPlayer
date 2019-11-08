using SendingKey.Service;
using System.Collections.Generic;

namespace SendingKey.Data
{
    public class DataRulesAfkContainer
    {
        /// <summary>
        /// Name from their Process wath you use
        /// </summary>
        public string processName;

        /// <summary>
        /// in millisecond Example 2000 = 2sec
        /// </summary>
        public int loopTimer = 2000;

        /// <summary>
        /// the Timer between the Commands
        /// </summary>
        public int CommandTimer { get; private set; }

        /// <summary>
        /// hold Key Words 
        /// </summary>
        public IList<string> keyWords = new List<string>();

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

        /// <summary>
        /// the Timer between the Commands
        /// </summary>
        private const int commandTimer = 1000;

        public DataRulesAfkContainer()
        {
        }
    }
}
