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
            Panel mainc = (Panel)win.Content;
            foreach(FrameworkElement cc in LogicalTreeHelper.GetChildren(win))
            {
                applylangtoel(cc);
            }
        }

        private static void applylangtoel(FrameworkElement cc)
        {
            if(VisualTreeHelper.GetChildrenCount(cc)>0)
            {
                for (int i=0; i<VisualTreeHelper.GetChildrenCount(cc);i++)
                {
                    applylangtoel((FrameworkElement)VisualTreeHelper.GetChild(cc, i));
                }
            }
            foreach(KeyValuePair<string, string> text in controls)
            {
                if(cc.Name==text.Key)
                {
                    string t = cc.GetType().ToString();

                    switch (t) 
                    {
                        case "System.Windows.Controls.Button":
                            Button b = (Button)cc;
                            b.Content = text.Value;
                            break;
                        case "System.Windows.Controls.TextBlock":
                            TextBlock tb = (TextBlock)cc;
                            tb.Text = text.Value;
                            break;
                        case "System.Windows.Controls.CheckBox":
                            CheckBox cb = (CheckBox)cc;
                            cb.Content = text.Value;
                            break;
                    }
                }
            }
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
