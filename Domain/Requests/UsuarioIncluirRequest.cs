using Domain.Entities;

namespace Domain.Requests
{
    public class UsuarioIncluirRequest: Usuario
    {
        public string? SenhaConfirmacao { get; set; }
    }
}
