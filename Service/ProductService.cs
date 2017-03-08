namespace WebAPICore.Service
{
    using AutoMapper;
    using Data;
    using Data.Repositories;

    public class ProductService : AbstractDbService<Product>, IProductService
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }
    }
}