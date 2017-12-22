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

            Tile[] t = new Tile[20 * 8];

            for (int x = 0; x < 20; x++)
                for (int y = 0; y < 8; y++)
                    t[x + y * 20] = new Tile(new Vector2f(x, y), TileType.Forest);

            Map.Map m = new Map.Map(new Vector2f(0, 0), t);

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();

                m.update(Window);

                Window.SetView(MainCamera);
                Window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
