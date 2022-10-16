using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using Client.ProductResponses;

namespace Client.Handlers
{
    public interface IGetProductByIdHandler
    {
        public Task<UpdateProductResponse> ExecuteAsync(HttpClient httpClient, int productId,int fridgeId);
    }
    public class GetProductByIdHandler:IGetProductByIdHandler
    {
        public async Task<UpdateProductResponse> ExecuteAsync(HttpClient httpClient,int productId,int fridgeId)
        {
            return await httpClient.GetFromJsonAsync<UpdateProductResponse>($"https://localhost:3001/Product/GetProductById?productId={productId}&fridgeId={fridgeId}");
        }
    }
}