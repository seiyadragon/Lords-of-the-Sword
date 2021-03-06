﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

using Lords_of_the_Sword.src.Gui;
using Lords_of_the_Sword.src.Engine;

namespace Lords_of_the_Sword.Maps
{
    class Tile : GameObject
    {
        public TileType Type;
        public Sprite DrawSprite = new Sprite();

        public bool Top;

        public CircleShape Selection = new CircleShape(35, 6);

        public Vector2f RectPos;
        public Vector2f RectSize;

        public Vector2f PartyPos;

        public bool isEmpty = true;

        public Tile[] AdjacentTiles = new Tile[6];

        public int ID;

        public Tile(Vector2f pos, TileType type, bool istop) : base(pos)
        {
            Type = type;
            Top = istop;
            DrawSprite.Texture = TileTools.TileMap;
            DrawSprite.TextureRect = new IntRect((Vector2i)TileTools.getTileTypeTextureCoords(type), new Vector2i(32, 48));
            DrawSprite.Scale = new Vector2f(2, 2);

            Selection.FillColor = new Color(100, 100, 50, 100);
            Selection.Rotation = 30;
        }

        public void setType(TileType type)
        {
            Type = type;
            DrawSprite.TextureRect = new IntRect((Vector2i)TileTools.getTileTypeTextureCoords(type), new Vector2i(32, 48));
        }

        public override void Render()
        {
            Program.Screen.Draw(DrawSprite);
        }

        public override void Update()
        {
            if (checkHovering() && Program.MainPanel.Panels.Count == 0)
                hover();
        }

        private void hover()
        {
            Program.Screen.Draw(Selection);

            if (Program.isButtonPressed((int)Mouse.Button.Left))
            {
                if (this == Program.CurrentMap.Tiles[Program.Parties[0].CurrentTile])
                    Program.MainPanel.addPanel(Panel.createPartyPanel());

                Program.Parties[0].move(ID, false);
            }
        }

        private bool checkHovering()
        {
            Vector2f m = Program.MousePos;

            if (m.X > RectPos.X && m.X < RectPos.X + RectSize.X && m.Y > RectPos.Y && m.Y < RectPos.Y + RectSize.Y)
                return true;

            if (m.X > RectPos.X - 14 && m.X < RectPos.X + 44 && m.Y > RectPos.Y + 20 && m.Y < RectPos.Y + 42)
                return true;

            if (m.X > RectPos.X - 8 && m.X < RectPos.X + 38 && m.Y > RectPos.Y + 10 && m.Y < RectPos.Y + 52)
                return true;

            return false;
        }
    }
}
