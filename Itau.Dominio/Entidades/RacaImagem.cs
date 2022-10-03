namespace Itau.Dominio.Entidades
{
    public class RacaImagem
    {
        public int Id { get; set; }
        public int RacaId { get; set; }
        public Raca Raca { get; set; }
        public string ImagemUrl { get; set; }
    }
}
