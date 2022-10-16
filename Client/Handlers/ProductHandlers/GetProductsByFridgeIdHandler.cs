using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using Client.ProductResponses;

namespace Client.Handlers
{
    public interface IGetProductsHandler
    {
        public Task<ProductsResponse> ExecuteAsync(HttpClient httpClient,int fridgeId);
    }
    public class GetProductsHandler:IGetProductsHandler
    {
        public async Task<ProductsResponse> ExecuteAsync(HttpClient httpClient,int fridgeId)
        {
             return await httpClient.GetFromJsonAsync<ProductsResponse>($"https://localhost:3001/Product/GetProductsByFridgeId?fridgeId={fridgeId}");
        }
    }
}