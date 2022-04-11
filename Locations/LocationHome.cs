using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuest
{
    class LocationHome
        : Location
    {
        public LocationHome()
        {

        }

        override public void RunAction()
        {
            Gui.MenuTitle("Вы находитесь дома");
            MyGame.PressAnyKeyToContinue();
            Console.Clear();
        }
    }
}
