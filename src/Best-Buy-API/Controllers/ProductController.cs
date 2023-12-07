using Best.Buy.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Best.Buy.API.Attributes;
using Best.Buy.DTO;

namespace Best.Buy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : CustomController
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }
        
        [HttpGet]
        [ApiKey]
        public async Task<IActionResult> Get([FromQuery] ProductRequest productRequest)
        {
            try
            {
                var result = await _productService.GetProductsAsync(productRequest);
                return ResponseGet(result);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return ResponseGet(new PagedList<ProductResponse>(null, 0, 0, PageSize.TEN));
            }
        }
    }
}