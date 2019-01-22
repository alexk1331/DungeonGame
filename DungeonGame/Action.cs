using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Action
    {
        string name { get; }
        int ap_cost { get; }
        //int time_cost { get; } -ne dlya etoi igri
        List<Effect> effects { get;}
        int type { get; }//0-out battle, 1-in battle, 2-both
        int target { get; }//0-untargeted, 1-targeted
    }
}
