using Dapper;
using Repository.Contracts;
using Domain.Entities;

namespace Repository.Repositories
{
    public class CorretorRepository: ICorretorRepository
    {
        private readonly IConnectionFactory _conexao;
        public CorretorRepository(IConnectionFactory conexao)
        {
            _conexao = conexao;
        }

        public async Task<IEnumerable<Corretor>?> Consultar()
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.QueryAsync<Corretor>("SELECT * FROM Corretor");
            }
        }

        public async Task<Corretor?> Consultar(int idCorretor)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.QuerySingleOrDefaultAsync<Corretor>(
                    "SELECT * FROM Corretor WHERE idCorretor = @idCorretor",
                    new { idCorretor });
            }
        }

        public async Task<bool> Incluir(Corretor request)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.ExecuteAsync(
                    @"INSERT INTO Corretor
                    (Nome, RG, CPFCNPJ, Nascimento, ComissaoPadrao, Autonomo, Whatsapp)
                    VALUES
                    (@Nome, @RG, @CPFCNPJ, @Nascimento, @ComissaoPadrao, @Autonomo, @Whatsapp)",
                    request) > 0;
            }
        }
    
        public async Task<bool> Alterar(Corretor request)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.ExecuteAsync(
                    @"UPDATE Corretor
                    SET Nome = @Nome,
                    RG = @RG,
                    CPFCNPJ = @CPFCNPJ, 
                    Nascimento = @Nascimento, 
                    ComissaoPadrao = @ComissaoPadrao, 
                    Autonomo = @Autonomo, 
                    Whatsapp = @Whatsapp
                    WHERE idCorretor = @idCorretor",
                    request) > 0;
            }
        }
    
        public async Task<bool> Deletar(int idCorretor)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.ExecuteAsync(
                    @"DELETE 
                    FROM Corretor 
                    WHERE idCorretor = @idCorretor",
                    new { idCorretor }) > 0;
            }
        }
    }
}
