using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Handlers
{
    public interface IUpdateProductHandler
    {
        public Task ExecuteAsync(HttpClient httpClient, int fridgeId,UpdateProductModel updateProductModel);
    }
    public class UpdateProductHandler : IUpdateProductHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient, int fridgeId,UpdateProductModel updateProductModel)
        {
            await httpClient.PutAsJsonAsync($"https://localhost:3001/Product/UpdateProduct?fridgeId={fridgeId}", updateProductModel);
        }
    }
}