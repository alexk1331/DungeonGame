using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DungeonGame
{
    public class VMSettings:ViewBase
    {
        ComboBox resolution = new ComboBox();
        CheckBox fullscreen = new CheckBox();
        ComboBox language = new ComboBox();

        public VMSettings(ContentControl cc) : base(cc)
        {

        }

        public override void createview()
        {
            Grid mg = new Grid();
            RowDefinition rd1 = new RowDefinition();
            rd1.Height = new GridLength(4, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            mg.RowDefinitions.Add(new RowDefinition());
            mg.ColumnDefinitions.Add(new ColumnDefinition());
            mg.ColumnDefinitions.Add(new ColumnDefinition());
            StackPanel stp = new StackPanel();
            TextBlock tb = new TextBlock();
            tb.Name="choose_resolution_text";
            tb.Text = SettingsApply.applylangtoel(tb);
            stp.Children.Add(tb);
            resolution.Margin = new Thickness(0, 0, 180, 0);
            TextBlock tb1 = new TextBlock();
            tb1.Text = "1024x768";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1280x720";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1280x768";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1280x800";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1280x1024";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1360x768";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1366x768";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1680x1050";
            resolution.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "1920x1080";
            resolution.Items.Add(tb1);
            stp.Children.Add(resolution);
            fullscreen.Name = "fullscreen_check";
            fullscreen.Margin = new Thickness(0, 10, 5, 0);
            fullscreen.HorizontalAlignment = HorizontalAlignment.Right;
            fullscreen.Content = SettingsApply.applylangtoel(fullscreen);
            string res = Properties.Settings.Default.Width + "x" + Properties.Settings.Default.Height;
            for (int i = 0; i < resolution.Items.Count; i++)
            {
                TextBlock tx = (TextBlock)resolution.Items[i];
                if (tx.Text == res)
                {
                    resolution.SelectedIndex = i;
                }
            }
            fullscreen.IsChecked = Properties.Settings.Default.Fullscreen;
            stp.Children.Add(fullscreen);
            mg.Children.Add(stp);

            StackPanel stp2 = new StackPanel();
            Grid.SetColumn(stp2, 1);
            TextBlock tb2 = new TextBlock();
            tb2.Name = "choose_language_text";
            tb2.Text = SettingsApply.applylangtoel(tb2);
            stp2.Children.Add(tb2);
            language.Margin = new Thickness(0, 0, 80, 0);
            tb1 = new TextBlock();
            tb1.Text = "English";
            tb1.Name = "english";
            language.Items.Add(tb1);
            tb1 = new TextBlock();
            tb1.Text = "Українська";
            tb1.Name = "ukrainian";
            language.Items.Add(tb1);
            for (int i = 0; i < language.Items.Count; i++)
            {
                TextBlock tx = (TextBlock)language.Items[i];
                if (tx.Name == Properties.Settings.Default.Language)
                {
                    language.SelectedIndex = i;
                }
            }
            stp2.Children.Add(language);
            mg.Children.Add(stp2);
            Button clb = new Button();
            Grid.SetRow(clb, 1);
            clb.Name = "close_button";
            clb.Content = SettingsApply.applylangtoel(clb);
            clb.Margin = new Thickness(40, 10, 50, 10);
            clb.Click += new RoutedEventHandler(cancel_button_Click);
            mg.Children.Add(clb);

            Button sb = new Button();
            Grid.SetRow(sb, 1);
            Grid.SetColumn(sb, 1);
            sb.Name = "save_changes_button";
            sb.Content = SettingsApply.applylangtoel(sb);
            sb.Margin = new Thickness(50, 10, 40, 10);
            sb.Click += new RoutedEventHandler(save_changes_button_Click);
            mg.Children.Add(sb);

            maintab.Content = mg;
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            GlobalMainViewModel.switchview(typeof(VMStart));
        }

        private void save_changes_button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock lang = (TextBlock)language.SelectedItem;
            SettingsApply.psettings.setsettings(resolution.Text, lang.Name, (bool)fullscreen.IsChecked);
            SettingsApply.setproperties();
            SettingsApply.applyres(GlobalMainViewModel.win);
            GlobalMainViewModel.switchview(typeof(VMSettings));
        }
    }
}
