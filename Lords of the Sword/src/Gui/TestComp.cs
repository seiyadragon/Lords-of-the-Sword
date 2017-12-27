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
    class TestComp : GuiComponent
    {
        RectangleShape s = new RectangleShape(new Vector2f(1280 - 80, 68));

        public TestComp(Vector2f pos)
            : base(pos)
        {
            s.Position = Position;
            s.FillColor = Color.Red;
        }

        public override void update(RenderWindow Window)
        {
            Window.Draw(s);
        }
    }
}
