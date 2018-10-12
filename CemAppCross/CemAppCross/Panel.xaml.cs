using CemAppCross.Clases;
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
        ListView listaElementos;
        public Panel ()
        {
            InitializeComponent();
            listaElementos = this.FindByName<ListView>("listaUsuarios");
            
        }

        private async void TraerDatos()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            string[] nombres = new string[datos.Count];
            for (int i=0;i<nombres.Length;i++)
            {
                nombres[i] = string.Format("{0} {1} {2} {3}",datos[0].pnombre, datos[0].snombre, datos[0].appat, datos[0].apmat);
            }
            listaUsuarios.ItemsSource = nombres;
        }
    }
}