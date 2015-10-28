namespace eStanar.Domain.Entities
{
    public class Stanar
    {
        public int StanarId { get; set; }
        public int StanId { get; set; }
        public int OsobaId { get; set; }

        public virtual Stan Stan { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
