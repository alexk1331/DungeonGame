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
        public static Map player_map;
        public struct ppos
        {
            public int x;
            public int y;
        }
        public static ppos maptile;

        static Account()
        {
            maps = new List<Map>();
            if(maps.Count<1)
            {
                maps.Add(new Map(0));//create basic map. CHANGE LATER TO CUSTOM!
                player_map = maps[0];
                maptile.x = player_map.enter.x;
                maptile.y = player_map.enter.y;
            }
        }
        public static void inicialize()
        {

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
