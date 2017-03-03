namespace WebAPICore.Data.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    public class ProductRepository : IProductRepository
    {
        DataBaseContext _dataContext;

        public ProductRepository(DataBaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public IList<Product> ReadAll()
        {
            return _dataContext.Products.ToList();
        }

        public Product Read(int id)
        {
            return _dataContext.Products.Find(id);
        }

        public void Update(Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = _dataContext.Products.FirstOrDefault(productDB => productDB.Id == id);
            if(product != null)
            {
                _dataContext.Products.Remove(product);
                _dataContext.SaveChanges();
            }
        }
    }
}