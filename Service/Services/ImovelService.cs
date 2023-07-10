using Domain.Entities;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class ImovelService: IImovelService
    {
        private readonly IImovelRepository _repository;

        public ImovelService(IImovelRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Imovel>?> Consultar()
            => await _repository.Consultar();        
    }
}
