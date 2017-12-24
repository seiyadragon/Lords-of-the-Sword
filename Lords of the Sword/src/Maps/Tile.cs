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
        public Vector2f LeftTriPoint;
        public Vector2f RightTriPoint;

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

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                Console.WriteLine(Position);
        }

        private bool checkHovering(RenderWindow Window)
        {
            Vector2i m = Program.MousePos;

            if (m.X > RectPos.X && m.X < RectPos.X + RectSize.X && m.Y > RectPos.Y && m.Y < RectPos.Y + RectSize.Y)
                return true;

            Vector2f a = LeftTriPoint;
            Vector2f b = new Vector2f(RectPos.X, RectPos.Y + 2);
            Vector2f c = new Vector2f(RectPos.X, RectPos.Y + 56);

            float s1 = c.Y - a.Y;
            float s2 = c.X - a.X;
            float s3 = b.Y - a.Y;
            float s4 = m.Y - a.Y;

            float w1 = (a.X * s1 + s4 * s2 - m.X * s1) / (s3 * s2 - (b.X - a.X) * s1);
            float w2 = (s4 - w1 * s3) / s1;

            if (w1 >= 0 && w2 >= 0 && (w1 + w2) <= 1)
                return true;

            a = new Vector2f(RectPos.X + 32, RectPos.Y + 58);
            b = new Vector2f(RectPos.X + 32, RectPos.Y + 1); ;
            c = RightTriPoint;

            w1 = (a.X * s1 + s4 * s2 - m.X * s1) / (s3 * s2 - (b.X - a.X) * s1);
            w2 = (s4 - w1 * s3) / s1;

            if (w1 >= 0 && w2 >= 0 && (w1 + w2) <= 1)
                return true;

            return false;
        }
    }
}
