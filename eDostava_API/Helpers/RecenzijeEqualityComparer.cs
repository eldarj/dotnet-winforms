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
            // Zašto unchecked? - gethashcode inače radi sa 'dugim' podacima, pa implementiraju unchecked ('krati' podatke i ne baca exception)
            //          jer nas zapravo ne zanima hoćel doći do int overflow-a, 32 bita je dovoljno da nam da 'unique' vr., 
            //          a nama čak u ovom slučaju nije ni potreban ali ok
            unchecked
            {
                // zašto 17 i 23? 
                // prime brojevi daju memory-wise 'unikatnije' vrijednosti i bolje performanse ¯\_(ツ)_/¯
                int hash = (17 * 23) + obj.KorisnikID.GetHashCode();
                return hash;
            }
        }
    }
}