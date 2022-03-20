using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Elemendide_App.TTT_Page;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepperSlider_page : ContentPage
    {
        Label lb;
        Slider sld, sld2, sld3;
        BoxView box1;
        Image Img1, Img2, Img3, Img4;
        Button btn1, btn2, btn3,btn4,btn5;
        Grid  grid3X3;
        public static double RED,GREEN,BLUE;
        string TT = "krest";


        public StepperSlider_page()
        {
            lb = new Label
            {
                TextColor = Color.Black,
                FontSize = 18,
                FontFamily = "Comic Sans MS",
                HorizontalOptions = LayoutOptions.Center,
            };


            sld = new Slider
            {
                Minimum=0,
                Maximum=255,
                Value=0,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red

            };
            sld.ValueChanged += Sld_ValueChanged;
            

            sld2 = new Slider
            {
                Minimum=0,
                Maximum=255,
                Value=0,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red

            };
            sld2.ValueChanged += Sld2_ValueChanged;
            
            sld3 = new Slider
            {
                Minimum=0,
                Maximum=255,
                Value=0,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red

            };
            sld3.ValueChanged += Sld3_ValueChanged;
            btn1 = new Button
            {
                Text= "tagasi"
            };

            btn2 = new Button
            {
                Text= "muuta"
            };
                       
            btn3 = new Button
            {
                Text= "Valige1"
            };

            btn4 = new Button
            {
                Text= "Valige2"
            };

            btn5 = new Button
            {
                Text= "Valige3"
            };
            btn4.Clicked += Btn4_Clicked;
            btn3.Clicked += Btn3_Clicked;
            btn5.Clicked += Btn5_Clicked;
            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
            Img1 = new Image
            {
                Source = ImageSource.FromFile(TT+"1.png")
            };
            Img2 = new Image
            {
                Source = ImageSource.FromFile(TT+"2.png")
            };
            Img3 = new Image
            {
                Source = ImageSource.FromFile(TT+"3.png"),
                
            };
            Img4 = new Image
            {
                Source = ImageSource.FromFile(TT + Style1 + ".png")
            };
            box1 = new BoxView
            {
                Color=Color.FromRgb(RED,GREEN,BLUE)
            };
                        Img4.Source = ImageSource.FromFile(TT + Style1 + ".png");
            grid3X3 = new Grid
            {
                BackgroundColor = Color.Gray,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
            };
            grid3X3.Children.Add(Img1, 0, 0);
            grid3X3.Children.Add(Img2, 1, 0);
            grid3X3.Children.Add(Img3, 2, 0);
            grid3X3.Children.Add(btn2, 2, 2);
            grid3X3.Children.Add(btn1, 0, 2);        
            grid3X3.Children.Add(Img4, 1, 2);
            grid3X3.Children.Add(btn5, 2, 1);
            grid3X3.Children.Add(btn4, 1, 1);
            grid3X3.Children.Add(btn3, 0, 1);
            StackLayout st = new StackLayout
            {
                Children = { box1, lb, sld, sld2, sld3, grid3X3 }
            };
            Content = st;
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            if (TT== "krest")
            {
                TT = "Nolik";
            }
            else
            {
                TT = "krest";
            }
            Img1.Source = ImageSource.FromFile(TT + "1.png");
            Img2.Source = ImageSource.FromFile(TT + "2.png");
            Img3.Source = ImageSource.FromFile(TT + "3.png");
            Img4.Source = ImageSource.FromFile(TT + Style1 + ".png");

        }

        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TTT_Page());
        }

        private void Btn5_Clicked(object sender, EventArgs e)
        {
            Style1 = "3";
            Img4.Source = ImageSource.FromFile(TT+"3.png");
        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            Style1 = "2";
            Img4.Source = ImageSource.FromFile(TT + "2.png");
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            Style1 = "1";
            Img4.Source = ImageSource.FromFile(TT + "1.png");
        }

        private void Sld3_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lb.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            BLUE = e.NewValue;
            box1.Color = Color.FromRgb(RED, GREEN, BLUE);
        }

        private void Sld2_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lb.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            GREEN = e.NewValue;
            box1.Color = Color.FromRgb(RED, GREEN, BLUE);
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lb.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            RED = e.NewValue;
            box1.Color = Color.FromRgb(RED, GREEN, BLUE);
        }
    }
}