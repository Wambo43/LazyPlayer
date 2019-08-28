using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingKey.Helper
{
    public class SpecifyCharacters
    {
        /***
         * SHIFT +
         * CTRL ^
         * ALT %
         ***/
        public SpecifyCharacters() { }

        public string GetShift(string character = "")
        {
            return "+{" + character + "}";
        }

        public string GetCtrl(string character = "")
        {
            return "^{" + character + "}";
        }

        public string GetAlt(string character = "")
        {
            return "%{" + character + "}";
        }

        public string GetEnter()
        {
            return "{ENTER}";
        }

        public string GetSpace()
        {
            return "{SPACE}";
        }

        public string GetDown()
        {
            return "{DOWN}";
        }

        public string GeUp()
        {
            return "{UP}";
        }

        public string GeRight()
        {
            return "{RIGHT}";
        }

        public string GeLeft()
        {
            return "{LEFT}";
        }
    }
}
