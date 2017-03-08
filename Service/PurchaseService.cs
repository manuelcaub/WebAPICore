namespace WebAPICore.Service
{
    using AutoMapper;
    using Data;
    using Data.Repositories;

    public class PurchaseService : AbstractDbService<Purchase>, IPurchaseService
    {
        IPurchaseRepository _purchaseRepository;
        IMapper _mapper;

        public PurchaseService(IPurchaseRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _purchaseRepository = repository;
            _mapper = mapper;
        }
    }
}