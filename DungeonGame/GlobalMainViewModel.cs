using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DungeonGame
{
    public static class GlobalMainViewModel
    {
        public static ContentControl maintab;
        public static ViewBase currentview;
        public static Window win;

        static GlobalMainViewModel()
        {
            maintab = new ContentControl();
            win = new Window();
        }

        public static void switchview(Type t)
        {

            if(t==typeof(VMStart))
            {
                currentview = new VMStart(maintab);
            }
            else if(t == typeof(VMSettings))
            {
                currentview = new VMSettings(maintab);
            }
            else if (t == typeof(VMMap))
            {
                currentview = new VMMap(maintab);
            }
            else
            {

            }
        }

    }
}
