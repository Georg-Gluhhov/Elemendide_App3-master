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
    public partial class Telefon_Page : ContentPage
    {
     public string[] Telefonid { get; set; }
        public List<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        public Telefon_Page()
        {
            Telefonid = new string[] { "iPhone 13", "Samsug Galaxy S21", "Xiaomi Mi T11" };
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            telefons = new List<Telefon>
            {
                new Telefon
                {
                    Nimetus="Samsung Galaxy S21", Tootja="Samsung", Hind=1349
                },
                new Telefon
                {
                    Nimetus="Xiaomi Mi 10T 5G", Tootja="Xiaomi", Hind=399
                },
                new Telefon
                {
                    Nimetus="Xiaomi Mi 11 5G", Tootja="Xiaomi", Hind=599
                },
                new Telefon
                {
                    Nimetus="iPhone 13", Tootja="Apple", Hind=1179
                },

            };
            list = new ListView
            {
               HasUnevenRows = true,
                ItemsSource = Telefonid,
                ItemTemplate=new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmat{0}" };
                    imageCell.SetBinding(ImageCell.DetailColorProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                    
                    
                    /*   Label nimetus = new Label { FontSize = 20 };
                      nimetus.SetBinding(Label.TextProperty, "Nimetus");

                      Label tootja = new Label();
                      tootja.SetBinding(Label.TextProperty, "Tootja");

                      Label hind = new Label();
                      hind.SetBinding(Label.TextProperty, "Hind");

                      return new ViewCell
                      {
                          View = new StackLayout
                          {
                              Padding = new Thickness(0, 5),
                              Orientation = StackOrientation.Vertical,
                              Children = { nimetus, tootja, hind }
                          }*/
                })
            };
            list.ItemTapped += List_ItemTapped;
            //list.ItemSelected += List_ItemSelected; 
            this.Content = new StackLayout { Children = { lbl_list, list } };
            }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                lbl_list.Text = e.SelectedItem.ToString();
        }
    }
}