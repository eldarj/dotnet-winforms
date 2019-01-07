using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoraniUI.Utils
{
    // User access control
    public static class UserAccessControlHelper
    {
        public static Dictionary<int, string> Roles = new Dictionary<int, string>{ { 1, "Zaposlenik" }, { 2, "Vlasnik" }, { 4, "Administrator" } };

        public static bool AdminRights => Global.PrijavljeniKorisnik.UlogaKorisnikaID == 4;
        public static bool VlasnikRights => Global.PrijavljeniKorisnik.UlogaKorisnikaID == 2;
        public static bool ZaposlenikRights => Global.PrijavljeniKorisnik.UlogaKorisnikaID == 1;
    }
}
