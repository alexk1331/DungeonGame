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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SettingsApply.setproperties();
            SettingsApply.applyres(this);
            SettingsApply.applylang(this);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            WinSettings sett = new WinSettings();
            sett.Owner = this;
            SettingsApply.applyres(sett);
            this.Hide();
            
            sett.ShowDialog();
            SettingsApply.applyres(this);
            this.Show();
            
        }

        
    }
}
