using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api")]
    public class KorisniciController : BaseApiController
    {
        //api/korisnici
        // optional: api/korisnici?ulogaId=1&gradId=1
        [HttpGet]
        [Route("korisnici")]
        public IHttpActionResult GetKorisnici([FromUri] int? uloga = null, [FromUri] int? grad = null)
        {
            Thread.Sleep(100);
            return Ok(db.esp_Korisnici_SelectByUlogaOrGrad(uloga, grad).ToList());
        }

        //api/korisnici/{id}
        [HttpPut]
        [Route("korisnici/{id}/updaterole")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Update([FromUri] int id, [FromBody] Korisnik obj)
        {
            Korisnik k = await db.Korisnik.FindAsync(id);
            k.UlogaKorisnikaID = obj.UlogaKorisnikaID;

            await db.SaveChangesAsync();

            List<Zaposlenici> deleteZaposlenikRelations = db.Zaposlenici.Where(z => z.KorisnikID == obj.KorisnikID).ToList();
            List<Vlasnici> deleteVlasnikRelations = db.Vlasnici.Where(v => v.KorisnikID == obj.KorisnikID).ToList();
            db.Zaposlenici.RemoveRange(deleteZaposlenikRelations);
            db.Vlasnici.RemoveRange(deleteVlasnikRelations);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi",
                new { controller = "korisnici", id = obj.KorisnikID },
                Korisnici_Result.GetKorisnikResultInstance(obj));
        }

        //api/korisnici/{id}
        [HttpDelete]
        [Route("korisnici/{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Korisnik k = await db.Korisnik.FindAsync(id);
            try
            {
                db.Korisnik.Remove(k);
                await db.SaveChangesAsync();
                return Ok("Uspješno ste izbrisali korisnika!");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }

        //api/ulogekorisnika
        [HttpGet]
        [Route("ulogekorisnika")]
        public IHttpActionResult GetUloge()
        {
            Thread.Sleep(100);
            return Ok(db.esp_UlogeKorisnika_SelectAll().ToList());
        }

        //api/zaposlenici/{id}/restorani
        [HttpGet]
        [Route("zaposlenici/{id}/restorani")]
        public IHttpActionResult GetRestoraneZaposlenika([FromUri] int id)
        {
            return Ok(db.esp_Restorani_SelectAllByZaposlenikVlasnik(id, null).ToList());
        }

        //api/zaposlenici/{id}/restorani
        [HttpPost]
        [Route("zaposlenici/{id}/restorani")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> PostRestoraneZaposlenika([FromUri] int id, [FromBody] List<Restorani_Result> objList)
        {
            Korisnik k = await db.Korisnik.FindAsync(id);

            List<Zaposlenici> todelete = db.Zaposlenici.Where(z => z.KorisnikID == id).ToList();
            db.Zaposlenici.RemoveRange(todelete);
            await db.SaveChangesAsync();

            db.Zaposlenici.AddRange(objList.Select(z => new Zaposlenici { KorisnikID = id, RestoranID = z.RestoranID }).ToList());
            await db.SaveChangesAsync();

            return Ok("Izmjene uspješno sačuvane!");
        }

        //api/vlasnici/{id}/restorani
        [HttpGet]
        [Route("vlasnici/{id}/restorani")]
        public IHttpActionResult GetRestoraneVlasnika([FromUri] int id)
        {
            return Ok(db.esp_Restorani_SelectAllByZaposlenikVlasnik(null, id).ToList());
        }

        //api/vlasnici/{id}/restorani
        [HttpPost]
        [Route("vlasnici/{id}/restorani")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> PostRestoraneVlasnika([FromUri] int id, [FromBody] List<Restorani_Result> objList)
        {
            Korisnik k = await db.Korisnik.FindAsync(id);

            List<Vlasnici> todelete = db.Vlasnici.Where(v => v.KorisnikID == id).ToList();
            db.Vlasnici.RemoveRange(todelete);
            await db.SaveChangesAsync();

            db.Vlasnici.AddRange(objList.Select(v => new Vlasnici { KorisnikID = id, RestoranID = v.RestoranID }).ToList());
            await db.SaveChangesAsync();

            return Ok("Izmjene uspješno sačuvane!");
        }
    }
}
