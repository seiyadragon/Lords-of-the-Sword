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
        public List<Panel> Panels = new List<Panel>();

        GuiComponent[] Slots;

        public Vector2f[] SlotPositions;
        public Vector2f SlotSize;

        public RectangleShape Draw = new RectangleShape(new Vector2f(1280, 720));

        public bool HoverEffects = false;
        public RectangleShape HoverShape;

        int frameCount;
        int acc = 35;
        int lastSelectedSlot;

        public static Panel createMainPanel()
        {
            Panel p = new Panel();
            p.Draw.FillColor = Color.Transparent;
            p.Slots = new GuiComponent[10];
            p.SlotPositions = new Vector2f[10];
            p.SlotPositions[0] = new Vector2f(50, 20);
            p.SlotSize = new Vector2f(1200, 68);
            for (int i = 1; i < 10; i++)
                p.SlotPositions[i] = new Vector2f(50, p.SlotPositions[i - 1].Y + 68);

            return p;
        }

        public static Panel createCityPanel()
        {
            Panel p = new Panel();
            p.Draw.FillColor = new Color(100, 0, 100, 100);
            p.Slots = new GuiComponent[10];
            p.SlotPositions = new Vector2f[10];
            p.SlotPositions[0] = new Vector2f(50, 20);
            p.SlotSize = new Vector2f(1170, 68);
            p.HoverEffects = true;
            p.HoverShape = new RectangleShape(new Vector2f(0, p.SlotSize.Y));
            p.HoverShape.FillColor = new Color(150, 0, 0, 100);
            for (int i = 1; i < 10; i++)
                p.SlotPositions[i] = new Vector2f(50, p.SlotPositions[i - 1].Y + 68);

            p.addComponent(new GameText("Leave", p.SlotPositions[9]), 9);

            return p;
        }

        public bool isMouseOverSlot(int slot)
        {
            return Program.MousePos.X > SlotPositions[slot].X && Program.MousePos.X < SlotPositions[slot].X + SlotSize.X &&
                Program.MousePos.Y > SlotPositions[slot].Y && Program.MousePos.Y < SlotPositions[slot].Y + SlotSize.Y;
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
            if (component.isText)
            {
                GameText gt = (GameText)component;
                gt.Draw.CharacterSize = (uint)(500 / Slots.Length);
                Slots[slot] = gt;
            }
            else Slots[slot] = component;
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
            {
                if (HoverEffects)
                {
                    HoverShape.Position = SlotPositions[i];

                    if (isMouseOverSlot(i))
                    {
                        if (i != lastSelectedSlot)
                        {
                            HoverShape.Size = new Vector2f(0, HoverShape.Size.Y);
                            acc = 35;
                        }

                        if (frameCount >= acc)
                        {
                            if (HoverShape.Size.X < 1170)
                                HoverShape.Size = new Vector2f(HoverShape.Size.X + 5, HoverShape.Size.Y);

                            if (acc > 0)
                                acc--;

                            frameCount = 0;
                        }

                        Window.Draw(HoverShape);
                        lastSelectedSlot = i;
                    }
                }

                if (Slots[i] != null)
                    Slots[i].update(Window);
            }

            for (int i = 0; i < Panels.Count; i++)
                Panels[i].update(Window);

            frameCount++; 
        }
    }
}
