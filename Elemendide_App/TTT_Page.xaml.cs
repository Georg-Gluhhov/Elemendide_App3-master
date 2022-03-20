using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Elemendide_App.StepperSlider_page;
namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TTT_Page : ContentPage
    {
        Grid grid2X1, grid3X3;
        Xamarin.Forms.Image b;
        Image img1, img2;
        Button uus_nang, style;
        public bool esimene;    
        public int F=0;
        public static string Style1 = "2";
        public TTT_Page()
        {
            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Gray,
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
                    b = new Xamarin.Forms.Image { Source = "null1.png"};
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
            style = new Button()
            {
                Text = "Style"
            };
            img1 = new Image { Source = ImageSource.FromFile("krest"+Style1+".png") };
            grid2X1.Children.Add(uus_nang, 0,0);
            grid2X1.Children.Add(img1, 0, 1);
            grid2X1.Children.Add(style, 0,2);
            style.Clicked += Style_Clicked;
            Content = grid2X1;
        }

        private async void Style_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperSlider_page());
        }

        public async void Kes_on_esimene()
        {
            string esimine = await DisplayPromptAsync("Kes on esimene?","Valik",initialValue:"1",maxLength:1,keyboard:Keyboard.Numeric);
            if (esimine == "1")
            {
                esimene = true;
                img1.Source = ImageSource.FromFile("krest" + Style1 + ".png");
            }
            else
            {
                esimene = false;
                img1.Source = ImageSource.FromFile("Nolik" + Style1 + ".png");
            }
        }
        int Tulemus = 2;
        int[,] Tulemused = new int[3, 3];

        private void Uus_nang_Clicked(object sender, EventArgs e)
        {
            grid2X1.Children.Remove(uus_nang);
            grid2X1.Children.Remove(style);
            Uus_nang();
            Kes_on_esimene();

        }
        public void Uus_nang()
        {
            grid3X3 = new Grid
            {
                BackgroundColor = Color.FromRgb(RED,GREEN,BLUE),
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
                    b = new Xamarin.Forms.Image { Source = "null1.png" };
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
            if (checkTie())
            {
                DisplayAlert("Mängu lõpp", "mäng on viigis", "OK");
            }
            return Tulemus;

        }
        public void lopp()
        {
            Tulemus = Kontroll();
            F = 1;
            if (Tulemus == 0)
            {
                DisplayAlert("Võit", "Traps", "ok!");
                Tulemus = 2;
                Tulemused = new int[3, 3];
                grid2X1.Children.Add(uus_nang, 0, 1);
                grid2X1.Children.Add(style, 0, 2);
                F = 0;
            }
            if (Tulemus == 1)
            {
                DisplayAlert("Võit", "Trips", "ok!");
                Tulemus = 2;
                Tulemused = new int[3, 3];
                grid2X1.Children.Add(uus_nang, 0, 1);
                grid2X1.Children.Add(style, 0, 2);
                F = 0;
            }
        }
        private bool checkTie()
        {
            for (int i = 0; i < Tulemused.GetLength(0); i++)
            {
                for (int j = 0; j < Tulemused.GetLength(1); j++)
                {
                    if (Tulemused[i, j] == 2)
                    {
                        return false;
                    }
                }
            }
            if (F == 0)
            {
                return false;
            }
            return true;
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (Xamarin.Forms.Image)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esimene == true)
            {
                b.Source = ImageSource.FromFile("krest" + Style1 + ".png");
                esimene = false;
                Tulemused[r, c] =1;
                img1.Source = ImageSource.FromFile("Nolik" + Style1 + ".png");
            }
            else
            {
                b.Source = ImageSource.FromFile("Nolik" + Style1 + ".png");
                esimene = true;
                Tulemused[r, c] =2 ;
                img1.Source = ImageSource.FromFile("krest" + Style1 + ".png");
            }
            grid3X3.Children.Add(b,c,r);
            lopp();
        }
    }
}