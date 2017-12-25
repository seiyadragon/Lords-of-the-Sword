using System;
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

namespace Lords_of_the_Sword.src.Groups
{
    class Party
    {
        public List<Unit> Members = new List<Unit>();
        public Unit Leader;

        RectangleShape Draw = new RectangleShape(new Vector2f(32, 32));

        int CurrentTile;

        public int Morale;

        public Party(Unit leader, int tileID)
        {
            Leader = leader;

            Draw.FillColor = Color.Blue;

            move(tileID);
        }

        public void update(RenderWindow Window)
        {
            int totalUM = 0;
            for (int i = 0; i < Members.Count; i++)
                totalUM += Members[i].Morale;

            if (Members.Count > 0)
                Morale = totalUM / Members.Count;

            Window.Draw(Draw);
        }

        public void move(int tileID)
        {
            CurrentTile = tileID;
            Tile tile = null;

            for (int i = 0; i < Program.CurrentMap.Tiles.Length; i++)
                if (Program.CurrentMap.Tiles[i].ID == tileID)
                    tile = Program.CurrentMap.Tiles[i];

            Draw.Position = tile.PartyPos;
        }

        public void Camp()
        {

        }
    }
}
