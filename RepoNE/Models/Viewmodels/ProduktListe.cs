using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoNE.Models.Viewmodels
{
    public class ProduktListe
    {
        public Kategori Kategori { get; set; }
        public List<Produkt> listProdukt { get; set; } 
    }
}
