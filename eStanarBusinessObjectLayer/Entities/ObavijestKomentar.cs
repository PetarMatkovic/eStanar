using System;
using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class ObavijestKomentar
    {
        public int ObavijestKomentarId { get; set; }
        public int ObavijestId { get; set; }
        /// <summary>
        /// AutorId
        /// </summary>
        public int OsobaId { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public virtual Obavijest Obavijest { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
