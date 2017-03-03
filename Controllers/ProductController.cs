namespace WebAPICore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebAPICore.Data.Repositories;
    using WebAPICore.Data;

    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repProduct;

        public ProductsController(IProductRepository repProduct)
        {
            _repProduct = repProduct;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _repProduct.Create(product);
            return Created("GetProduct", product);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id)
        {
            return new JsonResult(_repProduct.Read(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_repProduct.ReadAll());
        }

        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            _repProduct.Update(product);
            return new JsonResult(product);
        }
    }
}
