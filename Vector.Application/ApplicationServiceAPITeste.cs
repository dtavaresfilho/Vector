using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Vector.Application.Dtos;
using Vector.Application.Interfaces;

namespace Vector.Application
{
    public class ApplicationServiceAPITeste : IApplicationServiceAPITeste
    {
        private RestClient client;
        public ApplicationServiceAPITeste()
        {
            client = new RestClient("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
        }
        public virtual IEnumerable<UsuarioDto> GetUsuarios()
        {
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioDto>>(response.Content);

            return listaUsuarios;
        }
    }
}
