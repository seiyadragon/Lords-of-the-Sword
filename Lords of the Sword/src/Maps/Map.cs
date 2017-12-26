using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace Lords_of_the_Sword.Maps
{
    class Map
    {
        public Vector2f Position;

        public Tile[] Tiles;

        public Map(Vector2f pos, Tile[] tiles)
        {
            Position = pos;

            Tiles = tiles;

            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i].DrawSprite.Position = new Vector2f(Position.X + 64 * Tiles[i].Position.X, Position.Y + 96 * Tiles[i].Position.Y);
                Tiles[i].Selection.Position = new Vector2f(Tiles[i].DrawSprite.Position.X + 20, Tiles[i].DrawSprite.Position.Y + 17);

                Tiles[i].RectSize = new Vector2f(30, 60);
                Tiles[i].RectPos = new Vector2f(Tiles[i].DrawSprite.Position.X + 16, Tiles[i].DrawSprite.Position.Y + 36);

                Tiles[i].PartyPos = new Vector2f(Tiles[i].DrawSprite.Position.X + 18, Tiles[i].DrawSprite.Position.Y + 50);

                Tiles[i].ID = i;

                for (int j = 0; j < 6; j++)
                    Tiles[i].AdjacentTiles[j] = null;
            }

            for (int i = 0; i < Tiles.Length; i++)
            {
                if (i - 24 >= 0)
                    Tiles[i].AdjacentTiles[0] = Tiles[i - 24];

                if (i + 24 < 288)
                    Tiles[i].AdjacentTiles[1] = Tiles[i + 24];

                if (i - 1 >= 0)
                    Tiles[i].AdjacentTiles[2] = Tiles[i - 1];

                if (i + 1 < 288)
                    Tiles[i].AdjacentTiles[3] = Tiles[i + 1];

                if (Tiles[i].Top)
                {
                    if (i - 25 >= 0)
                        Tiles[i].AdjacentTiles[4] = Tiles[i - 25];

                    if (i - 23 >= 0)
                        Tiles[i].AdjacentTiles[5] = Tiles[i - 23];
                }

                if (!Tiles[i].Top)
                {
                    if (i + 25 < 288)
                        Tiles[i].AdjacentTiles[4] = Tiles[i + 25];

                    if (i + 23 < 288)
                        Tiles[i].AdjacentTiles[5] = Tiles[i + 23];
                }
            }
        }

        public void update(RenderWindow Window)
        {
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i].update(Window);
        }
    }
}
