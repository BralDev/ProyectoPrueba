using EsquemaMAUI.Esquemas;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Reflection;

namespace AppProductos.Servicios
{
    public class ProductoServicio
    {
        private readonly HttpClient loHttpCli;
        private readonly string lcUrlAPI = "http://localhost/WAProductos/api/";

        public ProductoServicio()
        {
            loHttpCli = new HttpClient();                        
        }

        // GET api/productos
        public async Task<ProductosListRPT> amObtenerProductos()
        {
            try
            {
                String varUrl = lcUrlAPI + "obtenerProductos";
                ProductosListRPT? loRPT = await loHttpCli.GetFromJsonAsync<ProductosListRPT>(varUrl);
                return loRPT ?? new ProductosListRPT { pnCodigo = 500, pcMensaje = "No se obtuvo respuesta." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                return new ProductosListRPT { pnCodigo = 500, pcMensaje = ex.Message };
            }
        }

        // POST api/productos
        public async Task<ProductoCrearRPT> amCrearProducto(ProductoCrearRQT toProCreRQT)
        {
            try
            {
                HttpResponseMessage loResponse = await loHttpCli.PostAsJsonAsync(lcUrlAPI, toProCreRQT);
                ProductoCrearRPT? loRPT = await loResponse.Content.ReadFromJsonAsync<ProductoCrearRPT>();
                return loRPT ?? new ProductoCrearRPT { pnCodigo = 500, pcMensaje = "No se obtuvo respuesta." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                return new ProductoCrearRPT { pnCodigo = 500, pcMensaje = ex.Message };
            }
        }

        // PUT api/productos
        public async Task<ProductoActualizarRPT> amActualizarProducto(ProductoActualizarRQT toProActRQT)
        {
            try
            {
                HttpResponseMessage loResponse = await loHttpCli.PutAsJsonAsync(lcUrlAPI, toProActRQT);
                ProductoActualizarRPT? loRPT = await loResponse.Content.ReadFromJsonAsync<ProductoActualizarRPT>();
                return loRPT ?? new ProductoActualizarRPT { pnCodigo = 500, pcMensaje = "No se obtuvo respuesta." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar producto: {ex.Message}");
                return new ProductoActualizarRPT { pnCodigo = 500, pcMensaje = ex.Message };
            }
        }

        // DELETE api/productos
        public async Task<ProductoEliminarRPT> amEliminarProducto(ProductoEliminarRQT toProEliRQT)
        {
            try
            {
                HttpRequestMessage loRequest = new HttpRequestMessage(HttpMethod.Delete, lcUrlAPI)
                {
                    Content = JsonContent.Create(toProEliRQT)
                };
                HttpResponseMessage loResponse = await loHttpCli.SendAsync(loRequest);
                ProductoEliminarRPT? loRPT = await loResponse.Content.ReadFromJsonAsync<ProductoEliminarRPT>();
                return loRPT ?? new ProductoEliminarRPT { pnCodigo = 500, pcMensaje = "No se obtuvo respuesta." };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
                return new ProductoEliminarRPT { pnCodigo = 500, pcMensaje = ex.Message };
            }
        }
    }
}