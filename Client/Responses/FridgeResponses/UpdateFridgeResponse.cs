using Client.Models;

namespace Client.FridgeResponses
{
    public class UpdateFridgeResponse
    {
        public UpdateFridgeModel Model { get; set; }
        public StatusResponse StatusResponse { get; set; }
    }
}