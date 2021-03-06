﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

using Lords_of_the_Sword.src.Units;
using Lords_of_the_Sword.Maps;
using Lords_of_the_Sword.src.Gui;

namespace Lords_of_the_Sword.src.Groups
{
    class Party
    {
        public List<Unit> Members = new List<Unit>();
        public Unit Leader;

        Sprite Draw = new Sprite();

        public int CurrentTile;

        public int Morale;

        public Party(Unit leader, int tileID)
        {
            Leader = leader;

            Draw.Texture = new Texture("res/textures/Flag.png");

            move(tileID, true);
        }

        public void update(RenderTexture Screen)
        {
            int totalUM = 0;
            for (int i = 0; i < Members.Count; i++)
                totalUM += Members[i].Morale;

            if (Members.Count > 0)
                Morale = totalUM / Members.Count;

            Screen.Draw(Draw);
        }

        public void move(int tileID, bool ignoreAdjacent)
        {
            bool adjacent = false;

            for (int i = 0; i < Program.CurrentMap.Tiles[CurrentTile].AdjacentTiles.Length; i++)
                if (Program.CurrentMap.Tiles[CurrentTile].AdjacentTiles[i] != null && Program.CurrentMap.Tiles[CurrentTile].AdjacentTiles[i].ID == tileID)
                    adjacent = true;

            if (!adjacent && !ignoreAdjacent)
                return;

            CurrentTile = tileID;
            Tile tile = Program.CurrentMap.Tiles[CurrentTile];
            Draw.Position = tile.PartyPos;

            if (Program.CurrentMap.Tiles[CurrentTile].Type == TileType.City || Program.CurrentMap.Tiles[CurrentTile].Type == TileType.Town)
                Program.MainPanel.addPanel(Panel.createCityPanel());

            if (Program.CurrentMap.Tiles[CurrentTile].Type == TileType.Farm)
                Program.MainPanel.addPanel(Panel.createFarmPanel());
        }

        public void Camp()
        {

        }
    }
}
