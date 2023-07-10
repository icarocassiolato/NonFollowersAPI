namespace Domain.Requests
{
    public class WhatsappEnviarMensagemRequest
    {
        public List<string> Destinatarios { get; set; }
        public string Mensagem { get; set; }

        public WhatsappEnviarMensagemRequest(List<string> destinatarios, string mensagem)
        {
            Destinatarios = destinatarios;
            Mensagem = mensagem;
        }
    }
}
