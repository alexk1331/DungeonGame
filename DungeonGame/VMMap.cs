using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace DungeonGame
{
    public class VMMap:ViewBase
    {
        Grid mapgrid = new Grid();
        Canvas canv = new Canvas();
        Grid actiongrid = new Grid();
        Canvas mmap = new Canvas();
        Viewbox mapvb = new Viewbox();
        Grid menugrid = new Grid();
        bool mapvis;
        //-------------------------------------------------pan and zoom
        private Point _pointOnClick; // Click Position for panning
        private ScaleTransform _scaleTransform;
        private TranslateTransform _translateTransform;
        private TransformGroup _transformGroup;
        //-------------------------------------------------

        public VMMap(ContentControl cc) : base(cc)
        {
            Account.inicialize();
            _translateTransform = new TranslateTransform();
            _scaleTransform = new ScaleTransform();
            _transformGroup = new TransformGroup();
            _transformGroup.Children.Add(_scaleTransform);
            _transformGroup.Children.Add(_translateTransform);
            

            mmap.RenderTransform = _transformGroup;
        }
        public override void createview()
        {
            mapvis = false;
            Grid mg = new Grid();
            RowDefinition rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.1, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            mg.RowDefinitions.Add(new RowDefinition());
            rd1 = new RowDefinition();
            rd1.Height = new GridLength(0.25, GridUnitType.Star);
            mg.RowDefinitions.Add(rd1);
            ColumnDefinition cd1 = new ColumnDefinition();
            cd1.Width = new GridLength(0.3, GridUnitType.Star);
            mg.ColumnDefinitions.Add(cd1);
            mg.ColumnDefinitions.Add(new ColumnDefinition());
            cd1 = new ColumnDefinition();
            cd1.Width = new GridLength(0.4, GridUnitType.Star);
            mg.ColumnDefinitions.Add(cd1);

            Grid contrlgrid = new Grid();
            Grid.SetColumn(contrlgrid, 1);
            Grid.SetRow(contrlgrid, 2);
            contrlgrid.RowDefinitions.Add(new RowDefinition());
            contrlgrid.RowDefinitions.Add(new RowDefinition());
            contrlgrid.ColumnDefinitions.Add(new ColumnDefinition());
            contrlgrid.ColumnDefinitions.Add(new ColumnDefinition());
            contrlgrid.ColumnDefinitions.Add(new ColumnDefinition());
            contrlgrid.ColumnDefinitions.Add(new ColumnDefinition());

            Button upb = new Button();
            Grid.SetColumn(upb, 1);
            Grid.SetRow(upb, 0);
            upb.Content = "↑";
            upb.Name = "upb";
            upb.Click += new RoutedEventHandler(controlb_Click);
            Button downb = new Button();
            Grid.SetColumn(downb, 1);
            Grid.SetRow(downb, 1);
            downb.Content = "↓";
            downb.Name = "downb";
            downb.Click += new RoutedEventHandler(controlb_Click);
            Button leftb = new Button();
            Grid.SetColumn(leftb, 0);
            Grid.SetRow(leftb, 1);
            leftb.Content = "←";
            leftb.Name = "leftb";
            leftb.Click += new RoutedEventHandler(controlb_Click);
            Button rightb = new Button();
            Grid.SetColumn(rightb, 2);
            Grid.SetRow(rightb, 1);
            rightb.Content = "→";
            rightb.Name = "rightb";
            rightb.Click += new RoutedEventHandler(controlb_Click);

            contrlgrid.Children.Add(upb);
            contrlgrid.Children.Add(downb);
            contrlgrid.Children.Add(leftb);
            contrlgrid.Children.Add(rightb);

            Button temp = new Button();
            temp.Click += new RoutedEventHandler(newmap);
            temp.Content = "temp";
            contrlgrid.Children.Add(temp);

            Button minmap = new Button();
            minmap.Content = "MAP";
            Grid.SetColumn(minmap, 2);
            minmap.Click += new RoutedEventHandler(minimap);
            Grid.SetColumn(mapvb, 1);
            Grid.SetRow(mapvb, 1);

            Button menu = new Button();
            menu.Content = "MENU";
            menu.Margin = new Thickness(GlobalMainViewModel.win.ActualWidth*0.15, 0, GlobalMainViewModel.win.ActualWidth * 0.15, 0);
            menu.Click += new RoutedEventHandler(menu_click);
            Grid.SetColumn(menu, 1);
            mg.Children.Add(menu);

            Grid.SetColumn(menugrid, 1);
            Grid.SetRow(menugrid, 1);
            menugrid.RowDefinitions.Add(new RowDefinition());
            menugrid.RowDefinitions.Add(new RowDefinition());
            menugrid.Visibility = Visibility.Collapsed;
            menugrid.Margin = new Thickness(GlobalMainViewModel.win.ActualWidth * 0.1, 0, GlobalMainViewModel.win.ActualWidth * 0.1, 0);
            Button mainmanu = new Button();
            mainmanu.Content = "Main Menu";
            mainmanu.Click += new RoutedEventHandler(mainmenu_click);
            menugrid.Children.Add(mainmanu);

            //mapvb.Visibility = Visibility.Collapsed;
            mg.Children.Add(mapvb);
            mg.Children.Add(minmap);
            mg.Children.Add(contrlgrid);
            Grid.SetColumn(mapgrid, 1);
            Grid.SetRow(mapgrid, 1);
            mapgrid.Children.Add(canv);
            mg.Children.Add(mapgrid);
            mg.Children.Add(menugrid);
            Grid.SetColumn(actiongrid, 2);
            Grid.SetRow(actiongrid, 3);
            mg.Children.Add(actiongrid);
            maintab.Content = mg;
        }

        private void mainmenu_click(object sender, RoutedEventArgs e)
        {
            GlobalMainViewModel.switchview(typeof(VMStart));
        }

        private void menu_click(object sender, RoutedEventArgs e)
        {
            if(menugrid.Visibility==Visibility.Collapsed)
            {
                menugrid.Visibility = Visibility.Visible;
            }
            else
            {
                menugrid.Visibility = Visibility.Collapsed;
            }
        }

        private void minimap(object sender, RoutedEventArgs e)
        {
            if(mapvis)
            {
                mapvis = false;
                mapvb.Visibility = Visibility.Collapsed;
                canv.Visibility = Visibility.Visible;
                canvpaint(canv);
            }
            else
            {
                showmap();
                canv.Visibility = Visibility.Collapsed;
                mapvb.Visibility = Visibility.Visible;
//MessageBox.Show("" + mapvb.ActualHeight);
                mapvis = true;
            }
        }

        private void showmap()
        {
            //mapvb.ClipToBounds = true;
            //mapvb.StretchDirection = StretchDirection.Both;
            mapvb.Stretch = Stretch.UniformToFill;
            mmap.MouseWheel += Mapvb_MouseWheel;
            mmap.MouseLeftButtonDown += Mmap_MouseLeftButtonDown;
            mmap.MouseLeftButtonUp += Mmap_MouseLeftButtonUp;
            mmap.MouseMove += Mmap_MouseMove;
            mmap.Width = Math.Max(Account.player_map.width, Account.player_map.height)+1;
            mmap.Height = mmap.Width;
            mapvb.Child = mmap;
            paintmmap();
        }

        private void Mmap_MouseMove(object sender, MouseEventArgs e)
        {
            //ToolTip for informations
            //showToolTip(e);
            //Return if mouse is not captured
            if (!mmap.IsMouseCaptured) return;
            //Point on move from Parent
            Point pointOnMove = e.GetPosition((FrameworkElement)mmap.Parent);
            //set TranslateTransform
            _translateTransform.X = mmap.RenderTransform.Value.OffsetX - ((_pointOnClick.X - pointOnMove.X)*0.1);
            _translateTransform.Y = mmap.RenderTransform.Value.OffsetY - ((_pointOnClick.Y - pointOnMove.Y)*0.1);
            //Update pointOnClic
            _pointOnClick = e.GetPosition((FrameworkElement)mmap.Parent);

        }

        private void Mmap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Release Mouse Capture
            mmap.ReleaseMouseCapture();
            //Set cursor by default
            Mouse.OverrideCursor = null;
        }

        private void Mmap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Capture Mouse
            mmap.CaptureMouse();
            //Store click position relation to Parent of the canvas
            _pointOnClick = e.GetPosition((FrameworkElement)mmap.Parent);

        }

        private void Mapvb_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //Point de la souris
            Point mousePosition = e.GetPosition(mmap);
            //Actual Zoom
            double zoomNow = Math.Round(mmap.RenderTransform.Value.M11, 1);
            //ZoomScale
            double zoomScale = 0.1;
            //Positive or negative zoom
            double valZoom = e.Delta > 0 ? zoomScale : -zoomScale;
            //Point de la souris pour le panning et zoom/dezoom
            Point pointOnMove = e.GetPosition((FrameworkElement)mmap.Parent);
            //RenderTransformOrigin (doesn't fully working)
            mmap.RenderTransformOrigin = new Point(mousePosition.X / mmap.ActualWidth, mousePosition.Y / mmap.ActualHeight);
            //Appel du zoom
            if (zoomNow+valZoom>0)
            {
                Zoom(new Point(mousePosition.X, mousePosition.Y), zoomNow + valZoom);
            }
        }
        private void Zoom(Point point, double scale)
        {
            //Calcul des centres selon la position de la souris
            double centerX = (point.X - _translateTransform.X) / _scaleTransform.ScaleX;
            double centerY = (point.Y - _translateTransform.Y) / _scaleTransform.ScaleY;
            //Mise à l'échelle
            _scaleTransform.ScaleX = scale;
            _scaleTransform.ScaleY = scale;
            //Retablissement du translate pour éviter un décalage
            _translateTransform.X = point.X - centerX * _scaleTransform.ScaleX;
            _translateTransform.Y = point.Y - centerY * _scaleTransform.ScaleY;
        }

        private void paintmmap()
        {
            
            mmap.Background = Brushes.Black;
            mmap.Children.Clear();
            double hpoint = 1; //mmap.Height / Account.player_map.height;
            double wpoint = 1;  //mmap.Width / Account.player_map.width;
            for (int i = 0; i < Account.player_map.height-1; i++)
            {
                for (int j = 0; j < Account.player_map.width-1; j++)
                {
                    if (Account.player_map.tiles[i, j].type == 1)
                    {
                        Rectangle nb = new Rectangle();
                        nb.Stroke = Brushes.Blue;
                        nb.StrokeThickness = 0;
                        nb.Margin = new Thickness(1);
                        nb.SnapsToDevicePixels = true;
                        nb.Fill = Brushes.White;
                        nb.Height = hpoint;
                        nb.Width = wpoint;
                        Canvas.SetTop(nb, wpoint + (wpoint * j));
                        Canvas.SetLeft(nb, hpoint + (hpoint * i));
                        
                        if (Account.player_map.tiles[i, j].contains.Contains("enter"))
                        {
                            nb.Fill = Brushes.Green;
                        }
                        if (Account.player_map.tiles[i, j].contains.Contains("exit"))
                        {
                            nb.Fill = Brushes.Blue;
                        }
                        mmap.Children.Add(nb);
                        if (j == Account.maptile.x && i == Account.maptile.y)
                        {
                            Ellipse player = new Ellipse();
                            Canvas.SetTop(player, wpoint*2+wpoint * j + wpoint * 0.25);
                            Canvas.SetLeft(player,hpoint*2+ hpoint * i + wpoint * 0.25);
                            player.Fill = Brushes.Red;
                            player.Height = hpoint * 0.5;
                            player.Width = wpoint * 0.5;

                            mmap.Children.Add(player);
                        }
                    }
                }
            }
        }



        private void controlb_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (mapvis) { return; }
            switch (b.Name)
            {
                case "leftb":
                    if (Account.player_map.tiles[Account.maptile.y - 1, Account.maptile.x].type == 1)
                    {
                        Account.maptile.y--;
                        canv = canvpaint(canv);
                    }
                    break;
                case "rightb":
                    if (Account.player_map.tiles[Account.maptile.y + 1, Account.maptile.x].type == 1)
                    {
                        Account.maptile.y++;
                        canv = canvpaint(canv);
                    }
                    break;
                case "upb":
                    if (Account.player_map.tiles[Account.maptile.y, Account.maptile.x - 1].type == 1)
                    {
                        Account.maptile.x--;
                        canv = canvpaint(canv);
                    }
                    break;
                case "downb":
                    if (Account.player_map.tiles[Account.maptile.y, Account.maptile.x + 1].type == 1)
                    {
                        Account.maptile.x++;
                        canv = canvpaint(canv);
                    }
                    break;
            }

        }

        private void actg_change()
        {
            MapTile pt = Account.player_map.tiles[Account.maptile.y, Account.maptile.x];
            ScrollViewer sv = new ScrollViewer();
            sv.CanContentScroll = true;
            StackPanel sp = new StackPanel();
            sv.Content = sp;
            actiongrid.Children.Add(sv);
            if (pt.contains.Contains("enter"))
            {
                Button nb = new Button();
                nb.Content = "UP";
                nb.MaxHeight = actiongrid.ActualHeight / 2;
                nb.MinHeight = actiongrid.ActualHeight / 2;
                nb.Click += delegate (object sender, RoutedEventArgs e) { changemap(sender, e, Account.player_map.deep-1); };
                sp.Children.Add(nb);
            }
            if (pt.contains.Contains("exit"))
            {
                Button nb = new Button();
                nb.Content = "Down";
                nb.MaxHeight = actiongrid.ActualHeight / 2;
                nb.MinHeight = actiongrid.ActualHeight / 2;
                nb.Click += delegate (object sender, RoutedEventArgs e) { changemap(sender, e, Account.player_map.deep +1); };
                sp.Children.Add(nb);
            }
        }

        private void changemap(object sender, EventArgs e, int depth)//should start generate NEXT map in background when player enter THIS. Maps over ~150 deep take minutes to gen and up 500 may take even hour
        {
            if(depth>=0&&!mapvis)
            {
                int pos = 0;//0-go down, 1-go up
                if(!Account.maps.Exists(x=>x.deep==depth))
                {
                    Account.maps.Add(new Map(depth));
                }
                for(int i=0;i<Account.maps.Count;i++)
                {
                    if(Account.maps[i].deep==depth)
                    {
                        if(Account.player_map.deep>depth)
                        {
                            pos = 1;
                        }
                        Account.player_map = Account.maps[i];
                        break;
                    }
                }
                if (pos == 0)
                {
                    MessageBox.Show("Descending to the level "+depth);
                    Account.maptile.x = Account.player_map.enter.x;
                    Account.maptile.y = Account.player_map.enter.y;
                }
                else
                {
                    MessageBox.Show("Ascending to the level " + depth);
                    Account.maptile.x = Account.player_map.exit.x;
                    Account.maptile.y = Account.player_map.exit.y;
                }
                
                canv=canvpaint(canv);
            }
        }

        private void newmap(object sender, RoutedEventArgs e)
        {
            mapgrid.Width = mapgrid.ActualHeight;
            canv.Width = mapgrid.ActualHeight;
            canv.Height = mapgrid.ActualHeight;

            canv = canvpaint(canv);
        }

        public Canvas canvpaint(Canvas canv)
        {
            //Account.inicialize();

            Map pmap = Account.player_map;

            //test---------------------------
            bool ex = false;
            for (int i = 0; i < pmap.width; i++)
            {
                for (int j = 0; j < pmap.height; j++)
                {
                    if (pmap.tiles[j, i].contains.Contains("exit"))
                    {
                        ex = true;
                    }
                }
            }
            if(!ex)
            {
                MessageBox.Show("NOEXIT!");//sometimes exit doesnt created. there must be some fixable issue but i dont want to adress it right now, so just try until it creates(FIX LATER!)
            }
            //----------------------------
            canv.Background = Brushes.SaddleBrown;
            canv.Children.Clear();
            double hpoint = canv.Height / 11;
            double wpoint = canv.Width / 11;
            Ellipse player = new Ellipse();
            for (int i = Account.maptile.x-5; i <= Account.maptile.x + 5; i++)
            {
                for (int j = Account.maptile.y - 5; j <= Account.maptile.y + 5; j++)
                {
                    if(i>=0&&j>=0&&j<pmap.height&&i<pmap.width)
                    {
                        if (pmap.tiles[j, i].type == 1)
                        {
                            Rectangle nb = new Rectangle();
                            nb.Stroke = Brushes.Blue;
                            nb.StrokeThickness = 0;
                            nb.Margin = new Thickness(1);
                            nb.SnapsToDevicePixels = true;
                            nb.Fill = Brushes.LightGray;

                            //===
                            nb.Height = hpoint;
                            nb.Width = wpoint;
                            Canvas.SetLeft(nb, wpoint*(j-(Account.maptile.y-5)));
                            Canvas.SetTop(nb, hpoint*(i-(Account.maptile.x-5)));
                            canv.Children.Add(nb);
                            if (pmap.tiles[j, i].contains.Contains("enter"))
                            {
                                Rectangle ent = new Rectangle();
                                ent.Fill = Brushes.Green;
                                ent.Height = hpoint - hpoint * 0.1;
                                ent.Width = wpoint - wpoint * 0.2;
                                Canvas.SetLeft(ent, wpoint * (j - (Account.maptile.y - 5))+wpoint*0.1);
                                Canvas.SetTop(ent, hpoint * (i - (Account.maptile.x - 5))+wpoint*0.1);
                                canv.Children.Add(ent);
                            }
                            if (pmap.tiles[j, i].contains.Contains("exit"))
                            {
                                Rectangle ent = new Rectangle();
                                ent.Fill = Brushes.Blue;
                                ent.Height = hpoint - hpoint * 0.1;
                                ent.Width = wpoint - wpoint * 0.2;
                                Canvas.SetLeft(ent, wpoint * (j - (Account.maptile.y - 5)) + wpoint * 0.1);
                                Canvas.SetTop(ent, hpoint * (i - (Account.maptile.x - 5)) + wpoint * 0.1);
                                canv.Children.Add(ent);
                                
                            }
                            if (i==Account.maptile.x&&j==Account.maptile.y)
                            {
                                Canvas.SetLeft(player, wpoint * (j - (Account.maptile.y - 5))+wpoint*0.25);
                                Canvas.SetTop(player, hpoint * (i - (Account.maptile.x - 5))+wpoint*0.25);
                                if (Account.player_map.tiles[Account.maptile.y, Account.maptile.x].contains.Count > 0)
                                {
                                    actg_change();
                                }
                                else
                                {
                                    actiongrid.Children.Clear();
                                }
                            }
                        }
                    }
                }
            }
            
            player.Fill = Brushes.Red;
            player.Height = hpoint * 0.5;
            player.Width = wpoint * 0.5;
            
            canv.Children.Add(player);
            return canv;
        }

    }
}
