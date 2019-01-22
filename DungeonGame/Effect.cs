using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Effect
    {
        string name { get; }
        string source { get; set; }
        int duration { get; set; }

        Dictionary<string, int> param_effects;
    }
}
