using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

using Lords_of_the_Sword.Map;

namespace Lords_of_the_Sword
{
    class Program
    {
        public static RenderWindow Window;
        public static View MainCamera;

        static void Main(string[] args)
        {
            Window = new RenderWindow(new VideoMode(1280, 720), "Lords of the Sword", Styles.Default);
            MainCamera = new View(new FloatRect(0, 0, 1280, 720));

            Window.Closed += Window_Closed;

            Tile[][] t = new Tile[15][];

            for (int i = 0; i < 15; i++)
                t[i] = makeRow(i);

            Map.Map m = new Map.Map(new Vector2f(0, 0), combineTileArrays(15, t));

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();

                m.update(Window);

                Window.SetView(MainCamera);
                Window.Display();
            }
        }

        private static Tile[] makeRow(int y)
        {
            Tile[] t = new Tile[40];

            int num = 1;

            for (int i = 0; i < t.Length; i++)
            {
                if (num == 1)
                {
                    t[i] = new Tile(new Vector2f(i, y), TileType.Grassland);
                    num = 2;
                }

                else if (num == 2)
                {
                    t[i] = new Tile(new Vector2f(i, y - 0.4f), TileType.Grassland);
                    num = 1;
                }
            }

            return t;
        }

        private static Tile[] combineTileArrays(int amountofarrays, Tile[][] arrays)
        {
            Tile[] t = arrays[0];

            for (int i = 1; i < amountofarrays; i++)
                t = t.Concat(arrays[i]).ToArray();

            return t;
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
