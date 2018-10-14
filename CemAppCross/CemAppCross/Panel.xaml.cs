using CemAppCross.Clases;
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
            var clickeado = (Button)e.SelectedItem;
            DisplayAlert("asd",clickeado.Text,"asd");
        }

        private void CrearUser_Pressed(object sender, EventArgs e)
        {
            
            Navigation.PushModalAsync(new CrearUsuario());
        }

        private async void TraerDatos()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            string[] nombres = new string[datos.Count];
            for (int i=0;i<nombres.Length;i++)
            {
                nombres[i] = string.Format("{0} {1} {2} {3}",datos[i].pnombre, datos[i].snombre, datos[i].appat, datos[i].apmat);
            }
            listaUsuarios.ItemsSource = nombres;
        }
    }
}