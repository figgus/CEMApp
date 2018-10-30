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
	public partial class Login : ContentPage
	{
        Button Ingresar;
        
		public Login ()
		{
			InitializeComponent();
            try
            {
                
                if (App.Current.Properties["Logeado"].ToString() == "true")
                {
                    Navigation.PushModalAsync(new Panel());
                }
            }
            catch (Exception e)
            {
                DisplayAlert("asd", "No funciono", "ok");
            }
            Ingresar = this.FindByName<Button>("btnIngresar");
            Ingresar.Pressed += Ingresar_Pressed;
            
		}

        private void Ingresar_Pressed(object sender, EventArgs e)
        {
            Loguear();
        }


        private async void Loguear()
        {
            HttpClient client=new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            string usu = txtusername.Text;
            string pass = txtpassword.Text;
            bool res = false;
            foreach (Usuario user in datos)
            {
                if (user.username == usu && user.password == pass)
                {
                    res = true;
                }
            }
            
            if (res)
            {
                App.Current.Properties.Add("Logeado", "true");
                await App.Current.SavePropertiesAsync();
                await Navigation.PushModalAsync(new Panel());
            }
            else
            {
                await DisplayAlert("Error", "Credenciales no validas", "Entendido");
            }

        }

    }
}