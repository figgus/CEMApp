using CemAppCross.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CemAppCross.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallesUser : ContentPage
	{
        public DetallesUser(Usuario user)
        {
            string tipo;
            InitializeComponent();
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
            //tipoUsuario. = tipo;
            string regular = "";
            try
            {
                if (int.Parse(txtalumnoRegular.Text) == 1)
                {
                    regular = "Regular";
                }
                else
                {
                    regular = "No regular";
                }
            }
            catch (Exception)
            {

            }
            txtalumnoRegular.Text = regular;

		}


	}
}