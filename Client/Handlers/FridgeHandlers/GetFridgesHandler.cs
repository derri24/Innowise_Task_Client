using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.FridgeResponses;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Handlers
{
    public interface IGetFridgesHandler
    {
        public Task<FridgesResponse> ExecuteAsync(HttpClient httpClient);
    }

    public class GetFridgesHandler : IGetFridgesHandler
    {
        public async Task<FridgesResponse> ExecuteAsync(HttpClient httpClient)
        {
            return await httpClient.GetFromJsonAsync<FridgesResponse>("https://localhost:3001/Fridge/GetFridges?");
        }
    }
}