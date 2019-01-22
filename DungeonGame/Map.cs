using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Map
    {
        public int deep { get; }
        public int size { get; set; }
        public MapTile[,] tiles;
        public Map(int d)//depth of this lvl
        {
            size = 6;
            //map generation
            MapTile[,] t = new MapTile[6, 6];
            tiles = t;
            for (int i=0;i<6;i++)
            {
                for(int j=0;j<6;j++)
                {
                    tiles[i, j] = new MapTile();
                    
                }
            }
            tiles[1, 1].type = 0;
            tiles[5, 2].type = 0;
            tiles[0, 5].type = 0;
            tiles[1, 5].type = 0;
        }

        public void generatemap(int d)
        {
            Random r = new Random();
            int s = r.Next(d-(d/10), d+(d/10));
            MapTile[,] newmap = new MapTile[s, s];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    newmap[i, j] = new MapTile();
                    if(i==0||i==s-1||j==0||j==s-1)
                    {
                        newmap[i, j].type = 0;
                    }
                    else
                    {
                        newmap[i, j].type = 1;
                    }
                }
            }
            size = s;
            tiles = newmap;
        }


    }
}
