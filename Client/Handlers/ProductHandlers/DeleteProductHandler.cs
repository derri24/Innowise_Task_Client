using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Handlers
{
    public interface IDeleteProductHandler
    {
        public Task ExecuteAsync(HttpClient httpClient, int productId);
    }

    public class DeleteProductHandler : IDeleteProductHandler
    {
        public async Task ExecuteAsync(HttpClient httpClient, int productId)
        {
            await httpClient.DeleteAsync($"https://localhost:3001/Product/DeleteProduct?productId={productId}");
        }
    }
}