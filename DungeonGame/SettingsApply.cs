using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace DungeonGame
{
    static class  SettingsApply
    {
        public static ProgramSett psettings;

        static SettingsApply()
        {
            psettings = new ProgramSett();

        }

       public static void globalsettingsapply()
        {
            setproperties();
            foreach (Window win in App.Current.Windows)
            {
                applyres(win);
                applylang(win);
            }
        }
       public static void applyres(Window win)
        {
            
            
            if(win.Owner==null)
            {
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            if(Properties.Settings.Default.Fullscreen==true)
            {
                win.ShowActivated = true;
                win.WindowState = WindowState.Maximized;
                
            }
            else
            {
                win.WindowState = WindowState.Normal;
                win.Height = Properties.Settings.Default.Height;
                win.Width = Properties.Settings.Default.Width;
            }
        }

        public static void applylang(Window win)
        {

        }

        public static void setproperties()
        {
            Properties.Settings.Default.Height = psettings.res_height;
            Properties.Settings.Default.Width = psettings.res_width;
            Properties.Settings.Default.Language = psettings.lang;
            Properties.Settings.Default.Fullscreen = psettings.fullscreen;
        }

    }
}
