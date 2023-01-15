using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Handlers
{
    public interface ICallStoredProcedureHandler
    {
        public Task ExecuteAsync(HttpClient httpClient);
    }

    public class CallStoredProcedureHandler : ICallStoredProcedureHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient)
        {
            await httpClient.PutAsync($"https://localhost:3001/Product/CallStoredProcedure?", null);
        }
    }
}