using System;
using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Obavijest
    {
        public Obavijest()
        {
            this.ObavijestKomentari = new HashSet<ObavijestKomentar>();
        }

        public int ObavijestId { get; set; }
        public int ZgradaId { get; set; }
        public string Tekst { get; set; }
        /// <summary>
        /// AutorId
        /// </summary>
        public int OsobaId { get; set; }
        public DateTime DatumObjave { get; set; }
        public int ObavijestTipId { get; set; }
        public Nullable<int> UlazId { get; set; }
        public Nullable<int> SastanakId { get; set; }

        public virtual Zgrada Zgrada { get; set; }
        public virtual Osoba Autor { get; set; }
        public virtual ObavijestTip ObavijestTip { get; set; }
        public virtual Ulaz Ulaz { get; set; }
        public virtual Sastanak Sastanak { get; set; }
        public virtual ICollection<ObavijestKomentar> ObavijestKomentari { get; set; }
    }
}
