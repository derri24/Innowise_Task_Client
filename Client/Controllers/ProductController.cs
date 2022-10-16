using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Handlers;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        private HttpClient _httpClient;

        private IUpdateProductHandler _updateProductHandler;
        private IDeleteProductHandler _deleteProductHandler;
        private IGetProductsHandler _getProductsHandler;
        private IGetProductByIdHandler _getProductByIdHandler;
        private ICreateProductsHandler _createProductsHandler;

        public ProductController(IUpdateProductHandler updateProductHandler,
            IDeleteProductHandler deleteProductHandler,
            IGetProductsHandler getProductsHandler,
            IGetProductByIdHandler getProductByIdHandler,
            ICreateProductsHandler createProductsHandler)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(clientHandler);

            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
            _getProductsHandler = getProductsHandler;
            _getProductByIdHandler = getProductByIdHandler;
            _createProductsHandler = createProductsHandler;

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int fridgeId, [FromBody] UpdateProductModel updateProductModel)
        {
            await _updateProductHandler.ExecuteAsync(_httpClient, fridgeId,updateProductModel);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatingProduct(int productId,int fridgeId)
        {
            return View((await _getProductByIdHandler.ExecuteAsync(_httpClient, productId,fridgeId)).Model);
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _deleteProductHandler.ExecuteAsync(_httpClient, productId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Products(int fridgeId)
        {
            return View((await _getProductsHandler.ExecuteAsync(_httpClient, fridgeId)).Model);
        }

        public IActionResult Products()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductsModel createProductsModel)
        {
            await _createProductsHandler.ExecuteAsync(_httpClient,createProductsModel);
            return Ok();
            //return View();
        }
        
        public async Task<IActionResult> CreatingProducts(int fridgeId)
        {
            return View();
        }
    }
}