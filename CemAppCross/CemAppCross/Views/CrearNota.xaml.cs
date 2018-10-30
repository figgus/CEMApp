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
	public partial class CrearNota : ContentPage
	{
		public CrearNota ()
		{
			InitializeComponent ();
            btnCrear.Pressed += BtnCrear_Pressed;
		}

        private async void BtnCrear_Pressed(object sender, EventArgs e)
        {
            Notas notaInsertar = new Notas() ;
            notaInsertar.calificacion =double.Parse(txtCalificacion.Text);
            notaInsertar.fecha = txtFecha.Date;
            notaInsertar.idProgramaEstudiosFK = int.Parse(txtProgramaEstudio.Text);
            notaInsertar.idUsuarioFK = int.Parse(txtUsuario.Text);
            ConexionAPI.ConexionAPINotas notas = new ConexionAPI.ConexionAPINotas();
            await notas.Insertar(notaInsertar);
            
            
            await DisplayAlert("¡Exito!", "registrado con exito", "Ok!");
            await Navigation.PushModalAsync(new Panel());
            
        }
    }
}