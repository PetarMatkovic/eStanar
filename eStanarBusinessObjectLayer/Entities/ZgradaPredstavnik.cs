using System;

namespace eStanar.Domain.Entities
{
    public class ZgradaPredstavnik
    {
        public int ZgradaPredstavnikId { get; set; }
        public int ZgradaId { get; set; }
        public int OsobaId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }

        public virtual Zgrada Zgrada { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
