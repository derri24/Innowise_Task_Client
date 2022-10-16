using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Handlers
{
    public interface IUpdateFridgeHandler
    {
        public Task ExecuteAsync(HttpClient httpClient, UpdateFridgeModel updateFridgeModel);
    }

    public class UpdateFridgeHandler : IUpdateFridgeHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient, UpdateFridgeModel updateFridgeModel)
        {
            await httpClient.PutAsJsonAsync($"https://localhost:3001/Fridge/UpdateFridge", updateFridgeModel);
        }
    }
    
}