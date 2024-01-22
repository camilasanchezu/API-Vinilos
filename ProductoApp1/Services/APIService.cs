using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductoApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp1.Services
{
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;

        public APIService()
        {

            _baseUrl = "https://apiproductos20240122075316.azurewebsites.net/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }


        public async Task<bool> DeleteTarea(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync($"/api/Tarea/{IdProducto}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            var response = await _httpClient.GetAsync($"/api/Tarea/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return new Producto();
        }

        public async Task<List<Producto>> GetProductos()
        {
            var response = await _httpClient.GetAsync("/api/Tarea");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return new List<Producto>();

        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Tarea/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public async Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Tarea/{IdProducto}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }
    }
}
