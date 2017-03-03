namespace WebAPICore.Data.Repositories
{
    using System.Collections.Generic;

    public interface IRepository<TModel>
    {
        void Create(TModel model);

        IList<TModel> ReadAll();

        TModel Read(int id);

        void Update(TModel product);

        void Delete(int id);
    }
}