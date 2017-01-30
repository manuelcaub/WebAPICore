namespace WebAPICore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebAPICore.Models;
    using WebAPICore.ContextDB.Data;
    using WebAPICore.ContextDB;

    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductRepository _repProduct = new ProductRepository();

        [HttpPost]
        public void Post([FromBody]ProductModel product)
        {
            _repProduct.Create(new Product 
            {
                Name = product.Name,
                Price = product.Price,
                Currency = product.Currency
            });
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_repProduct.ReadAll());
        }
    }
}
