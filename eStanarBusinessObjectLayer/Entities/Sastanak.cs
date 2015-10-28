using System;
using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Sastanak
    {
        public Sastanak()
        {
            this.Obavijesti = new HashSet<Obavijest>();
        }

        public int SastanakId { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumSastanka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Prioritet { get; set; }

        public virtual ICollection<Obavijest> Obavijesti { get; set; }
    }
}
