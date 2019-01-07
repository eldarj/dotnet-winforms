using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestoraniUI.Utils;
using System.Net.Http;

namespace eRestoraniUI
{
    class Global
    {
        public static Korisnik PrijavljeniKorisnik { get; set; }

        public async static Task<List<Restorani>> GetKorisnikRestorani()
        {
            HttpResponseMessage response = null;
            if (UserAccessControlHelper.HasZaposlenikAcess)
            {
                response = await new WebApiHelper().GetResponse(String.Format("zaposlenici/{0}/restorani", PrijavljeniKorisnik.KorisnikID));
            }
            else if (UserAccessControlHelper.HasVlasnikAccess)
            {
                response = await new WebApiHelper().GetResponse(String.Format("zaposlenici/{0}/restorani", PrijavljeniKorisnik.KorisnikID));
            }
            else if (UserAccessControlHelper.HasAdminAccess)
            {
                response = await new WebApiHelper().GetResponse(String.Format("zaposlenici/{0}/restorani", PrijavljeniKorisnik.KorisnikID));
            }

            if(response != null && response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Restorani>>().Result;
            }

            return null;
        }

        public static MainForm Mdi { get; set; }
    }
}
