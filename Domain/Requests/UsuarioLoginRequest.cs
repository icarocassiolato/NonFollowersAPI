namespace Domain.Requests
{
    public class UsuarioLoginRequest
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public UsuarioLoginRequest(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
    }
}
