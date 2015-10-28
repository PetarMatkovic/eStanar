using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class Grad
    {
        public Grad()
        {
            this.Zgrade = new HashSet<Zgrada>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Zgrada> Zgrade { get; set; }
    }
}
