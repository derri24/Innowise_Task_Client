using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Client.FridgeResponses;
using Client.Handlers;

namespace Client.Controllers
{
    public class FridgeController : Controller
    {
        private HttpClient _httpClient;

        private ICreateFridgeHandler _createFridgeHandler;
        private IUpdateFridgeHandler _updateFridgeHandler;
        private IDeleteFridgeHandler _deleteFridgeHandler;
        private IGetFridgesHandler _getFridgesHandler;
        private IGetFridgeByIdHandler _getFridgeByIdHandler;

        public FridgeController(ICreateFridgeHandler createFridgeHandler,
            IUpdateFridgeHandler updateFridgeHandler,
            IDeleteFridgeHandler deleteFridgeHandler,
            IGetFridgesHandler getFridgesHandler,
            IGetFridgeByIdHandler getFridgeByIdHandler)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(clientHandler);

            _createFridgeHandler = createFridgeHandler;
            _updateFridgeHandler = updateFridgeHandler;
            _deleteFridgeHandler = deleteFridgeHandler;
            _getFridgesHandler = getFridgesHandler;
            _getFridgeByIdHandler = getFridgeByIdHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFridge([FromBody] CreateFridgeModel createFridgeModel)
        {
            await _createFridgeHandler.ExecuteAsync(_httpClient, createFridgeModel);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFridge([FromBody] UpdateFridgeModel updateFridgeModel)
        {
            await _updateFridgeHandler.ExecuteAsync(_httpClient, updateFridgeModel);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFridge(int fridgeId)
        {
            await _deleteFridgeHandler.ExecuteAsync(_httpClient, fridgeId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatingFridge(int fridgeId)
        {
            return View((await _getFridgeByIdHandler.ExecuteAsync(_httpClient, fridgeId)).Model);
        }

        [HttpGet]
        public async Task<IActionResult> Fridges()
        {
            
            return View((await _getFridgesHandler.ExecuteAsync(_httpClient)).Model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatingFridge()
        {
            return View();
        }
    }
}