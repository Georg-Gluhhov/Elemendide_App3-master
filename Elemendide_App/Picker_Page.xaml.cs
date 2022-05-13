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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Entry en;
        Grid grid2X1;
        Button btn1, btn2, btn3;
        string newUrl = "";
        List<string> lehed = new List<string> { "https://tahvel.edu.ee", "https://moodle.hitsa.ee","" };
        public Picker_Page()
        {
            en = new Entry { Text = "Entry Url", IsVisible = false };

            grid2X1 = new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Gray,
                
                
            };

            btn1 = new Button
            {
                Text="next"
                
            };     
            btn2 = new Button
            {
                Text="privious"
            };
            btn3 = new Button
            {
                Text = "add",
                IsVisible = false
            };
            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
            btn3.Clicked += Btn3_Clicked;
            en.TextChanged += En_TextChanged;
            en.Completed += En_Completed;
            picker = new Picker
            {
                Title = "Webilehed"
            };
            grid2X1.Children.Add(btn2, 0, 0);         
            grid2X1.Children.Add(btn1, 1,0);     
            grid2X1.Children.Add(btn3, 2,0);
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("Customlink");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            webView.GestureRecognizers.Add(swipe);
            st = new StackLayout { Children = { picker,en, grid2X1 } };
            Content = st;

        }

        private async void Btn3_Clicked(object sender, EventArgs e)
        {
            string siteName = await DisplayPromptAsync("Site Name","Name");
            picker.Items.Add(siteName);
            NewLink();
        }
        private void NewLink()
        {
            lehed.Add(newUrl);
        }
        private void Btn2_Clicked(object sender, EventArgs e)
        {
            webView.GoBack();
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            webView.GoForward();
        }

        private void En_Completed(object sender, EventArgs e)
        {

            newUrl = en.Text;
            lehed.Insert(2,newUrl);
            WebLoad();
        }

        private void En_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (en.Text != "")
            {
                newUrl = en.Text;
                lehed.Insert(2, newUrl);
                btn3.IsVisible = true;
            }
            else
            {
                btn3.IsVisible = false;
            }
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3]};
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(picker.SelectedIndex == 2)
            {
                en.IsVisible = true;
            }
            else
            {
                en.IsVisible = false;
                WebLoad();
            }
        }
        private void WebLoad()
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            };
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            st.Children.Add(webView);
        }
    }
}