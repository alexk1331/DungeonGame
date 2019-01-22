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
    /// Логика взаимодействия для WindowGameMain.xaml
    /// </summary>
    public partial class WindowGameMain : Window
    {
        WindowMapViewModel temp;
        public WindowGameMain()
        {
            InitializeComponent();
            SettingsApply.applyres(this);
            SettingsApply.applylang(this);

            temp =  new WindowMapViewModel(MapGrid);
            temp.paintmap();

        }

        private void testt_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int s = r.Next(5, 20);
            temp.currentmap.generatemap(s);
            temp.paintmap();
        }

        private void Moving_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            temp.movecommand(b.Name);
        }
    }
}
