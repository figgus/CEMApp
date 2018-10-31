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
	public partial class DetallesNota : ContentPage
	{
        Notas NotaParam;
		public DetallesNota (Notas nota)
		{
			InitializeComponent();
            NotaParam = nota;
            txtIdNota.Text = NotaParam.idNota.ToString();
            txtCalificacion.Text = NotaParam.calificacion.ToString();
            DateTime dt;
            if (DateTime.TryParse(NotaParam.fecha.ToString(),out dt))
            {
                txtFecha.Date = dt;
            }
            txtNumeral.Text = NotaParam.numeral.ToString();
            txtUsuario.Text = NotaParam.idUsuarioFK.ToString();
            txtProgramaEstudio.Text = NotaParam.idProgramaEstudiosFK.ToString();
            btnEliminar.Pressed += BtnEliminar_Pressed; btnEditar.Pressed += BtnEditar_Pressed;
		}

        private void BtnEditar_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void BtnEliminar_Pressed(object sender, EventArgs e)
        {
            ConexionAPI.ConexionAPINotas api = new ConexionAPI.ConexionAPINotas();
            if (NotaParam == null)
            {
                await DisplayAlert("Error", "Nota esta vacio", "Ok");
            }
            else
            {
                await api.Eliminar(NotaParam);
                await DisplayAlert("Exito", "Registro borrado con exito", "Ok");
            }
        }
    }
}