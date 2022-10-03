namespace Itau.Dominio.Entidades
{
    public class Raca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int OrigemId { get; set; }
        public Origem Origem { get; set; }
        public IEnumerable<RacaTemperamento> TemperamentoRaca { get; set; } = new List<RacaTemperamento>();
        public List<RacaImagem> RacaImagens { get; set; } = new List<RacaImagem>();
    }
}
