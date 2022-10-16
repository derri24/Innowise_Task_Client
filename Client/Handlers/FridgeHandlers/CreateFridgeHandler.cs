using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Client.FridgeResponses;
using Client.Models;

namespace Client.Handlers
{
    public interface ICreateFridgeHandler
    {
        public Task ExecuteAsync(HttpClient httpClient, CreateFridgeModel createFridgeModel);
    }
    public class CreateFridgeHandler : ICreateFridgeHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient, CreateFridgeModel createFridgeModel)
        {
           await httpClient.PostAsJsonAsync($"https://localhost:3001/Fridge/CreateFridge?",createFridgeModel);
        }
    }
}