using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDostava_API.Helpers
{
    public class RecenzijeEqualityComparer : IEqualityComparer<Recenzije>
    {
        public bool Equals(Recenzije x, Recenzije y)
        {
            return x.KorisnikID == y.KorisnikID;
        }

        public int GetHashCode(Recenzije obj)
        {
            unchecked
            {
                int hash = (17 * 23) + obj.KorisnikID.GetHashCode();
                return hash;
            }
        }
    }
}