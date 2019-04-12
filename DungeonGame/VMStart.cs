using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DungeonGame
{
    public class VMStart:ViewBase
    {
        public VMStart(ContentControl cc):base(cc)
        {

        }

        public override void createview()
        {
            Grid mg = new Grid();
            RowDefinition rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.5, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            mg.RowDefinitions.Add(new RowDefinition());
            rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.2, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            mg.RowDefinitions.Add(new RowDefinition());
            rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.2, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            mg.RowDefinitions.Add(new RowDefinition());
            rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.2, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            mg.RowDefinitions.Add(new RowDefinition());
            rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.5, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            ColumnDefinition cd = new ColumnDefinition();
            cd.Width = new GridLength(0.3, GridUnitType.Star);
            mg.ColumnDefinitions.Add(cd);
            mg.ColumnDefinitions.Add(new ColumnDefinition());
            cd = new ColumnDefinition();
            cd.Width = new GridLength(0.3, GridUnitType.Star);
            mg.ColumnDefinitions.Add(cd);
            Button ng = new Button();
            Grid.SetColumn(ng, 1);
            Grid.SetRow(ng, 1);
            ng.Name = "new_game_button";
            ng.Content = SettingsApply.applylangtoel(ng);
            ng.Click += new RoutedEventHandler(New_Game_Click);
            mg.Children.Add(ng);

            Button lg = new Button();
            Grid.SetColumn(lg, 1);
            Grid.SetRow(lg, 3);
            lg.Name = "load_game_button";
            lg.Content = SettingsApply.applylangtoel(lg);
            //ng.Click += new RoutedEventHandler(New_Game_Click);
            mg.Children.Add(lg);

            Button set = new Button();
            Grid.SetColumn(set, 1);
            Grid.SetRow(set, 5);
            set.Name = "settings_button";
            set.Content = SettingsApply.applylangtoel(set);
            set.Click += new RoutedEventHandler(Settings_Click);
            mg.Children.Add(set);

            Button ex = new Button();
            Grid.SetColumn(ex, 1);
            Grid.SetRow(ex, 7);
            ex.Name = "exit_button";
            ex.Content = SettingsApply.applylangtoel(ex);
            ex.Click += new RoutedEventHandler(Exit_Click);
            mg.Children.Add(ex);
            maintab.Content = mg;
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            GlobalMainViewModel.switchview(typeof(VMMap));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //GlobalMainViewModel.win.Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GlobalMainViewModel.switchview(typeof(VMSettings));
        }
    }
}
