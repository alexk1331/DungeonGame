using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace DungeonGame
{
    public abstract class ViewBase
    {
        public ContentControl maintab;
        //public List<FrameworkElement> cntrls;

        public ViewBase(ContentControl cc)
        {
            maintab = cc;
            createview();
        }

        public virtual void createview()
        {

        }


    }
}
