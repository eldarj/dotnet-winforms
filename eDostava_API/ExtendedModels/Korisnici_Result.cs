using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Korisnici_Result
    {
        public static Korisnici_Result GetKorisnikResultInstance(Korisnik obj)
        {
            return new Korisnici_Result
            {
                KorisnikID = obj.KorisnikID,
                Username = obj.Username,
                ImePrezime = obj.Ime + " " + obj.Prezime,
                Adresa = obj.Adresa,
                BlokID = obj.BlokID,
                Blok = obj.Blokovi.Naziv,
                DatumRegistracije = obj.DatumRegistracije,
                Email = obj.Email,
                Grad = obj.Blokovi.Gradovi.Naziv,
                GradID = obj.Blokovi.GradID,
                Telefon = obj.Telefon,
                Uloga = obj.UlogaKorisnika.Uloga,
                UlogaKorisnikaID = obj.UlogaKorisnikaID
            };
        }
    }
}