using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NOLIKI
{
    public partial class MainPage : ContentPage
    {
        Grid grid4x1, grid3x3;
        Button новая_игра, первый, тема;
        BoxView b;
        bool esi = false;
        
        public MainPage()
        {

            grid4x1 = new Grid
            {
                BackgroundColor = Color.AliceBlue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(3,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };

            новая_игра = new Button()
            {
                Text = "НОВАЯ ИГРА"
            };
            новая_игра.Clicked += Новая_игра_Clicked;

            первый = new Button()
            {
                Text = "Кто первый?"
            };
            первый.Clicked += Первый_Clicked;

            тема = new Button()
            {
                Text = "ТЕМА"
            };

            grid4x1.Children.Add(новая_игра, 0, 1);
            grid4x1.Children.Add(первый, 0, 2);
            grid4x1.Children.Add(тема, 0, 3);
            Content = grid4x1;


        }

        private  void Первый_Clicked(object sender, EventArgs e)
        {
            Кто_первый();
        }
        public async void Кто_первый()
        {
            string e_vali = await DisplayPromptAsync("Кто первый?", "Выбери 1-белый,2-зеленый", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_vali == "1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }

        private void Новая_игра_Clicked(object sender, EventArgs e)
        {
            Кто_первый();
            Новая_игра();
        }

        public void Новая_игра()
        {
            grid3x3 = new Grid
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)} 
                }
                
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b = new BoxView { Color = Color.Green };//
                    grid3x3.Children.Add(b, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            }
            grid4x1.Children.Add(grid3x3, 0, 0);
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (BoxView)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esi)
            {
                b.Color = Color.White;
                esi = false;
            }
            else
            {
                b.Color = Color.Yellow;
                esi = true;
            }
        }
    }
}
