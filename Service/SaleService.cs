namespace WebAPICore.Service
{
    using AutoMapper;
    using Data;
    using Data.Repositories;

    public class SaleService : AbstractDbService<Sale>, ISaleService
    {
        ISaleRepository _saleRepository;
        IMapper _mapper;

        public SaleService(ISaleRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _saleRepository = repository;
            _mapper = mapper;
        }
    }
}