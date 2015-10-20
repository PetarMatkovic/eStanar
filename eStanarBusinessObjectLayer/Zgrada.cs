using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStanarBusinessObjectLayer
{
    public class Zgrada
    {
        public int ZgradaId { get; set; }
        public int GradId { get; set; }
        public string GradNaziv { get; set; }
        public string Adresa { get; set; }
        public int BrojKatova { get; set; }
        public int BrojStanova { get; set; }
    }
}
