using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoNE
{
    public class Produkt
    {
        public int ID { get; set; }
        public int KatID { get; set; }
        public string Navn { get; set; }
        public int Varenummer { get; set; }
        public decimal Pris { get; set; }
        public decimal Tilbudspris { get; set; }
        public string Leveringstid { get; set; }
        public int Lagerantal { get; set; }
        public string Billede { get; set; }
    }
}
