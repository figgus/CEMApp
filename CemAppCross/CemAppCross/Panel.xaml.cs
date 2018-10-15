using CemAppCross.Clases;
using CemAppCross.ViewModels;
using CemAppCross.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CemAppCross
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Panel : TabbedPage
    {
        Button CrearUser;
        List<Usuario> listaUsuariosPasar;
        public Panel ()
        {
            InitializeComponent();
            CrearUser = this.FindByName<Button>("btnCrearUser");
            TraerDatos();
            CrearUser.Pressed += CrearUser_Pressed;
            listaUsuarios.ItemSelected += ListaUsuarios_ItemSelected;
        }

       

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (listaUsuariosPasar==null)
            {
                DisplayAlert("Error","Lista vacia","Ok");
            }
            else
            {
                int SelectedId = int.Parse( e.SelectedItem.ToString()[0].ToString());
                var user = listaUsuariosPasar.Where(p=>p.idUsuario==SelectedId);
                Navigation.PushModalAsync(new DetallesUser(user.ToList<Usuario>()[0]));
            }
            
        }

        private void CrearUser_Pressed(object sender, EventArgs e)
        {
            
            Navigation.PushModalAsync(new CrearUsuario(),true);
        }

        private async void TraerDatos()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            string[] nombres = new string[datos.Count];
            listaUsuariosPasar = datos;
            for (int i=0;i<nombres.Length;i++)
            {
                nombres[i] = string.Format("{0}- {1} {2} {3}  {4}",datos[i].idUsuario ,datos[i].pnombre, datos[i].snombre, datos[i].appat, datos[i].apmat);
            }
            listaUsuarios.ItemsSource = nombres;
        }
    }
}