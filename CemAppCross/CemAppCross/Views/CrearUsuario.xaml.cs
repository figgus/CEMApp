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

namespace CemAppCross.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CrearUsuario : ContentPage
	{
		public CrearUsuario ()
		{
			InitializeComponent ();
            Content.BackgroundColor = Color.DarkRed;
            btnGuardarUser.Pressed += BtnGuardarUser_Pressed;
            tipoUsuario.ItemsSource = new string[] { "Administrador", "Usuario" };
        }

        private void BtnGuardarUser_Pressed(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.username = txtUsername.Text;
            user.password = txtpnombre.Text;
            user.pnombre = txtpnombre.Text;
            user.snombre = txtsnombre.Text;
            user.appat = txtappat.Text;
            user.apmat = txtapmat.Text;
            user.email = txtEmail.Text;
            user.fonoCelular = txtCelular.Text;
            user.fonoFijo = txtFonoFijo.Text;
            user.tipoUsuario = 1;
            user.alumnoRegular = 1;

            GuardarUsuario(user);
        }

        private async void GuardarUsuario(Usuario user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json,Encoding.UTF8,"application/json");
            HttpClient client = new HttpClient();
            var response = await client.PostAsync("http://restapicem.somee.com/api/usuarios",content);
            await DisplayAlert("¡Exito!","Usuario registrado con exito","Gracias!");
        }
    }
}