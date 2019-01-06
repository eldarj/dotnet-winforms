using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Helpers.Recommenders
{
    // PreporuceniRestorani: User-based CF - vraća preporučene restorane po sličnosti korisnika (omiljeni restorani)
    // Korišteno u: KorisniciController::PreporuceniRestorani ( /api//{id}/slicni)
    public class PreporuceniRestorani
    {
        public class KorisnikOmiljeniMatrix
        {
            public int KorisnikID;
            public List<Restorani> Omiljeni;
            public int BrojIstih;
            public List<Restorani> Razliciti;
        }

        public static int BROJ_RESTORANA_ZA_PREPORUCITI = 5;
        public static int MIN_SLICNIH_OMILJENIH = 1;

        public static EasyFoodEntities db = new EasyFoodEntities();

        private Korisnik korisnik;
        private List<Restorani_Result> KorisnikoviOmiljeniRestorani;
        private List<Restorani_Result> Preporuceni = new List<Restorani_Result>();
        private List<KorisnikOmiljeniMatrix> KorisniciOmiljeniMat;

        public PreporuceniRestorani(int korisnikId)
        {
            korisnik = db.Korisnik.Where(k => k.KorisnikID == korisnikId).FirstOrDefault();
        }

        public List<Restorani_Result> GetPreporucene()
        {
            if (korisnik == null) return Preporuceni;

            try
            {
                KorisnikoviOmiljeniRestorani = db.esp_Restorani_Omiljeni(korisnik.KorisnikID, null).ToList(); // svi korisnikovi omiljeni

                if (KorisnikoviOmiljeniRestorani.Count == 0) // ako korisnik nema omiljenih, nemamo šta porediti... vrati GetRestoraneBezAlgoritma
                {
                    return GetRestoraneBezAlgoritma(BROJ_RESTORANA_ZA_PREPORUCITI);
                }

                KorisniciOmiljeniMat = GetOmiljeniPoKorisnicimaMatrix();

                Preporuceni.AddRange(KorisniciOmiljeniMat.Where(x => x.BrojIstih >= MIN_SLICNIH_OMILJENIH)
                    .SelectMany(x => x.Razliciti) // concat liste različitih restorana
                    .Select(r => Restorani_Result.GetRestoraniResultInstance(r)) // pretvori u Restorani_Result
                    .ToList());

                if (Preporuceni.Count < BROJ_RESTORANA_ZA_PREPORUCITI)
                {
                    int razlika = BROJ_RESTORANA_ZA_PREPORUCITI - Preporuceni.Count;
                    Preporuceni.AddRange(GetRestoraneBezAlgoritma(razlika, Preporuceni));
                }
            }
            catch (Exception e)
            {
                // dbg
            }

            return Preporuceni;
        }

        // Fallback - vraća restorane s najvišim prosječnim ocjenama (po mogućnosti iz korisnikovog grada)
        private List<Restorani_Result> GetRestoraneBezAlgoritma(int josDodati, List<Restorani_Result> excludeFrom = null)
        {
            // pazi da ne nadopunjavamo preporuke istim restoranima
            var excluded = excludeFrom != null ?
                new HashSet<int>(excludeFrom.Select(x => x.RestoranID)) :
                new HashSet<int>(korisnik.Omiljeni.Select(x => x.RestoranID));

            var restorani = db.Restorani.Where(x => !excluded.Contains(x.RestoranID))
                .OrderByDescending(x => x.Recenzije.Average(rec => rec.Ocjena))
                .ToList();

            var restorani1 = restorani.Where(x => x.Blokovi.GradID == korisnik.Blokovi.GradID).Take(josDodati).ToList();

            // ako nemamo dovoljno iz istog grada, dodaj one iz drugih gradova...
            int razlika = josDodati - restorani1.Count;
            if (razlika > 0)
            {
                restorani1.AddRange(restorani.Where(x => x.Blokovi.GradID != korisnik.Blokovi.GradID).Take(razlika).ToList());
            }

            return restorani1.Select(x => Restorani_Result.GetRestoraniResultInstance(x)).ToList(); 
        }

        // Linq - Vraća 'matricu' - korisnika, nj. omiljenih restorana i omiljenih restorana koji se ne podudaraju s omiljenim restornima našeg korisnika
        public List<KorisnikOmiljeniMatrix> GetOmiljeniPoKorisnicimaMatrix()
        {
            return db.Korisnik.Where(k => k.KorisnikID != korisnik.KorisnikID && k.Omiljeni.Count != 0).ToList()
                    .Select(k => {
                        return new KorisnikOmiljeniMatrix()
                        {
                            KorisnikID = k.KorisnikID,
                            Omiljeni = k.Omiljeni.Select(o => o.Restorani).ToList(),
                            BrojIstih = k.Omiljeni.Where(o => KorisnikoviOmiljeniRestorani.Select(r => r.RestoranID).Contains(o.RestoranID)).Count(),
                            Razliciti = k.Omiljeni.Where(o => !KorisnikoviOmiljeniRestorani.Select(r => r.RestoranID).Contains(o.RestoranID)).Select(o => o.Restorani).ToList()
                        };
                    })
                    .ToList();
        }
    }
}