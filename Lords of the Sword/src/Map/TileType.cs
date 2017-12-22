using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_of_the_Sword.Map
{
    enum TileType
    {
        Grassland,
        Forest,
        Coast,
        Ocean,
        Merchant_Ship,
        Pirate_Ship,
        Military_Ship,
        Bandit_Camp,
        Hunter_Camp,
        Military_Camp,
        Mercenary_Camp,
        Village,
        Town,
        Castle,
        City
    }

    class TileTools
    {
        public static bool isTileTypeEmpty(TileType type)
        {
            if (type == TileType.Grassland || type == TileType.Forest || type == TileType.Coast || type == TileType.Ocean)
                return true;

            return false;
        }
    }
}
