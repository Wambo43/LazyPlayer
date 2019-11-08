using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingKey.Data
{
    class WorkScreenArea
    {
        public int MinWidth => Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.2);
        public int MinHeight => Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.2);
        public int MaxHeight => Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
        public int MaxWidth => Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
        public int ScreenSizeHeight => Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height);
        public int ScreenSizeWidth => Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width);
    }
}
