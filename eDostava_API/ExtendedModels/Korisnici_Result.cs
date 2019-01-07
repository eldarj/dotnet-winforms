using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Korisnici_Result
    {
        public string AdresaFull { get; set; }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
                return KorisnikID == ((Korisnici_Result)obj).KorisnikID;
        }

        public static Korisnici_Result GetKorisnikResultInstance(Korisnik obj)
        {
            return obj == null ? null : new Korisnici_Result
            {
                KorisnikID = obj.KorisnikID,
                Username = obj.Username,
                Ime = obj.Ime,
                Prezime = obj.Prezime,
                ImePrezime = obj.Ime + " " + obj.Prezime,
                Adresa = obj.Adresa,
                BlokID = obj.BlokID,
                Blok = obj.Blokovi.Naziv,
                DatumRegistracije = obj.DatumRegistracije,
                Email = obj.Email,
                Grad = obj.Blokovi.Gradovi.Naziv,
                GradID = obj.Blokovi.GradID,
                AdresaFull = obj.Blokovi != null && obj.Blokovi.Gradovi != null ? obj.Adresa + " " + obj.Blokovi.Naziv + ", " + obj.Blokovi.Gradovi.Naziv : "-",
                Telefon = obj.Telefon,
                Uloga = obj.UlogaKorisnika.Uloga,
                UlogaKorisnikaID = obj.UlogaKorisnikaID
            };
        }
    }
}