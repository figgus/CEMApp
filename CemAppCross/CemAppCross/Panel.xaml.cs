using CemAppCross.Clases;
using CemAppCross.ViewModels;
using CemAppCross.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<Notas> listaNotasPasar;
        public Panel ()
        {
            InitializeComponent();
            CrearUser = this.FindByName<Button>("btnCrearUser");
            TraerDatos();
            CrearUser.Pressed += CrearUser_Pressed;
            listaUsuarios.ItemSelected += ListaUsuarios_ItemSelected;
            listaNotas.ItemSelected += ListaNotas_ItemSelected;
            btnAgregarNota.Pressed += BtnAgregarNota_Pressed;
            btnCerrarSesion.Pressed += BtnCerrarSesion_Pressed;
        }

        private void BtnCerrarSesion_Pressed(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.SavePropertiesAsync();
            Navigation.PushModalAsync(new Login());
        }

        private void BtnAgregarNota_Pressed(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new CrearNota());
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listaNotasPasar == null)
            {
                DisplayAlert("Error", "Lista notas vacia", "Ok");
            }
            else
            {
                int SelectedId = int.Parse(e.SelectedItem.ToString()[0].ToString());
                var user = listaNotasPasar.Where(p => p.idNota == SelectedId);
                Navigation.PushModalAsync(new DetallesNota(user.ToList<Notas>()[0]));
            }
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (listaUsuariosPasar==null)
            {
                DisplayAlert("Error","Lista usuarios vacia","Ok");
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

            HttpClient cliente = new HttpClient();
            var resp = await client.GetStringAsync("http://restapicem.somee.com/api/notas");

            List<Notas> datos = JsonConvert.DeserializeObject<List<Notas>>(resp);
            listaNotasPasar = datos;
            string[] arregloNotas = new string[datos.Count];
            for (int i = 0; i < datos.Count; i++)
            {
                arregloNotas[i] = string.Format("{0}- {1}", datos[i].idNota, datos[i].calificacion);
            }
            List<Usuario> datosUser = JsonConvert.DeserializeObject<List<Usuario>>(response);
            string[] nombres = new string[datosUser.Count];
            listaUsuariosPasar = datosUser;
            for (int i=0;i<nombres.Length;i++)
            {
                nombres[i] = string.Format("{0}- {1} {2} {3}  {4}", datosUser[i].idUsuario , datosUser[i].pnombre, datosUser[i].snombre, datosUser[i].appat, datosUser[i].apmat);
            }
            listaUsuarios.ItemsSource = nombres;
            listaNotas.ItemsSource = arregloNotas;
        }
    }
}