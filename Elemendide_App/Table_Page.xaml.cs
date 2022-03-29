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
        public Table_Page()
        {
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
                    },
                }
            };
            Content = tableview;
        }
    }
}