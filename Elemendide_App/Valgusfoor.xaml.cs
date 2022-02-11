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
    public partial class Valgusfoor : ContentPage
    {
        Label lblRed,lblGreen,lblYellow;
        Frame GreenBox, YellowBox, RedBox;
        Button OnBtn,OffBtn;
        bool ON_OFF = true;
        public Valgusfoor()
        {
            this.BackgroundColor = Color.White;
            lblRed = new Label()
            {
                TextColor = Color.White,
                HorizontalTextAlignment=TextAlignment.Center,
                Text ="Red"

            };           
            this.BackgroundColor = Color.White;
            lblGreen = new Label()
            {
                TextColor = Color.White,
                HorizontalTextAlignment=TextAlignment.Center,
                Text ="Green"

            };           
            this.BackgroundColor = Color.White;
            lblYellow = new Label()
            {
                TextColor = Color.White,
                HorizontalTextAlignment=TextAlignment.Center,
                Text ="Yellow"

            };
            OnBtn = new Button()
            {
                TextColor = Color.White,
                Text = "Turn On",
                HorizontalOptions = LayoutOptions.Start,
    
            };
            OffBtn = new Button()
            {
                TextColor = Color.White,
                Text = "Turn Off",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End
            };

            GreenBox = new Frame()
            {
                Content= lblGreen,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Gray,
            };
            YellowBox = new Frame()
            {
                Content = lblYellow,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            RedBox = new Frame()
            {
                Content = lblRed,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            OnBtn.Clicked += OnBtn_Clicked;
            OffBtn.Clicked += OffBtn_Clicked;
            StackLayout st = new StackLayout { Children = { GreenBox, YellowBox ,RedBox, OnBtn, OffBtn } };
            Content = st;
        }

        private async void OffBtn_Clicked(object sender, EventArgs e)
        {
            ON_OFF = false;
        }

        private async void OnBtn_Clicked(object sender, EventArgs e)
        {
            ON_OFF = true;
            while (ON_OFF==true) { 
            GreenBox.BackgroundColor = Color.Green;
            await Task.Delay(5000);
            GreenBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);
            GreenBox.BackgroundColor = Color.Green;
            await Task.Delay(100);
            GreenBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);          
                GreenBox.BackgroundColor = Color.Green;
            await Task.Delay(100);
            GreenBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);

            YellowBox.BackgroundColor = Color.FromRgb(100, 100, 0);
            await Task.Delay(2500);
                YellowBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);
                YellowBox.BackgroundColor = Color.FromRgb(255,255,0); 
            await Task.Delay(100);
                YellowBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);

            RedBox.BackgroundColor = Color.FromRgb(255, 0, 0);
            await Task.Delay(5000);
                RedBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);
                RedBox.BackgroundColor = Color.FromRgb(255, 0,0); 
            await Task.Delay(100);
                RedBox.BackgroundColor = Color.Gray;
            await Task.Delay(100);
                RedBox.BackgroundColor = Color.FromRgb(255, 0,0); 
            await Task.Delay(100);
                RedBox.BackgroundColor = Color.Gray;

                YellowBox.BackgroundColor = Color.FromRgb(100, 100, 0);
                await Task.Delay(2500);
                YellowBox.BackgroundColor = Color.Gray;
                await Task.Delay(100);
                YellowBox.BackgroundColor = Color.FromRgb(255, 255, 0);
                await Task.Delay(100);
                YellowBox.BackgroundColor = Color.Gray;
                await Task.Delay(100);


            }
        }
    }
}