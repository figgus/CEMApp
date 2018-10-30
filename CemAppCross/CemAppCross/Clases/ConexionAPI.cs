using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CemAppCross.Clases
{
    public class ConexionAPI
    {




        public class ConexionAPINotas
        {

            public ConexionAPINotas()
            {



            }

            public async Task<List<Notas>> TraerNotas()
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://restapicem.somee.com/api/notas");

                List<Notas> datos = JsonConvert.DeserializeObject<List<Notas>>(response);
                Debug.WriteLine(datos);
                return datos;
            }

            public async Task<bool> Eliminar(Notas notaBorrar)
            {
                var json = JsonConvert.SerializeObject(notaBorrar);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var response = await client.DeleteAsync(string.Concat("http://restapicem.somee.com/api/notas/", notaBorrar.idNota));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public async Task<bool> Insertar(Notas nota)
            {
                var json = JsonConvert.SerializeObject(nota);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var response = await client.PostAsync("http://restapicem.somee.com/api/notas", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
    }
}
