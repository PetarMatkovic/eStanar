namespace eStanar.Domain
{
    public class StanVlasnik
    {
        public int StanVlasnikId { get; set; }
        public int ŞtanId { get; set; }
        public int OsobaId { get; set; }

        public virtual Stan Stan { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
