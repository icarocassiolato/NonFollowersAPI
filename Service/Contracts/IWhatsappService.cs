using Domain.Requests;

namespace Service.Contracts
{
    public interface IWhatsappService
    {
        Task<bool> EnviarMensagem(WhatsappEnviarMensagemRequest request);
    }
}
