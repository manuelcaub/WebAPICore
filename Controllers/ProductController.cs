namespace WebAPICore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Service;

    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _serviceProduct;

        public ProductsController(IProductService serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductModel product)
        {
            _serviceProduct.Create(product);
            return Created("GetProduct", product);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(ulong id)
        {
            return new JsonResult(_serviceProduct.ReadById<ProductModel>(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_serviceProduct.ReadAll<ProductModel>());
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProductModel product)
        {
            _serviceProduct.Update(product);
            return new JsonResult(product);
        }
    }
}
