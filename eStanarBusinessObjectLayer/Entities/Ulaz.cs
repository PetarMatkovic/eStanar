using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Ulaz
    {
        public Ulaz()
        {
            this.Stanovi = new HashSet<Stan>();
            this.Obavijesti = new HashSet<Obavijest>();
            this.Dokumenti = new HashSet<Dokument>();
        }

        public int UlazId { get; set; }
        public string KucniBroj { get; set; }
        public int ZgradaId { get; set; }

        public virtual Zgrada Zgrada { get; set; }
        public virtual ICollection<Stan> Stanovi { get; set; }
        public virtual ICollection<Obavijest> Obavijesti { get; set; }
        public virtual ICollection<Dokument> Dokumenti { get; set; }
    }
}
