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
    abstract class GuiComponent
    {
        protected Vector2f Position;

        public GuiComponent(Vector2f pos)
        {
            Position = pos;
        }

        public abstract void update(RenderWindow Window);
    }
}
