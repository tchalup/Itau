namespace Itau.TheCat.Dominio.Entidades
{
    public class Raca
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country_code { get; set; }
        public string Origin { get; set; }
        public string Temperament { get; set; }

        public IEnumerable<string> Temperaments { get { return Temperament.Split(",", StringSplitOptions.TrimEntries); } }
    }
}
