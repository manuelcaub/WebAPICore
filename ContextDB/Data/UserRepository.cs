namespace WebAPICore.ContextDB.Data
{
    using System.Linq;
    using System.Collections.Generic;

    public class ProductRepository
    {
        public void Create(Product product)
        {
            using (var dataContext = new DataBaseContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    dataContext.Products.Add(product);
                    dataContext.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        public IList<Product> ReadAll()
        {
            using (var dataContext = new DataBaseContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    return dataContext.Products.ToList();
                }
            }
        }

        public Product Read(int id)
        {
            using (var dataContext = new DataBaseContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    return dataContext.Products.Find(id);
                }
            }
        }

        public void Update(Product product)
        {
            using (var dataContext = new DataBaseContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    Product productDb = dataContext.Products.Find(product.Id);
                    if (productDb != null)
                    {
                        productDb.Name = productDb.Name;
                        productDb.Price = productDb.Price;
                        productDb.Currency = productDb.Currency;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var dataContext = new DataBaseContext())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    Product product = dataContext.Products.Find(id);
                    if(product != null)
                    {
                        dataContext.Products.Remove(product);
                        dataContext.SaveChanges();
                        transaction.Commit();
                    }
                }
            }
        }
    }
}