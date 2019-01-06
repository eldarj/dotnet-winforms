using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Models
{
    public partial class Recenzije
    {
        public override bool Equals(object obj)
        {
            int restoranId = this.RestoranID;
            int restoranId2 = ((Recenzije)obj).RestoranID;
            Recenzije r = this;
            return this.KorisnikID == ((Recenzije)obj).KorisnikID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (17 * 23) + this.KorisnikID.GetHashCode();
            }
        }
    }
}