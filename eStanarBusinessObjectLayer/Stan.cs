using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStanarBusinessObjectLayer
{
    public class Stan
    {
        public int StanId { get; set; }
        public int ZgradaId { get; set; }
        public decimal Povrsina { get; set; }
        public string Oznaka { get; set; }
    }
}
