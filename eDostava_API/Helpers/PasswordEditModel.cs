using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Helpers
{
    public class PasswordEditModel
    {
        public int KorisnikID { get; set; }
        public string LozinkaTrenutnaHash { get; set; }
        public string LozinkaNovaHash { get; set; }
        public string LozinkaNovaSalt { get; set; }
    }
}