using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Narudzbe_Result
    {
        public List<StavkeNarudzbe_Result> StavkeNarudzbe;
        public static Narudzbe_Result GetNarudzbeResultInstance(Narudzbe obj)
        {
            try
            {
                return new Narudzbe_Result
                {
                    NarudzbaID = obj.NarudzbaID,
                    Sifra = obj.Sifra,
                    DatumVrijeme = obj.DatumVrijeme,
                    UkupnaCijena = obj.UkupnaCijena,
                    NarucilacID = obj.NarucilacID,
                    Narucilac = new EasyFoodEntities().Korisnik.Where(n => n.KorisnikID == obj.NarucilacID).Select(n => n.Ime + " " + n.Prezime).SingleOrDefault(),
                    NarudzbaStatusID = obj.NarudzbaStatusID,
                    StatusNarudzbe = obj.NarudzbaStatusi != null ? obj.NarudzbaStatusi.Naziv : "-",
                    Adresa = obj.Adresa,
                    BlokID = obj.BlokID,
                    BlokNaziv = obj.Blokovi != null ? obj.Blokovi.Naziv : "-",
                    GradID = obj.Blokovi != null ? obj.Blokovi.GradID : 0,
                    GradNaziv = obj.Blokovi != null && obj.Blokovi.Gradovi != null ? obj.Blokovi.Gradovi.Naziv : "-",
                    AdresaFull = obj.Blokovi != null && obj.Blokovi.Gradovi != null ?  obj.Adresa + " " + obj.Blokovi.Naziv + ", " + obj.Blokovi.Gradovi.Naziv : "-",
                    StatusPromijenioZaposlenik = obj.Korisnik != null ? obj.Korisnik.Ime + " " + obj.Korisnik.Prezime : "-",
                    StatusPromijenioZaposlenikID = obj.KorisnikID,
                    StavkeNarudzbe = obj.StavkeNarudzbe.Select(itm => StavkeNarudzbe_Result.GetStavkaResultInstance(itm)).ToList()
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}