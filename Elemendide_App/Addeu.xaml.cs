﻿using System;
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
    public partial class Addeu : ContentPage
    {
        TableView tabelview;
        public EntryCell nimieu;
        EntryCell pealinneue;
        EntryCell elanikkondeu;
        EntryCell pilteu;
        Button saveeu;
        Button canceleu;
        
        public string test = "Latvia";

        public Addeu()
        {
            
            nimieu = new EntryCell
            {
                Label = "Riigi nimi:",
                Placeholder = "Sisesta riigi",
                Keyboard = Keyboard.Default
            };
            pealinneue = new EntryCell
            {
                Label = "Pealinna nimi:",
                Placeholder = "Sisesta pealinn",
                Keyboard = Keyboard.Default
            };
            elanikkondeu = new EntryCell
            {
                Label = "Elanikkond",
                Placeholder = "Sisesta elanikkond",
                Keyboard = Keyboard.Numeric
            };
            pilteu = new EntryCell
            {
                Label = "Nimi:",
                Placeholder = "Viide riigi lipule",
                Keyboard = Keyboard.Default
            };
            saveeu = new Button
            {
                Text = "Save",
                BackgroundColor = Color.DarkSeaGreen,
                TextColor = Color.Black
            };
            saveeu.Clicked += Saveeu_Clicked;
            canceleu = new Button
            {
                Text = "Cancel",
                BackgroundColor = Color.DarkSeaGreen,
                TextColor = Color.Black
            };
            canceleu.Clicked += Canceleu_Clicked;
            tabelview = new TableView
            {
                Intent = TableIntent.Form, 
                Root = new TableRoot("Andmete riik")
                {
                    new TableSection("Riik:")
                    {
                        nimieu,
                        pealinneue,
                        elanikkondeu,
                        pilteu,
                    }
                }
            };
            StackLayout vertical = new StackLayout
            {
                Children = { tabelview, saveeu, canceleu },
            };
            Content = vertical;
            this.BackgroundColor = Color.DimGray;
        }
        private async void Saveeu_Clicked(object sender, EventArgs e)
        {

            Europarigid.eurupos.Add(new Euuropa { Nimetus = nimieu.Text, Pealinn = pealinneue.Text, Elanikkond = elanikkondeu.Text, Pilt = pilteu.Text});
            await Navigation.PopAsync();
            
        }

        private async void Canceleu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}