using Domain.Entities;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class CorretorService: ICorretorService
    {
        private readonly ICorretorRepository _repository;

        public CorretorService(ICorretorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Corretor>?> Consultar()
            => await _repository.Consultar();

        public async Task<Corretor?> Consultar(int idCorretor)
            => await _repository.Consultar(idCorretor);

        public async Task<bool> Incluir(Corretor request)
            => await _repository.Incluir(request);
    
        public async Task<bool> Alterar(Corretor request)
            => await _repository.Alterar(request);
    
        public async Task<bool> Deletar(int idCorretor)
            => await _repository.Deletar(idCorretor);
    }
}
