using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoNE.Factories;
using RepoNE.Models.Viewmodels;

namespace RepoNE
{
    public class ProduktFac : AutoFac<Produkt>
    {
        KategoriFac kf = new KategoriFac();
        public ProduktListe GetProduktListe(int katID)
        {
            ProduktListe pl = new ProduktListe();

            pl.Kategori = kf.Get(katID);
            pl.listProdukt = GetBy("KatID", katID);
            return pl;
        }

        public KategoriProduktliste GetKategoriProduktListe(int katID)
        {
            KategoriProduktliste kpListe = new KategoriProduktliste();

            kpListe.listKategori = kf.GetAll();
            kpListe.listProdukt = GetBy("KatID", katID);
            return kpListe;
        }
    }
}
