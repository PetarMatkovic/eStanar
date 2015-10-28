using System;

namespace eStanar.Domain.Entities
{
    public class Dokument
    {
        public int DokumentId { get; set; }
        public int ZgradaId { get; set; }
        public Nullable<int> UlazId { get; set; }
        /// <summary>
        /// AutorId
        /// </summary>
        public int OsobaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string DatotekaTip { get; set; }
        public DateTime Datum { get; set; }

        public virtual Zgrada Zgrada { get; set; }
        public virtual Ulaz Ulaz { get; set; }
        public virtual Osoba Autor { get; set; }
    }
}
