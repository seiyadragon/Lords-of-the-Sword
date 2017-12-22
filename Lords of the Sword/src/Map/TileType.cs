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
    enum TileType
    {
        Grassland,
        Forest,
        Coast,
        Ocean,
        Bandit_Camp,
        Hunter_Camp,
        Military_Camp,
        Mercenary_Camp,
        Town,
        Castle,
        City
    }

    class TileTools
    {
        static bool TileMapSeparation = false;
        static Texture TileMap = new Texture("res/fantasyhextiles_v2.png");

        public static Sprite GrasslandTexture = new Sprite();
        public static Sprite ForestTexture = new Sprite();
        public static Sprite OceanTexture = new Sprite();
        public static Sprite TownTexture = new Sprite();
        public static Sprite CastleTexture = new Sprite();
        public static Sprite CityTexture = new Sprite();

        public static Sprite getTileTypeTexture(TileType type)
        {
            if (!TileMapSeparation)
            {
                GrasslandTexture.Texture = TileMap;
                GrasslandTexture.TextureRect = new IntRect(32 * 0, 48 * 0, 32, 48);
                GrasslandTexture.Scale = new Vector2f(2, 2);

                ForestTexture.Texture = TileMap;
                ForestTexture.TextureRect = new IntRect(32 * 2, 48 * 0, 32, 48);
                ForestTexture.Scale = new Vector2f(2, 2);

                TileMapSeparation = true;
            }

            if (type == TileType.Grassland)
                return GrasslandTexture;

            if (type == TileType.Forest)
                return ForestTexture;

            if (type == TileType.Ocean)
                return OceanTexture;

            if (type == TileType.Town)
                return TownTexture;

            if (type == TileType.Castle)
                return CastleTexture;

            if (type == TileType.City)
                return CityTexture;

            return null;
        }

        public static bool isTileTypeEmpty(TileType type)
        {
            if (type == TileType.Grassland || type == TileType.Forest || type == TileType.Coast || type == TileType.Ocean)
                return true;

            return false;
        }
    }
}
