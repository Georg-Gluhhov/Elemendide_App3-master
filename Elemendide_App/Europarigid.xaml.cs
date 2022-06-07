using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Europarigid : ContentPage
    {
        public static ObservableCollection<Euuropa> eurupos { get; set; }
        Label lbl_list;
        ListView listeu;
        Button lisaeu;
        Button kustutaeu;
        Addeu addeu = new Addeu();
        public Europarigid()
        {
            
            eurupos = new ObservableCollection<Euuropa>
            {
                new Euuropa {Nimetus="Nigeeria ", Pealinn="Abuja", Elanikkond="206100000" , Pilt="nigeria.png"},
                new Euuropa {Nimetus="Dominica ", Pealinn="Roseau", Elanikkond="72100", Pilt="dominica.png"},
                new Euuropa {Nimetus="Serbia", Pealinn="Male", Elanikkond="540542", Pilt="maldives.png"},
            };
            lbl_list = new Label
            {
                Text = "Euroopa riigid",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            listeu = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = eurupos,
                ItemTemplate = new DataTemplate(() => {
                    ImageCell imageCell = new ImageCell { TextColor = Color.DarkSeaGreen, DetailColor = Color.White, };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "Pealinn on: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            lisaeu = new Button
            {
                Text = "Lisa riik",
                VerticalOptions = LayoutOptions.Center,
            };
            lisaeu.Clicked += Lisaeu_Clicked;
            kustutaeu = new Button
            {
                Text = "Kustuta riik",
                VerticalOptions = LayoutOptions.Center,
            };
            kustutaeu.Clicked += Kustutaeu_Clicked;
            listeu.ItemTapped += Listeu_ItemTapped;
            

            this.Content = new StackLayout { Children = { lbl_list, listeu, lisaeu, kustutaeu} };
            this.BackgroundColor = Color.DimGray;
        }

        private void Kustutaeu_Clicked(object sender, EventArgs e)
        {
            Euuropa euriik = listeu.SelectedItem as Euuropa;
            if (euriik != null)
            {
                eurupos.Remove(euriik);
            }
        }

        private async void Lisaeu_Clicked(object sender, EventArgs e)
        {    
            await Navigation.PushAsync(new Addeu());
        }

        private async void Listeu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Euuropa selectedeu = e.Item as Euuropa;
            if (selectedeu != null)
            {
                await DisplayAlert("Euroopa riigid: ", $"{selectedeu.Nimetus}: {selectedeu.Pealinn} " + "\nElanikkond: " + $"{selectedeu.Elanikkond}", "OK");
            }
        }

    }
}