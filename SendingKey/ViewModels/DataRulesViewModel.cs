using SendingKey.Controller;
using SendingKey.Helper;

using System.ComponentModel;
using System.Windows.Input;

namespace SendingKey.ViewModels
{
    class DataRulesViewModel : INotifyPropertyChanged
    {

        private int loopTimer = 2000;
        private string processName = "notepad++";
        public string keyWords;

        //ersetzten und fragen ob Thread läuft
        private bool canExecuteFishing = true;
        private bool canExecuteCommandAfkProcess = true;
        private string color = "Green";
        private ICommand commandAfkProcess;
        private ICommand commandFishing;

        public ICommand CommandFishing
        {
            get
                {
                    return commandFishing ?? (commandFishing = new CommandHandler(() => ExecuteFishing(), () => CanExecuteFishing));
                }
        }
        public ICommand CommandAfkProcess
        {
            get
            {
                return commandAfkProcess ?? (commandAfkProcess = new CommandHandler(() => ExecuteCommandAfkProcess(), () => CanExecuteCommandAfkProcess));
            }
        }

        public bool CanExecuteFishing
        {
            get
            {
                return true;
                return canExecuteFishing;
                // check if executing is allowed, i.e., validate, check if a process is running, etc. 
            }
            set
            {
                canExecuteFishing = value;
            }
        }

        public void ExecuteFishing()
        {
            FishingController fishingController = new FishingController(this.ProcessName,"1" ,"j" );
            if (!fishingController.ThreadIsAlive)
            {
                Color = "Red";
                fishingController.StartProces();
            }
            else
            {
                fishingController.AportProcess();
            }
        }

        public bool CanExecuteCommandAfkProcess
        {
            get
            {
                return true;
                return canExecuteCommandAfkProcess;
                // check if executing is allowed, i.e., validate, check if a process is running, etc. 
            }
            set
            {
                canExecuteCommandAfkProcess = value;
            }
        }

        public void ExecuteCommandAfkProcess()
        {
            AfkController afkController = new AfkController(this.ProcessName);

            string comandLineInText = this.KeyWords;
            //der Button kann sonst nicht mehr ausgeführt werden
            //if(!CanExecuteFishing)
            if (!afkController.ThreadIsAlive)
            {
                CanExecuteFishing = afkController.StartProcess(comandLineInText);
            }
            else
            {
                CanExecuteFishing = afkController.AportProcess();
            }
        }


        public int LoopTimer {
            get { return loopTimer; }
            set
            {
                loopTimer = value;
                OnNotifyPropertyChanged("LoopTimer");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnNotifyPropertyChanged("Color");
            }
        }

        public string ProcessName
        {
            get { return processName; }
            set
            {
                processName = value;
                OnNotifyPropertyChanged("ProcessName");
            }
        }

        public string KeyWords
        {
            get { return keyWords; }
            set
            {
                keyWords = value;
                OnNotifyPropertyChanged("KeyWords");
            }
        }


        private void OnNotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
