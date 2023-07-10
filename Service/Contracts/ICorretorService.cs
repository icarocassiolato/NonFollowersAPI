using Domain.Entities;

namespace Service.Contracts
{
    public interface ICorretorService
    {
        Task<IEnumerable<Corretor>?> Consultar();

        Task<Corretor?> Consultar(int idCorretor);

        Task<bool> Incluir(Corretor request);

        Task<bool> Alterar(Corretor request);

        Task<bool> Deletar(int idCorretor);
    }
}
