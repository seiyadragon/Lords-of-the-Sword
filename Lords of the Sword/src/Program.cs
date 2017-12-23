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

            Map.Map m = createMap("res/Main.map");

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
            Tile[] t = new Tile[24];

            int num = 1;

            for (int i = 0; i < t.Length; i++)
            {
                if (num == 1)
                {
                    t[i] = new Tile(new Vector2f(i * 0.8f, .59f * y), TileType.Grassland);
                    num = 2;
                }

                else if (num == 2)
                {
                    t[i] = new Tile(new Vector2f(i * 0.8f, .59f * y - 0.26f), TileType.Grassland);
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

        private static Map.Map createMap(string path)
        {
            Tile[][] t = new Tile[12][];

            for (int i = 0; i < 12; i++)
                t[i] = makeRow(i);

            Tile[] array = combineTileArrays(12, t);

            string mapTxt = System.IO.File.ReadAllText(path);

            string[] sep = mapTxt.Split(' ');

            int[] final = new int[sep.Length];

            for (int i = 0; i < final.Length; i++)
                int.TryParse(sep[i], out final[i]);

            for (int i = 0; i < array.Length; i++)
            {
                if (final[i] == 0)
                    array[i].setType(TileType.Grassland);

                if (final[i] == 1)
                    array[i].setType(TileType.Forest);

                if (final[i] == 2)
                    array[i].setType(TileType.Ocean);

                if (final[i] == 3)
                    array[i].setType(TileType.Town);

                if (final[i] == 4)
                    array[i].setType(TileType.Castle);

                if (final[i] == 5)
                    array[i].setType(TileType.City);
            }

            return new Map.Map(new Vector2f(15, 0), array);
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
