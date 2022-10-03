namespace Itau.TheCat.Dominio.Entidades
{
    public class RacaImagem
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public int BreedId { get; set; }
        public IEnumerable<Raca> Breeds { get; set; }
    }
}
