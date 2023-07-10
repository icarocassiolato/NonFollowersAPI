namespace Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Login { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }

        public Usuario()
        {

        }

        public Usuario(int IdUsuario, string? Login, string? Nome, string? Senha, string? Email)
        {
            this.IdUsuario = IdUsuario;
            this.Login = Login;
            this.Nome = Nome;
            this.Senha = Senha;
            this.Email = Email;
        }
    }
}
