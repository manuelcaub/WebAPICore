namespace WebAPICore.Service
{
    using System.Collections.Generic;

    public interface IDbService
    {
        void Create<TModel>(TModel model);

        IList<TModel> ReadAll<TModel>();

        TModel ReadById<TModel>(ulong id);

        void Update<TModel>(TModel model);

        void Delete<TModel>(TModel model);
    }
}