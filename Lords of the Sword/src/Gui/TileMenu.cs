using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

using Lords_of_the_Sword.src.Groups;
using Lords_of_the_Sword.Maps;

namespace Lords_of_the_Sword.src.Gui
{
    class TileMenu
    {
        static RectangleShape Draw = new RectangleShape(new Vector2f(1280, 720));
        public static bool isOpen = false;

        private static bool first = true;

        private static string[] Town;
        private static string[] Castle;
        private static string[] City;
        private static string[] Bandit;

        public static void open(Party part, Tile tile)
        {
            if (first)
            {
                Draw.Position = new Vector2f(0, 0);
                Draw.FillColor = new Color(150, 23, 74, 100);

                string str = System.IO.File.ReadAllText("res/Encounters.cfg");
                string[] arr = str.Split('\n');

                Town = arr[0].Split(';');
                Castle = arr[1].Split(';');
                City = arr[2].Split(';');
                Bandit = arr[2].Split(';');
            }

            isOpen = true;
        }

        public void update(RenderWindow Window)
        {
            if (isOpen)
                Window.Draw(Draw);
        }
    }
}
