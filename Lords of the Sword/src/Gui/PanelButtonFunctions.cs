using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace Lords_of_the_Sword.src.Gui
{
    class PanelButtonFunctions
    {
        public static void newGameButton()
        {
            Program.Game = true;
        }
    }
}
