using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Helpers.Recommenders
{
    // SlicniRestorani: Item-based CF - vraća slične restorane po recenzijama odn. ocjenama
    // Korišteno u: RestoraniController::PreporuceniRestorani ( /api/restorani/{id}/slicni)
    public class SlicniRestorani
    {
        public static EasyFoodEntities db = new EasyFoodEntities();

        public static double SLICNOST_TRESHOLD = 0.6;
        public static double SLICNOST_PROSJEK_MIN= 2.5;
        public static int SLICNOST_BROJ_SLICNIH = 5;

        public static int restoranAktivan = db.RestoranStatusi.Find(3).RestoranStatusID;
        public Dictionary<int, List<Recenzije>> dictOcjene = new Dictionary<int, List<Recenzije>>();

        public List<Restorani_Result> GetSlicnePoOcjenama(int restoranId)
        {
            dictOcjene = GetRecenzijeDict(restoranId); // kolekcija svih ocjena svih restorana
            List<Recenzije> RecenzijePosmatranogRestorana = db.Recenzije.Where(x => x.RestoranID == restoranId).OrderBy(x => x.KorisnikID).ToList();

            List<Restorani_Result> slicniRestorani = new List<Restorani_Result>();
            List<double> prosjeci = new List<double>(); // lista za poređenje prosječnih ocjena, tako da vraćamo one najveće

            // .Where(p => ...) preskoči ako je prosječna ocjena preniska
            dictOcjene.Where(pair => pair.Value.Average(r => r.Ocjena) >= SLICNOST_PROSJEK_MIN).ToList().ForEach(pair =>
            {
                List<Recenzije> recenzije1 = new List<Recenzije>();
                List<Recenzije> recenzije2 = new List<Recenzije>();

                double prosjecnaOcjena = pair.Value.Average(x => x.Ocjena); 

                foreach (var r in RecenzijePosmatranogRestorana)
                {
                    if (pair.Value.Where(x => x.KorisnikID == r.KorisnikID).Count() > 0)
                    {
                        var rem = pair.Value.Where(x => x.KorisnikID == r.KorisnikID).First();

                        recenzije1.Add(r);
                        recenzije2.Add(rem);

                        pair.Value.Remove(rem); // pošto u slučaju ove aplikacije, po jednom korisniku može postojati više recenzija, moramo paziti da ne dodajemo iste.
                    }
                }
                double slicnost = CalcSlicnost(recenzije1, recenzije2);
                if (slicnost > SLICNOST_TRESHOLD)
                {
                    if (slicniRestorani.Count < SLICNOST_BROJ_SLICNIH) // dodaj samo odr. broj sličnih restorana (npr. ne više od 5)
                    {
                        prosjeci.Add(prosjecnaOcjena);
                        slicniRestorani.Add(db.esp_Restorani_SelectAll(pair.Key).First());
                    }
                    else if (prosjecnaOcjena > prosjeci.Min()) // a u slučaju da već imamo 5 restorana, provjeri jesmo li dodali neki s manjom prosječnom ocj. od ovog - ako jesmo, zamijeni ih
                    {
                        try
                        {
                            int indexOfMin = prosjeci.IndexOf(prosjeci.Min());
                            slicniRestorani.RemoveAt(indexOfMin);
                            slicniRestorani.Insert(indexOfMin, db.esp_Restorani_SelectAll(pair.Key).First());
                            prosjeci.RemoveAt(indexOfMin);
                            prosjeci.Insert(indexOfMin, prosjecnaOcjena);
                        }
                        catch (Exception e)
                        {
                            //
                        }
                    }
                }
            });
            
            return slicniRestorani;
        }

        public double CalcSlicnost(List<Recenzije> zajednickeOcjene1, List<Recenzije> zajednickeOcjene2)
        {
            // ako liste nisu iste dužine vrati 0
            // također, ako imaju samo jedan par ocjena, vrati 0, jer u tom slučaju će ovaj algoritam uvijek vraćati koeficijent 1
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count || zajednickeOcjene1.Count == 1) return 0; 

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajednickeOcjene2.Count; i++)
            {
                brojnik += zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena;
                nazivnik1 += Math.Pow(zajednickeOcjene1[i].Ocjena, 2);
                nazivnik2 += Math.Pow(zajednickeOcjene2[i].Ocjena, 2);
            }

            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);
            double nazivnik = nazivnik1 * nazivnik2;

            return nazivnik == 0 ? nazivnik : brojnik / nazivnik;
        }

        // Linq - Vraća Dict-matricu - sve ocjene svih restorana (osim onog našeg posmatranog)
        public Dictionary<int, List<Recenzije>> GetRecenzijeDict(int id) =>
            db.Restorani.Where(r => r.RestoranID != id && r.RestoranStatusID == 3 && r.Recenzije.Count > 0)
              .ToDictionary(r => r.RestoranID, r => new List<Recenzije>(r.Recenzije.OrderBy(z => z.KorisnikID)));
    }
}