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

namespace Lords_of_the_Sword.src.Groups
{
    class Party
    {
        public List<Unit> Members = new List<Unit>();
        public Unit Leader;

        public int Morale;

        public Party(Unit leader)
        {
            Leader = leader;
        }

        public void update(RenderWindow Window)
        {
            int totalUM = 0;
            for (int i = 0; i < Members.Count; i++)
                totalUM += Members[i].Morale;

            Morale = totalUM / Members.Count;
        }

        public void Camp()
        {

        }
    }
}
