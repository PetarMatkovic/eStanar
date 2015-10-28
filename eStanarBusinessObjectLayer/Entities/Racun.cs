namespace eStanar.Domain.Entities
{
    public class Racun
    {
        public int RacunId { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int OsobaId { get; set; }

        public virtual Osoba Osoba { get; set; }
    }
}
