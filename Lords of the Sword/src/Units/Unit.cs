using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_of_the_Sword.src.Units
{
    class Unit
    {
        public int Gender;
        public int SexualPreference;

        public int Morale;

        public int Lvl;
        public int Exp;
        public int Str;
        public int Agi;
        public int Int;

        public Unit(int level = 1, int gender = 3, int sp = 4)
        {
            Random r = new Random();

            Lvl = 1;

            if (level > 1)
                for (int i = 0; i < level; i++)
                    LevelUp();

            if (gender != 1 || gender != 2)
                Gender = r.Next(1, 2);
            else Gender = gender;

            if (sp != 1 || sp != 2 || sp != 3)
                SexualPreference = r.Next(1, 3);
            else SexualPreference = sp;

            if (Gender == 1)
            {
                Str = 3;
                Agi = 1;
                Int = 2;
            }

            if (Gender == 2)
            {
                Str = 1;
                Agi = 3;
                Int = 2;
            }
        }

        public void update()
        {
            if (Exp >= 100)
                LevelUp();
        }

        public void LevelUp()
        {
            Lvl++;
            Exp = 0;

            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                if (r.Next(1, 3) == 1)
                    Str++;

                else if (r.Next(1, 3) == 2)
                    Agi++;

                else if (r.Next(1, 3) == 3)
                    Int++;
            }
        }
    }
}
