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
    class Tile
    {
        public Vector2f Position;
        public TileType Type;
        public Sprite DrawSprite = new Sprite();

        public CircleShape Selection = new CircleShape(35, 6);

        public Vector2f RectPos;
        public Vector2f RectSize;

        public Vector2f PartyPos;

        public int ID;

        public Tile(Vector2f pos, TileType type)
        {
            Position = pos;
            Type = type;
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

        public void update(RenderWindow Window)
        {
            Window.Draw(DrawSprite);

            if (checkHovering(Window))
                hover(Window);
        }

        private void hover(RenderWindow Window)
        {
            Window.Draw(Selection);

            if (Program.isButtonPressed((int)Mouse.Button.Left))
                Program.Parties[0].move(ID);
        }

        private bool checkHovering(RenderWindow Window)
        {
            Vector2f m = Program.MousePos;

            if (m.X > RectPos.X && m.X < RectPos.X + RectSize.X && m.Y > RectPos.Y && m.Y < RectPos.Y + RectSize.Y)
                return true;

            return false;
        }
    }
}
