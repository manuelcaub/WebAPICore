namespace WebAPICore.Service
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Repositories;

    public abstract class AbstractDbService<TEntity> : IDbService
    {
        IRepository<TEntity> _repository;
        IMapper _mapper;

        public AbstractDbService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual void Create<TModel>(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Create(entity);
        }

        public virtual IList<TModel> ReadAll<TModel>()
        {
            return _repository.ReadAll<TModel>(entity => _mapper.Map<TModel>(entity));
        }

        public virtual TModel ReadById<TModel>(ulong id)
        {
            return _mapper.Map<TModel>(_repository.Read(id));
        }

        public virtual void Update<TModel>(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Update(entity);
        }

        public virtual void Delete<TModel>(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Delete(entity);
        }
    }
}