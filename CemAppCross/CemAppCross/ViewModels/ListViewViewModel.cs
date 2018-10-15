using CemAppCross.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace CemAppCross.ViewModels
{
    class ListViewViewModel
    {
        public ObservableCollection<Usuario> PersonList { get; set; }
        public Usuario _selectedUser { get; set; }
        public Usuario selectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser!=value)
                {
                    _selectedUser = value;
                    HandleSelectedItem();
                }
            }
        }
        private void HandleSelectedItem()
        {
            Panel panel = new Panel();
            panel.DisplayAlert("click", "click", "click");
        }

        public ListViewViewModel()
        {
            TraerDatos();

        }


        private async void TraerDatos()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            string[] nombres = new string[datos.Count];
            for (int i = 0; i < nombres.Length; i++)
            {
                PersonList.Add(datos[i]);
            }
        }

    }
}
