using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoNE
{
    public class Kontakt
    {
        public int ID { get; set; }
        public string Overskrift { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public int Tlf { get; set; }
        public int Fax { get; set; }
        public string Email { get; set; }
        public string HjemmesideLink { get; set; }
        public string Aabningstider { get; set; }
        public string ByNavn { get; set; }
    }
}
