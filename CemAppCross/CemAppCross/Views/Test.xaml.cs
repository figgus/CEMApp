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
	public partial class Test : ContentPage
	{
        ConexionAPI.ConexionAPINotas apiNotas;

        public Test ()
		{
			InitializeComponent ();
            apiNotas = new ConexionAPI.ConexionAPINotas();
            lblTexto.Text= traer().Result;
		}

        public async Task<string> traer()
        {
            List<Notas> notas= apiNotas.TraerNotas().Result;
            return notas[0].calificacion.ToString();
        }
	}
}