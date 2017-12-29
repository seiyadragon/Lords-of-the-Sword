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

        public Panel ParentPanel;

        public Panel(int slots, Color panelColor, bool hovereffect, Color hovercolor)
        {
            Draw.FillColor = panelColor;
            Slots = new GuiComponent[slots];
            SlotPositions = new Vector2f[slots];
            SlotPositions[0] = new Vector2f(50, 20);
            SlotSize = new Vector2f(1170, 680 / slots);
            HoverEffects = hovereffect;
            HoverShape = new RectangleShape(new Vector2f(0, SlotSize.Y));
            HoverShape.FillColor = hovercolor;
            for (int i = 1; i < slots; i++)
                SlotPositions[i] = new Vector2f(50, SlotPositions[i - 1].Y + SlotSize.Y);
        }

        public static Panel createMainPanel()
        {   
            return new Panel(10, Color.Transparent, false, Color.Blue);
        }

        public static Panel createCityPanel()
        {
            Panel p = new Panel(5, new Color(100, 0, 100, 100), true, new Color(150, 0, 0, 100));
            
            p.addComponent(new GameText("Request audience with the leader", p.SlotPositions[0], Color.Blue), 0);
            p.addComponent(new GameText("Visit the inn", p.SlotPositions[1], Color.Green), 1);
            p.addComponent(new GameText("Visit the market", p.SlotPositions[2], Color.Yellow), 2);
            p.addComponent(new GameText("Siege", p.SlotPositions[3], Color.Red), 3);
            p.addComponent(new GameText("Leave", p.SlotPositions[4], Color.Magenta), 4);

            return p;
        }

        public static Panel createFarmPanel()
        {
            Panel p = new Panel(5, new Color(100, 0, 100, 100), true, new Color(150, 0, 0, 100));

            p.addComponent(new GameText("Recruit peasents", p.SlotPositions[0], Color.Green), 0);
            p.addComponent(new GameText("Buy food", p.SlotPositions[1], Color.Yellow), 1);
            p.addComponent(new GameText("Steal food", p.SlotPositions[2], Color.Red), 2);
            p.addComponent(new GameText("Kidnap peasents", p.SlotPositions[3], Color.Red), 3);
            p.addComponent(new GameText("Leave", p.SlotPositions[4], Color.Magenta), 4);

            return p;
        }

        public static Panel createPartyPanel()
        {
            Panel p = new Panel(5, new Color(100, 0, 100, 100), true, new Color(150, 0, 0, 100));

            p.addComponent(new GameText("Inventory", p.SlotPositions[0], Color.Green), 0);
            p.addComponent(new GameText("Reputation", p.SlotPositions[1], Color.Green), 1);
            p.addComponent(new GameText("Party", p.SlotPositions[2], Color.Green), 2);
            p.addComponent(new GameText("Camp", p.SlotPositions[3], Color.Green), 3);
            p.addComponent(new GameText("Continue on your journey", p.SlotPositions[4], Color.Magenta), 4);

            return p;
        }

        public bool isMouseOverSlot(int slot)
        {
            return Program.MousePos.X > SlotPositions[slot].X && Program.MousePos.X < SlotPositions[slot].X + SlotSize.X &&
                Program.MousePos.Y > SlotPositions[slot].Y && Program.MousePos.Y < SlotPositions[slot].Y + SlotSize.Y;
        }

        public bool isSlotClicked(int slot)
        {
            return isMouseOverSlot(slot) && HoverShape.Size.X == 1170 && Program.isButtonPressed((int)Mouse.Button.Left);
        }

        public void addPanel(Panel panel)
        {
            Panels.Add(panel);
        }

        public Panel popBackPanel()
        {
            if (Panels.Count - 1 < 0)
                return null;

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
                hoverEffect(i, Window);

                if (Slots[i] != null)
                    Slots[i].update(Window);

                if (Slots[Slots.Length - 1] != null)
                    if (isSlotClicked(Slots.Length - 1))
                        ParentPanel.popBackPanel();
            }

            for (int i = 0; i < Panels.Count; i++)
            {
                Panels[i].ParentPanel = this;

                Panels[i].update(Window);
            }

            frameCount++; 
        }

        public void hoverEffect(int i, RenderWindow Window)
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

                    if (Slots[i] != null)
                        Window.Draw(HoverShape);

                    lastSelectedSlot = i;
                }
            }

            if (Slots[i] != null && Slots[i].Hover)
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

                    if (Slots[i] != null)
                        Window.Draw(HoverShape);

                    lastSelectedSlot = i;
                }
            }
        }
    }
}
