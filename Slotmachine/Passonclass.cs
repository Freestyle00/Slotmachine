using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slotmachine
{
    public static class Passonclass
    {
        public static bool ButtonClicked = false;
        public static string slot1er; 
        public static string slot2er;
        public static string slot3ernot;
        public static int credits = 10;
        public static bool thinkagain(string slot3er)
        {
            if (slot1er == slot2er && slot1er == slot3er)
            {
                slot3ernot = slot3er;
                return true;
            }
            return false;
        }
    }
}