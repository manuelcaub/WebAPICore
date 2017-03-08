namespace WebAPICore.Data.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        IList<TEntity> ReadAll();

        IList<TResult> ReadAll<TResult>(Func<TEntity, TResult> map);

        IList<TResult> ReadByPredicate<TResult>(Func<TEntity, bool> predicate, Func<TEntity, TResult> map);

        TEntity Read(ulong id);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}