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
            GlobalMainViewModel.win = this;
            GlobalMainViewModel.maintab = MainCntcont;
            SettingsApply.setproperties();
            SettingsApply.applyres(this);
            //SettingsApply.applylang(this);
            GlobalMainViewModel.switchview(typeof(VMStart));
        }

        private void MainMenu_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
