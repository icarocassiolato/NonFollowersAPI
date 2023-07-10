using Dapper;
using Repository.Contracts;
using Domain.Entities;
using Domain.Requests;

namespace Repository.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly IConnectionFactory _conexao;
        public UsuarioRepository(IConnectionFactory conexao)
        {
            _conexao = conexao;
        }

        public async Task<Usuario?> Consultar(int idUsuario)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.QuerySingleOrDefaultAsync<Usuario?>(
                    "SELECT * FROM Usuario WHERE idUsuario = @idUsuario",
                    new { idUsuario });
            }
        }

        public async Task<bool> Incluir(UsuarioIncluirRequest request)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.ExecuteAsync(
                    @"INSERT INTO Usuario
                    (Login, Nome, Senha, Email)
                    VALUES
                    (@Login, @Nome, @Senha, @Email)",
                    request) > 0;
            }
        }
    
        public async Task<bool> Alterar(Usuario request)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.ExecuteAsync(
                    @"UPDATE Usuario
                    SET Login = @Login,
                    Nome = @Nome,
                    Senha = @Senha,
                    Email = @Email
                    WHERE idUsuario = @idUsuario",
                    request) > 0;
            }
        }
    
        public async Task<bool> Deletar(int idUsuario)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.ExecuteAsync(
                    @"DELETE 
                    FROM Usuario 
                    WHERE idUsuario = @idUsuario",
                    new { idUsuario }) > 0;
            }
        }

        public async Task<bool> Login(UsuarioLoginRequest request)
        {
            using (var connectionDb = _conexao.Connection())
            {
                connectionDb.Open();
                return await connectionDb.QueryFirstOrDefaultAsync(
                    "SELECT * FROM Usuario WHERE Login = @login and Senha = @Senha",
                    request) != null;
            }
        }
    }
}
