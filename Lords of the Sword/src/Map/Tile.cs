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
    class Tile
    {
        public Vector2f Position;
        public TileType Type;
        public Sprite DrawSprite = new Sprite();

        public Tile(Vector2f pos, TileType type)
        {
            Position = pos;
            Type = type;
            DrawSprite.Texture = TileTools.TileMap;
            DrawSprite.TextureRect = new IntRect((Vector2i)TileTools.getTileTypeTextureCoords(type), new Vector2i(32, 48));
        }

        public void update(RenderWindow Window)
        {
            Window.Draw(DrawSprite);
        }
    }
}
