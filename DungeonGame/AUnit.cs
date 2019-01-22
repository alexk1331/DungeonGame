using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
     abstract class AUnit
    {
        int cur_hp { get; set; }
        int cur_mana { get; set; }
        string name { get; set; }
        //Inventory inv{ get; set; }
        Stats stats{ get; set; }
        //List<Actions> acts{ get; set; }
        //Appearance appear{ get; set; }
        //Effects eff{ get; set; }

        public int Gdamage
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Gspeed
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Gaccuracy
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Gdodge
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Gluck
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Ghp_max
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Gintelligence
        {
            get
            {
                return 0;
            }
            private set { }
        }
        public int Gmana_max
        {
            get
            {
                return 0;
            }
            private set { }
        }

    }
}
