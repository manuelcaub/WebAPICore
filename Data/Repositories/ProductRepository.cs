namespace WebAPICore.Data.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using System;

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

        public Product Read(ulong id)
        {
            return _dataContext.Products.Find(id);
        }

        public void Update(Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            if(product != null)
            {
                _dataContext.Products.Remove(product);
                _dataContext.SaveChanges();
            }
        }

        public IList<TResult> ReadAll<TResult>(Func<Product, TResult> map)
        {
            return _dataContext.Products.Select(map).ToList();
        }

        public IList<TResult> ReadByPredicate<TResult>(Func<Product, bool> predicate, Func<Product, TResult> map)
        {
            return _dataContext.Products.Where(predicate).Select(map).ToList();
        }
    }
}