using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.FridgeResponses;
using Client.Models;

namespace Client.Handlers
{
    public interface IGetFridgeByIdHandler
    {
        public Task<UpdateFridgeResponse> ExecuteAsync(HttpClient httpClient, int fridgeId);
    }

    public class GetFridgeByIdHandler : IGetFridgeByIdHandler
    {
        public async Task<UpdateFridgeResponse> ExecuteAsync(HttpClient httpClient, int fridgeId)
        {
            return await httpClient.GetFromJsonAsync<UpdateFridgeResponse>(
                $"https://localhost:3001/Fridge/GetFridgeById?fridgeId={fridgeId}");
        }
    }
}