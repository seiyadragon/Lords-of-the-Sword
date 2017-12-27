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
    class Panel
    {
        List<Panel> Panels = new List<Panel>();

        GuiComponent[] Slots;

        public Vector2f[] SlotPositions;

        public RectangleShape Draw = new RectangleShape(new Vector2f(1280, 720));

        public static Panel createMainPanel()
        {
            Panel p = new Panel();
            p.Draw.FillColor = Color.Transparent;
            p.Slots = new GuiComponent[10];
            p.SlotPositions = new Vector2f[10];
            p.SlotPositions[0] = new Vector2f(50, 20);
            for (int i = 1; i < 10; i++)
                p.SlotPositions[i] = new Vector2f(50, p.SlotPositions[i - 1].Y + 68);

            return p;
        }

        public void addPanel(Panel panel)
        {
            Panels.Add(panel);
        }

        public Panel popBackPanel()
        {
            Panel p = Panels[Panels.Count - 1];
            Panels.Remove(p);
            return p;
        }

        public void addComponent(GuiComponent component, int slot)
        {
            Slots[slot] = component;
        }

        public GuiComponent removeComponent(int slot)
        {
            GuiComponent c = Slots[slot];
            Slots[slot] = null;
            return c;
        }

        public void update(RenderWindow Window)
        {
            Window.Draw(Draw);

            for (int i = 0; i < Slots.Length; i++)
                if (Slots[i] != null)
                    Slots[i].update(Window);

            for (int i = 0; i < Panels.Count; i++)
                Panels[i].update(Window);
        }
    }
}
