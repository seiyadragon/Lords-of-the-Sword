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

                Tiles[i].RectSize = new Vector2f(28, 56);
                Tiles[i].RectPos = new Vector2f(Tiles[i].DrawSprite.Position.X + 17, Tiles[i].DrawSprite.Position.Y + 37);
                Tiles[i].LeftTriPoint = new Vector2f(Tiles[i].DrawSprite.Position.X, Tiles[i].DrawSprite.Position.Y + 56);
                Tiles[i].RightTriPoint = new Vector2f(Tiles[i].DrawSprite.Position.X + 28, Tiles[i].DrawSprite.Position.Y + 56);
            }
        }

        public void update(RenderWindow Window)
        {
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i].update(Window);
        }
    }
}
