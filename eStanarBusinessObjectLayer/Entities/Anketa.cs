using System;
using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Anketa
    {
        public Anketa()
        {
            this.AnketaOpcije = new HashSet<AnketaOpcija>();
        }

        public int AnketaId { get; set; }
        public Nullable<int> ObavijestId { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }

        public virtual Obavijest Obavijest { get; set; }
        public virtual ICollection<AnketaOpcija> AnketaOpcije { get; set; }
    }
}
