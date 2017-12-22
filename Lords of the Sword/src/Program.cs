using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace Lords_of_the_Sword
{
    class Program
    {
        public static RenderWindow Window;
        public static View Idk;

        static void Main(string[] args)
        {
            Window = new RenderWindow(new VideoMode(1280, 720), "Lords of the Sword", Styles.Default);

            Window.Closed += Window_Closed;

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();



                Window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
