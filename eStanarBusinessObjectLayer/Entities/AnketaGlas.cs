using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStanar.Domain.Entities
{
    public class AnketaGlas
    {
        public int AnketaOpcijaId { get; set; }
        public int OsobaId { get; set; }

        public virtual AnketaOpcija AnketaOpcija { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
