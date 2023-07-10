using Domain.Entities;

namespace Repository.Contracts
{
    public interface IImovelRepository
    {
        Task<IEnumerable<Imovel>?> Consultar();
    }
}
