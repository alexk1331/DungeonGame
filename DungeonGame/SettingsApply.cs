using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonGame
{
    static class  SettingsApply
    {
        public static ProgramSett psettings;
        public static Dictionary<string, string> controls;

        static SettingsApply()
        {
            try
            {
                ProgramSett tempp = new ProgramSett();
            }
            catch
            {
                string path = Directory.GetCurrentDirectory() + @"\settings.json";
                using (StreamReader sr = new StreamReader(path))
                {
                    string errorstring = sr.ReadToEnd();
                    bool end = false;
                    string good = "";
                    int i = 0;
                    while(!end)
                    {
                        
                        good = good + errorstring[i];
                        if(errorstring[i]=='}')
                        {
                            end = true;
                        }
                        i++;
                    }
                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(path, false))
                    {
                        sw.WriteLine(good);
                    }
                }
            }
            finally
            {
                psettings = new ProgramSett();
            }
        }

       public static void applyres(Window win)
        {
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (Properties.Settings.Default.Fullscreen == true)
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

        public static void applylang(List<FrameworkElement> clist)
        {
            foreach(FrameworkElement cc in clist)
            {
                applylangtoel(cc);
            }
        }

        public static string applylangtoel(FrameworkElement cc)
        {
            return controls.FirstOrDefault(x => x.Key == cc.Name).Value;
        }

        public static void setproperties()
        {
            Properties.Settings.Default.Height = psettings.res_height;
            Properties.Settings.Default.Width = psettings.res_width;
            Properties.Settings.Default.Language = psettings.lang;
            Properties.Settings.Default.Fullscreen = psettings.fullscreen;
            controls = psettings.returndict("controls");
        }

    }
}
