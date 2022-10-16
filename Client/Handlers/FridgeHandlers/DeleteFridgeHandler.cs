using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Handlers
{
    public interface IDeleteFridgeHandler
    {
        public Task ExecuteAsync(HttpClient httpClient,int fridgeId);
    }
    public class DeleteFridgeHandler:IDeleteFridgeHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient,int fridgeId)
        {
            await httpClient.DeleteAsync($"https://localhost:3001/Fridge/DeleteFridge?fridgeId={fridgeId}");
        }
       
    }
    
}