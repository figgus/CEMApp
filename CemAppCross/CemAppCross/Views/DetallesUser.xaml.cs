using CemAppCross.Clases;
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

namespace CemAppCross.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallesUser : ContentPage
	{
        private Usuario userUpdate;

        public DetallesUser(Usuario user)
        {
            string tipo;
            InitializeComponent();
            userUpdate = user;
            txtIdUsuario.Text=user.idUsuario.ToString();
            txtUsername.Text = user.username;
            txtPassword.Text = user.password;
            txtpnombre.Text = user.pnombre;
            txtsnombre.Text = user.snombre;
            txtappat.Text = user.appat;
            txtapmat.Text = user.apmat;
            txtEmail.Text = user.email;
            txtCelular.Text = user.fonoCelular;
            txtFonoFijo.Text = user.fonoFijo;
            switch (tipoUsuario.SelectedItem)
            {
                case 1:
                    tipo = "Administrador";
                    break;
                case 2:
                    tipo = "Usuario";
                    break;
            }
            
            user.tipoUsuario = 1;
            user.alumnoRegular = 1;


            tipoUsuario.ItemsSource = new string[] { "Administrador", "usuario" };
            btnEditar.Pressed += BtnEditar_Pressed;
            btnEliminar.Pressed += BtnEliminar_Pressed;
		}

        private void BtnEliminar_Pressed(object sender, EventArgs e)
        {
            Borrar();
        }

        private void BtnEditar_Pressed(object sender, EventArgs e)
        {
            userUpdate.idUsuario = int.Parse(txtIdUsuario.Text);
            userUpdate.username = txtUsername.Text;
            userUpdate.password = txtPassword.Text;
            userUpdate.pnombre = txtpnombre.Text;
            userUpdate.snombre = txtsnombre.Text;
            userUpdate.appat = txtappat.Text;
            userUpdate.apmat = txtapmat.Text;
            userUpdate.email = txtEmail.Text;
            userUpdate.fonoCelular = txtCelular.Text;
            userUpdate.fonoFijo = txtFonoFijo.Text;
            userUpdate.alumnoRegular = 1;
            userUpdate.idInstitucion = 1;
            userUpdate.idCarrera = 1;
            Actualizar();
        }

        private async void Actualizar()
        {
            var json = JsonConvert.SerializeObject(userUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            string urlServicio= string.Concat("http://restapicem.somee.com/api/usuarios/", userUpdate.idUsuario);
            var response = await client.PutAsync(string.Concat("http://restapicem.somee.com/api/usuarios/",userUpdate.idUsuario),content);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Exito","Datos actualizados con exito","Ok");
            }
            else
            {
                await DisplayAlert("Error", "Algo salio mal", "Ok");
            }
            
        }


        private async void Borrar()
        {
            var json = JsonConvert.SerializeObject(userUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(string.Concat("http://restapicem.somee.com/api/usuarios/", userUpdate.idUsuario));
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Exito", "Datos actualizados con exito", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Algo salio mal", "Ok");
            }

        }




    }
}