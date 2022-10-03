namespace Itau.Dominio.Entidades
{
    public class Temperamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<RacaTemperamento> TemperamentoRaca { get; set; } = new List<RacaTemperamento>();
    }
}
