using System.Collections.Generic;

namespace eStanar.Domain.Entities
{
    public class ObavijestTip
    {
        public ObavijestTip()
        {
            this.Obavijesti = new HashSet<Obavijest>();
        }

        public int ObavijestTipId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Obavijest> Obavijesti { get; set; }
    }
}
