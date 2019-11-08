using SendingKey.Data;
using SendingKey.Service;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SendingKey.Rules
{

    public class FischingRules
    {
        
        private Color color;
        private MyInteroptService myInteroptService;
        private WorkScreenArea workScreenArea;
        private Point fishingPoint;
        private int waitingForFish;
        private int waitingEjectAngel;

        private void Init(DataRulesFishingContainer dataRules)
        {
            this.waitingForFish = dataRules.waitingForFish;
            this.waitingEjectAngel = dataRules.waitingEjectAngel;
            this.color = dataRules.Color;
            this.myInteroptService = dataRules.MyInteroptService;
            this.workScreenArea = new WorkScreenArea();
        }

        public void Fisching(object dataRulesContainer)
        {
            DataRulesFishingContainer dataRules = dataRulesContainer as DataRulesFishingContainer;
            Init(dataRules);

            while (true)
            {
                ///WoW Key for Eject Angel
                this.myInteroptService.SendKeyToProcess("1");
                Thread.Sleep(this.waitingEjectAngel);
                if (FindColor())
                {
                    if (IsFishBites())
                    {
                        ///WoW Key for Interakt with Mouse
                        this.myInteroptService.SendKeyToProcess("j");
                    }
                }
                else
                {
                    Thread.Sleep(this.waitingForFish);
                }
            }
        }

        /// <summary>
        /// Quelle 17.09.2019
        /// https://www.tutorials.de/threads/c-net-pixelfarbe-suchen.358230/
        /// </summary>
        private bool FindColor()
        {
            //testC ist unsere gesuchte Farbe:)
            int pixelCount = 0;
            Stopwatch sw =Stopwatch.StartNew();
            Debug.WriteLine("Scanning ...");
            using (Bitmap b = CaptureScreen(this.workScreenArea.ScreenSizeWidth, this.workScreenArea.ScreenSizeHeight))
            {
                for (int width = this.workScreenArea.MinWidth; width <= this.workScreenArea.MaxWidth; width += 4)
                {
                    for (int height = this.workScreenArea.MinHeight; height <= this.workScreenArea.MaxHeight; height += 4)
                    {
                        Color searchC = b.GetPixel(width, height);
                        pixelCount++;
                        Cursor.Position = new Point(width, height);
                        if (searchC == this.color)
                        {
                            //wenn Farbe gefunden
                            this.fishingPoint = new Point(width, height);
                            Cursor.Position = this.fishingPoint;
                            sw.Stop();
                            Debug.WriteLine("Strop Scanning ...");
                            Debug.WriteLine("Farbe gefunden, Benötigte Millisekunden: " + sw.ElapsedMilliseconds.ToString() + " durchsuchte Pixel: " + pixelCount);
                            return true;
                        }
                    }
                }
            }
            sw.Stop();
            Debug.WriteLine("Strop Scanning ...");
            Debug.WriteLine("Benötigte Millisekunden: " + sw.ElapsedMilliseconds.ToString() + " durchsuchte Pixel: " + pixelCount);
            return false;
        }
        private bool IsFishBites()
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds <= waitingForFish)
            {
                if (IsChangeColor())
                {
                    return true;
                }
                Thread.Sleep(500);
            }
            sw.Stop();
            return false;
        }

        private bool IsChangeColor()
        {
            using (Bitmap b = CaptureScreen(this.workScreenArea.ScreenSizeWidth, this.workScreenArea.ScreenSizeHeight))
            {
                //this.myInteroptService.SetProcessForegroundWindow();
                Debug.WriteLine("#####################");
                Debug.WriteLine("Find");
                if (this.color == b.GetPixel(fishingPoint.X, fishingPoint.Y))
                {
                    Debug.WriteLine("hahaha");
                }
                return this.color == b.GetPixel(fishingPoint.X, fishingPoint.Y);
            }
        }

        private static Bitmap CaptureScreen(int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(0, 0, 0, 0, b.Size);
            }
            return b;
        }
    }
}
