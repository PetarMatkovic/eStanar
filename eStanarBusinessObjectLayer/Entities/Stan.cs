using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Stan
    {
        public Stan()
        {
            this.Stanari = new HashSet<Stanar>();
        }

        public int StanId { get; set; }
        public decimal Povrsina { get; set; }
        public string Oznaka { get; set; }
        public int UlazId { get; set; }

        public virtual Ulaz Ulaz { get; set; }
        public virtual ICollection<Stanar> Stanari { get; set; }
    }
}
