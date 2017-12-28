using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

using Lords_of_the_Sword.Maps;
using Lords_of_the_Sword.src.Units;
using Lords_of_the_Sword.src.Groups;
using Lords_of_the_Sword.src.Gui;

namespace Lords_of_the_Sword
{
    class Program
    {
        public static RenderWindow Window;
        public static View MainCamera;

        public static Vector2f MousePos = new Vector2f();

        private static bool[] MouseButtons = new bool[10];
        private static bool[] MouseButtonsLast = new bool[10];

        public static List<Party> Parties = new List<Party>();

        public static Map CurrentMap;
        public static Panel MainPanel;

        public static Font MainFont;

        static void Main(string[] args)
        {
            Window = new RenderWindow(new VideoMode(1280, 720), "Lords of the Sword", Styles.Default);
            MainCamera = new View(new FloatRect(0, 0, 1280, 720));

            Window.Closed += Window_Closed;
            Window.MouseMoved += Window_MouseMoved;
            Window.MouseButtonPressed += Window_MouseButtonPressed;
            Window.MouseButtonReleased += Window_MouseButtonReleased;

            MainFont = new Font("res/Travelling.ttf");

            MainPanel = Panel.createMainPanel();

            CurrentMap = createMap("res/Main.map");
            Parties.Add(new Party(new Unit("Uthred of Bebbanburg", 25, 1, 3), 10));

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();

                CurrentMap.update(Window);

                for (int i = 0; i < Parties.Count; i++)
                    Parties[i].update(Window);

                MainPanel.update(Window);

                if (MainPanel.Panels.Count > 0)
                    if (MainPanel.Panels[MainPanel.Panels.Count - 1].isMouseOverSlot(MainPanel.Panels[MainPanel.Panels.Count - 1].SlotPositions.Length - 1))
                        if (isButtonPressed((int)Mouse.Button.Left))
                            MainPanel.popBackPanel();

                Window.SetView(MainCamera);
                Window.Display();

                MouseButtonsLast = (bool[])MouseButtons.Clone();
            }
        }

        private static void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            MouseButtons[(int)e.Button] = false;
        }

        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            MouseButtons[(int)e.Button] = true;
        }

        private static void Window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            MousePos.X = e.X;
            MousePos.Y = e.Y;

            MousePos = Window.MapPixelToCoords(new Vector2i((int)MousePos.X, (int)MousePos.Y));
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }

        public static bool isButtonPressed(int button)
        {
            return MouseButtons[button] && !MouseButtonsLast[button];
        }

        public static bool isButtonReleased(int button)
        {
            return !MouseButtons[button] && MouseButtonsLast[button];
        }

        public static bool isButtonHeld(int button)
        {
            return MouseButtons[button];
        }

        private static Tile[] makeRow(int y)
        {
            Tile[] t = new Tile[24];

            int num = 1;

            for (int i = 0; i < t.Length; i++)
            {
                if (num == 1)
                {
                    t[i] = new Tile(new Vector2f(i * 0.8f, .59f * y), TileType.Grassland, false);
                    num = 2;
                }

                else if (num == 2)
                {
                    t[i] = new Tile(new Vector2f(i * 0.8f, .59f * y - 0.26f), TileType.Grassland, true);
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

        private static Map createMap(string path)
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

            return new Map(new Vector2f(15, 0), array);
        }
    }
}
