using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace Lords_of_the_Sword.Map
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
                Tiles[i].DrawSprite.Position = new Vector2f(Position.X + 32 * Tiles[i].Position.X, Position.Y + 48 * Tiles[i].Position.Y);
        }

        public void update(RenderWindow Window)
        {
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i].update(Window);
        }
    }
}
