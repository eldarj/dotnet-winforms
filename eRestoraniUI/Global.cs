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
        public static MainForm Mdi { get; set; }

        public static Korisnik PrijavljeniKorisnik { get; set; }

        public async static Task<List<Restorani_Result>> LoadApiKorisnikRestorani()
        {
            HttpResponseMessage response = null;
            if (UserAccessControlHelper.ZaposlenikRights)
            {
                response = await new WebApiHelper().GetResponse(String.Format("zaposlenici/{0}/restorani", PrijavljeniKorisnik.KorisnikID));
            }
            else if (UserAccessControlHelper.VlasnikRights)
            {
                response = await new WebApiHelper().GetResponse(String.Format("vlasnici/{0}/restorani", PrijavljeniKorisnik.KorisnikID));
            }
            else if (UserAccessControlHelper.AdminRights)
            {
                response = await new WebApiHelper().GetResponse("restorani");
            }

            if(response != null && response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Restorani_Result>>().Result;
            }

            return null;
        }
    }
}
