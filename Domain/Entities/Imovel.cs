namespace Domain.Entities
{
    public class Imovel
    {
        public int IdImovel { get; set; }
        public int? CadastroImobiliario { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? CaminhoMatricula { get; set; }
        public string? Endereco { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Complemento { get; set; }
    }
}
