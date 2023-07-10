using Domain.Requests;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Service.Services
{
    public class WhatsappService: IWhatsappService
    {
        private readonly IConfiguration _configuration;
        
        public WhatsappService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string MontarJsonMensagem(string numeroDestinatario)
            => JsonSerializer.Serialize( new
                {
                    messaging_product = "whatsapp",
                    to = numeroDestinatario,
                    type = "template",
                    template = new
                    {
                        name = "hello_world",
                        language = new
                        {
                            code = "en_US"
                        }
                    }
                });

        private async Task<bool> EnviarAPI(string json)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("TOKEN_FACEBOOK"));

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(
                    _configuration.GetSection("URLS").GetSection("WHATSAPP").Value,
                    content
                );

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> EnviarMensagem(WhatsappEnviarMensagemRequest request)
        {
            var numerosErro = new List<string>();

            foreach (var destinatario in request.Destinatarios)
            {
                var json = MontarJsonMensagem(destinatario);

                if (!await EnviarAPI(json))
                    numerosErro.Add(destinatario);
            }
            
            if (numerosErro.Count() > 0)
                throw new ApplicationException($"Não foi possível enviar para o(s) número(s): { string.Join(", ", numerosErro) }");

            return true;            
        }
    }
}
