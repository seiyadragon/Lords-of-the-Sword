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
    class TileMenu
    {
        static RectangleShape Draw = new RectangleShape(new Vector2f(16 * 20, 9 * 20));
        public static bool isOpen = false;

        private static bool first = true;

        public void open()
        {
            if (first)
            {
                Draw.Position = new Vector2f(0, 0);
                Draw.FillColor = new Color(150, 23, 74, 100);
            }
        }

        public void update(RenderWindow Window)
        {
            if (isOpen)
                Window.Draw(Draw);
        }
    }
}
