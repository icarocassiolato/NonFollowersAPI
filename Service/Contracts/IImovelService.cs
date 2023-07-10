using Domain.Entities;

namespace Service.Contracts
{
    public interface IImovelService
    {
        Task<IEnumerable<Imovel>?> Consultar();
    }
}
