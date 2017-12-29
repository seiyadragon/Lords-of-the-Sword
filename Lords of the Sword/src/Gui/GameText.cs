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
    class GameText : GuiComponent
    {
        public String text;
        public Text Draw;

        public GameText(string text, Vector2f pos, Color color, bool hover = false)
            : base(pos, true, hover)
        {
            this.text = text;
            Draw = new Text();
            Draw.Color = color;
            Draw.Font = Program.MainFont;
            Draw.DisplayedString = text;
            Draw.Position = pos;
        }

        public override void update(RenderWindow Window)
        {
            Window.Draw(Draw);
        }
    }
}
