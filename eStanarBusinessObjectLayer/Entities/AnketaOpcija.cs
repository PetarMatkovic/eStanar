namespace eStanar.Domain.Entities
{
    public class AnketaOpcija
    {
        public int AnketaOpcijaId { get; set; }
        public int AnketaId { get; set; }
        public string Tekst { get; set; }

        public virtual Anketa Anketa { get; set; }
    }
}
