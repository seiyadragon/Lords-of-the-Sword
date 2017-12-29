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
    enum TileType
    {
        Grassland,
        Forest,
        Coast,
        Ocean,
        Town,
        Castle,
        City,
        Farm
    }

    class TileTools
    {
        public static Texture TileMap = new Texture("res/fantasyhextiles_v2.png");

        public static Vector2f GrasslandTexture = new Vector2f(0, 0);
        public static Vector2f ForestTexture = new Vector2f(32 * 2, 0);
        public static Vector2f OceanTexture = new Vector2f(32 * 6, 0);
        public static Vector2f TownTexture = new Vector2f(0, 48);
        public static Vector2f CastleTexture = new Vector2f(32, 48);
        public static Vector2f CityTexture = new Vector2f(32 * 2, 48);
        public static Vector2f FarmTexture = new Vector2f(32 * 3, 48);

        public static Vector2f getTileTypeTextureCoords(TileType type)
        {
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

            if (type == TileType.Farm)
                return FarmTexture;

            return new Vector2f();
        }

        public static bool isTileTypeEmpty(TileType type)
        {
            if (type == TileType.Grassland || type == TileType.Forest || type == TileType.Coast || type == TileType.Ocean)
                return true;

            return false;
        }
    }
}
