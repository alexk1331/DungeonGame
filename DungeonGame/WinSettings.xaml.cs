using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DungeonGame
{
    /// <summary>
    /// Логика взаимодействия для WinSettings.xaml
    /// </summary>
    public partial class WinSettings : Window
    {
        public WinSettings()
        {
            InitializeComponent();
            
            int i = 0;
            foreach(TextBlock ic in res_list.Items)
            {
                string res = Properties.Settings.Default.Width + "x" + Properties.Settings.Default.Height;
                if(ic.Text==res)
                {
                    res_list.SelectedIndex = i;
                    break;
                }
                i++;
            }
            fullscreen_check.IsChecked = Properties.Settings.Default.Fullscreen;

            i = 0;
            foreach (TextBlock ic in lang_list.Items)
            {
                string res = Properties.Settings.Default.Language;
                if (ic.Name == res)
                {
                    lang_list.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_changes_button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock lang = (TextBlock)lang_list.SelectedItem;
            SettingsApply.psettings.setsettings(res_list.Text, lang.Name, (bool)fullscreen_check.IsChecked);
            
            SettingsApply.globalsettingsapply();
        }

    }
}
