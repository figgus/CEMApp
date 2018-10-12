using CemAppCross.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CemAppCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Notas, Title="Ver Notas" },
                new HomeMenuItem {Id = MenuItemType.Porgramas, Title="Programas de estudio" },
                new HomeMenuItem { Id = MenuItemType.Postulaciones, Title = "Ver Estado Postulacion" },
                new HomeMenuItem { Id = MenuItemType.SeleccionarFamilia, Title = "Seleccionar familia" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected +=  (sender, e) =>
            {
                if (e.SelectedItem == null) //async borrado
                    return;
                
               // Navigation.PushModalAsync(new Notas());
                
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                if (id==3)
                {
                    Navigation.PushModalAsync(new Notas());
                }
                //await RootPage.NavigateFromMenu(id);
            };
        }
    }
}