using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using SendingKey.Service;

namespace SendingKey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AfkService afkService;
        private bool afkProcessIsAlive = false;

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.StartAfkService.Content = "Start Service";
            this.afkService = new AfkService();
        }

        private void StartProcess(object sender, RoutedEventArgs e)
        {
            this.afkService.init(this.WorkingProcess.Text);
            string comandLineInText = this.CommandLine.Text;
            if (!afkProcessIsAlive)
            {
                afkProcessIsAlive = this.afkService.startAfkProces(comandLineInText);
                this.StartAfkService.Content = "Abort Service";
            }
            else
            {
                afkProcessIsAlive = this.afkService.AportAfkProcess();
                this.StartAfkService.Content = "Start Service";
            }
        }

        private void TextBoxCommandLine_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                this.CommandLine.AppendText("SHIFT " + GetStringFromKey(e.Key));
                this.CommandLine.AppendText(Environment.NewLine);
                Debug.WriteLine("SHIFT wurde losgelassen");
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Alt)
            {
                this.CommandLine.AppendText("ALT " + GetStringFromKey(e.Key));
                this.CommandLine.AppendText(Environment.NewLine);
                Debug.WriteLine("ALT wurde losgelassen");
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                this.CommandLine.AppendText("STRG " + GetStringFromKey(e.Key));
                this.CommandLine.AppendText(Environment.NewLine);
                Debug.WriteLine("STRG wurde losgelassen");
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.None
                & e.Key != Key.LeftShift & e.Key != Key.RightShift
                & e.Key != Key.LeftCtrl & e.Key != Key.RightCtrl)
            {
                this.CommandLine.AppendText("" + GetStringFromKey(e.Key));
                this.CommandLine.AppendText(Environment.NewLine);
                Debug.WriteLine("nix wurde losgelassen");
            }
        }

        private void TextBoxCommandLine_KeyPress(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private string GetStringFromKey(Key key)
        {
            switch (key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    return key.ToString().Replace("D", "");
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                    return key.ToString().Replace("NumPad", "");
            }
            return key.ToString();
        }
    }
}
