using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Osoba
    {
        public Osoba()
        {
            this.ZgradaPredstavnici = new HashSet<ZgradaPredstavnik>();
        }

        public int OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }

        public virtual Racun Racun { get; set; }
        public virtual Stanar Stanar { get; set; }
        public virtual ICollection<ZgradaPredstavnik> ZgradaPredstavnici { get; set; }
    }
}
