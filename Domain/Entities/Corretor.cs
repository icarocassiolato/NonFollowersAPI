namespace Domain.Entities
{
    public class Corretor
    {
        public int IdCorretor { get; set; }
        public string? Nome { get; set; }
        public string? RG { get; set; }
        public string? CPFCNPJ { get; set; }
        public DateTime? Nascimento { get; set; }
        public decimal? ComissaoPadrao { get; set; }
        public bool? Autonomo { get; set; }
        public string? Whatsapp { get; set; }

        public Corretor(int IdCorretor, string? Nome, string? RG, string? CPFCNPJ, DateTime? Nascimento, decimal? ComissaoPadrao, bool? Autonomo, string? Whatsapp)
        {
            this.IdCorretor = IdCorretor;
            this.Nome = Nome;
            this.RG = RG;
            this.CPFCNPJ = CPFCNPJ;
            this.Nascimento = Nascimento;
            this.ComissaoPadrao = ComissaoPadrao;
            this.Autonomo = Autonomo;
            this.Whatsapp = Whatsapp;
        }
    }
}
