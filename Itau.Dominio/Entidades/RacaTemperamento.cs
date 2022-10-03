namespace Itau.Dominio.Entidades
{
    public class RacaTemperamento
    {
        public int RacaId { get; set; }
        public Raca Raca { get; set; }
        public int TemperamentoId { get; set; }
        public Temperamento Temperamento { get; set; }
    }
}
