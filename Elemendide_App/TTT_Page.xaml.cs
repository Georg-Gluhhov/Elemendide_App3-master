using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TTT_Page : ContentPage
    {
        Grid grid2X1, grid3X3;
        BoxView b;
        Button uus_nang;
        public bool esimene;
        public TTT_Page()
        {
            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Blue,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };
            grid3X3 = new Grid
            {
                BackgroundColor = Color.Red,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b = new BoxView { BackgroundColor=Color.Green};
                    grid3X3.Children.Add(b,j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }

            };
            uus_nang = new Button()
            {
                Text = "Uus nang"
            };
            uus_nang.Clicked += Uus_nang_Clicked;


            grid2X1.Children.Add(uus_nang, 0,1);

            Content = grid2X1;
        }
        public async void Kes_on_esimene()
        {
            string esimine = await DisplayPromptAsync("Kes on esimene?","Valik",initialValue:"1",maxLength:1,keyboard:Keyboard.Numeric);
            if (esimine == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        int Tulemus = 2;
        int[,] Tulemused = new int[3, 3];

        private void Uus_nang_Clicked(object sender, EventArgs e)
        {
            Uus_nang();
            Kes_on_esimene();
        }
        public void Uus_nang()
        {
            grid3X3 = new Grid
            {
                BackgroundColor = Color.Red,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b = new BoxView { BackgroundColor = Color.Green };
                    grid3X3.Children.Add(b, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            };
            grid2X1.Children.Add(grid3X3, 0, 0);
        }
        public int Kontroll()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                Tulemus = 0;
            }
            else if (Tulemused[0, 1] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                Tulemus = 0;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                Tulemus = 0;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] ==2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                Tulemus = 1;
            }
            else if (Tulemused[0, 1] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[1, 2] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                Tulemus = 1;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 0] == 2)
            {
                Tulemus = 1;
            }

            return Tulemus;

        }
        public void lopp()
        {
            Tulemus = Kontroll();
            if (Tulemus == 0)
            {
                DisplayAlert("Võit", "42", "ok!");
                Tulemus = 2;
            }
            if (Tulemus == 1)
            {
                DisplayAlert("Võit", "32", "ok!");
                Tulemus = 2;
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (BoxView)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esimene == true)
            {
                b = new BoxView { BackgroundColor = Color.Yellow };
                esimene = false;
                Tulemused[r, c] =1;
            }
            else
            {
                b = new BoxView { BackgroundColor = Color.Red };
                esimene = true;
                Tulemused[r, c] =2 ;
            }
            grid3X3.Children.Add(b,c,r);
            lopp();
        }
    }
}