using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    static class Account
    {
        public static Player currentplayer { get; set; }
        public static List<Map> maps{ get; set; }//list of generated maps for current player
        public static string player_map { get; set; }
        public struct ppos
        {
            public int x;
            public int y;
        }
        public static ppos maptile;

        static Account()
        {
            maptile = new ppos();
            maptile.x = 1;
            maptile.y = 2;
        }

        public static void save()
        {

        }

        public static void load()
        {

        }

        public static void delete()
        {

        }
    }
}
