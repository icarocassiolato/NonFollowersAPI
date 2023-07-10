using Dapper;
using Repository.Contracts;
using Domain.Entities;

namespace Repository.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly IConnectionFactory _conexao;
        public ImovelRepository(IConnectionFactory conexao)
        {
            _conexao = conexao;
        }

        public async Task<IEnumerable<Imovel>?> Consultar()
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.QueryAsync<Imovel>("SELECT * FROM Imovel");
            }
        }
    }
}
