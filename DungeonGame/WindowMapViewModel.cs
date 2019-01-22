using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DungeonGame
{
    class WindowMapViewModel
    {
        public Map currentmap { get; set; }

        public WindowMapViewModel(Grid ng)
        {
            currentmap = new Map(0);
            mg = ng;
        }

        public Grid mg;

        public void paintmap()
        {
            mg.Children.Clear();
            mg.RowDefinitions.Clear();
            mg.ColumnDefinitions.Clear();

            for (int i = 0; i < currentmap.size; i++)
            {
                mg.RowDefinitions.Add(new RowDefinition());
                mg.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < currentmap.size; i++)
            {
                for (int j = 0; j < currentmap.size; j++)
                {
                    Button nb = new Button();
                    if (currentmap.tiles[i, j].type == 0)
                    {
                        nb.Background = Brushes.Gray;
                    }
                    else
                    {
                        nb.Background = Brushes.White;
                    }
                    Grid.SetRow(nb, i);
                    Grid.SetColumn(nb, j);
                    if (i == Account.maptile.x && j == Account.maptile.y)
                    {
                        nb.Content = "P";
                    }
                    mg.Children.Add(nb);
                }
            }

        }

        public void movecommand(string contrl)
        {
            switch (contrl)
            {
                case "Left":
                    if (Account.maptile.y - 1 < 0 || Account.maptile.y - 1 > currentmap.tiles.Length)
                    {
                        break;
                    }
                    if (movecheck(currentmap.tiles[Account.maptile.x, Account.maptile.y - 1]) == 1)
                    {
                        Account.maptile.y -= 1;
                        paintmap();
                    }

                    break;
                case "Right":
                    if (Account.maptile.y + 1 < 0 || Account.maptile.y + 1 >= currentmap.size)
                    {
                        break;
                    }
                    if (movecheck(currentmap.tiles[Account.maptile.x, Account.maptile.y + 1]) == 1)
                    {
                        Account.maptile.y += 1;
                        paintmap();
                    }
                    break;
                case "Forward":
                    if (Account.maptile.x - 1 < 0 || Account.maptile.x - 1 > currentmap.tiles.Length)
                    {
                        break;
                    }
                    if (movecheck(currentmap.tiles[Account.maptile.x - 1, Account.maptile.y]) == 1)
                    {
                        Account.maptile.x -= 1;
                        paintmap();
                    }
                    break;
                case "Backward":
                    if (Account.maptile.x + 1 < 0 || Account.maptile.x + 1 >= currentmap.size)
                    {
                        break;
                    }
                    if (movecheck(currentmap.tiles[Account.maptile.x + 1, Account.maptile.y]) == 1)
                    {
                        Account.maptile.x += 1;
                        paintmap();
                    }
                    break;
            }
        }
   

        public int movecheck(MapTile mt)
        {
            if (mt != null)
            {
                return mt.type;
            }
            else { return 0; }
        }



    }
}
