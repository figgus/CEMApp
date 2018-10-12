using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CemAppCross.Clases
{
    public class OperacionesUsuarios
    {
        public HttpClient client { get; set; }

        public OperacionesUsuarios()
        {
            client = new HttpClient();
        }

        //public List<Usuario> TraerTodo()
        //{
        //    var response =  client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

        //  //  List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);

        //    return datos;
        //}
    }
}
