using CollegeAPI.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CollegeAPI.Controllers.V2
{
    // Aqui tenemos que agregar al version que tenemos que consumir dependiendo de lo qu ha solcidado el cliente.
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")] // tenemos que agregar una version especifica qeu vamos a consumir segunla version
    [ApiController]
    public class UsersControllerV2 : ControllerBase
    {
        // tenemos que gestionar la peticion http de manera asyncrona.
        // Tenemos que realizar una peticion al una api externa, pero en contexto real, esto se gestiona en la base de datos.

        private const string _ApiTestURL = "https://dummyapi.io/data/user?limit=30";
        private const string _AppId = "4928492512-f0s8934"; // este el la key que nos da la api para realizar las peticione.
        private readonly HttpClient _httpClient;

        public UsersControllerV2(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetUsersData")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", _AppId);

            var response = await _httpClient.GetStreamAsync(_ApiTestURL); // hacemos la peticion a la endpoint

            var usersData = await JsonSerializer.DeserializeAsync<User>(response); // tenemos que serailzaer la funcion de respuesta.

            var users = usersData?.data;
            return Ok(usersData);
        }
    }
}
