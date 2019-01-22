using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Stats
    {
        int strenght { get; set; }
        int speed { get; set; }
        int vitality { get; set; }
        int agility { get; set; }
        int luck { get; set; }
        int inteligence { get; set; }
        int spirit { get; set; }

        public Stats()
            {

            }

        public void stat_change(int str, int sp, int vit, int ag, int luc, int intel, int spir)
            {
            if(str>0) strenght = str;

            if (sp > 0) speed = sp;
            if (vit > 0) vitality = vit;
            if (ag > 0) agility = ag;
            if (luc > 0) luck = luc;
            if (intel > 0) inteligence = intel;
            if (spir > 0) spirit = spir;
            }
    }
}
