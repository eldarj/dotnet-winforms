//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDostava_API.Models
{
    using System;
    
    public partial class Narucioci_Result
    {
        public int KorisnikID { get; set; }
        public string Username { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public System.DateTime DatumRegistracije { get; set; }
        public string Adresa { get; set; }
        public Nullable<int> BlokID { get; set; }
        public string Blok { get; set; }
        public Nullable<int> GradID { get; set; }
        public string Grad { get; set; }
        public int UlogaKorisnikaID { get; set; }
        public string Uloga { get; set; }
        public Nullable<int> BrojNarudzbi { get; set; }
        public Nullable<double> UkupnoPotrosio { get; set; }
    }
}
