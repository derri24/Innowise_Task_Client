using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Handlers
{
    public interface ICreateProductsHandler
    {
        public Task ExecuteAsync(HttpClient httpClient, CreateProductsModel createProductsModel);
    }
    public class CreateProductsHandler:ICreateProductsHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient,CreateProductsModel createProductsModel)
        {
            await httpClient.PostAsJsonAsync($"https://localhost:3001/Product/CreateProducts?",createProductsModel);
        }
    }
}