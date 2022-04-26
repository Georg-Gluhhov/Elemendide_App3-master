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
    public partial class Table_Page : ContentPage
    {
        TableView tableview;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        public Table_Page()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("cat.jpg"),
                Text = "Foto Nimetus",
                Detail = "Foto kirjeldus"
            };
            fotosection = new TableSection();
            tableview = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("andmete sisestamine")
                {
                    new TableSection("Pohiandmed:")
                    {
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Sisesta oma sobra nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontakt")
                    {
                        new EntryCell
                        {
                            Label="Telefon",
                            Placeholder="sisesta tel.",
                            Keyboard=Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label="Email",
                            Placeholder="sisesta email",
                            Keyboard=Keyboard.Email
                        },
                        sc
                    },
                    fotosection
                }
            };
            Content = tableview;
        }
        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto:";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }
        }
    }
}