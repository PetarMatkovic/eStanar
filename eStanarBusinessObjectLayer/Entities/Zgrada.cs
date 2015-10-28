using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Zgrada
    {
        public Zgrada()
        {
            this.Ulazi = new HashSet<Ulaz>();
            this.ZgradaPredstavnici = new HashSet<ZgradaPredstavnik>();
            this.Dokumenti = new HashSet<Dokument>();
        }

        public int ZgradaId { get; set; }
        public string Adresa { get; set; }
        public int BrojKatova { get; set; }
        public int BrojStanova { get; set; }
        public int GradId { get; set; }
        public virtual Grad Grad { get; set; }

        public virtual ICollection<Ulaz> Ulazi { get; set; }
        public virtual ICollection<ZgradaPredstavnik> ZgradaPredstavnici { get; set; }
        public virtual ICollection<Dokument> Dokumenti { get; set; }
    }
}
