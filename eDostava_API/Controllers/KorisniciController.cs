using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Helpers.Recommenders;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api")]
    public class KorisniciController : BaseApiController
    {
        //api/korisnici?ulogaId=1&gradId=1
        [HttpGet]
        [Route("korisnici")]
        public IHttpActionResult GetKorisnici([FromUri] int? uloga = null, [FromUri] int? grad = null)
        {
            Thread.Sleep(100);
            return Ok(db.esp_Korisnici_SelectByUlogaOrGrad(uloga, grad).ToList());
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

                List<Zaposlenici> deleteZaposlenikRelations = db.Zaposlenici.Where(z => z.KorisnikID == id).ToList();
                List<Vlasnici> deleteVlasnikRelations = db.Vlasnici.Where(v => v.KorisnikID == id).ToList();
                db.Zaposlenici.RemoveRange(deleteZaposlenikRelations);
                db.Vlasnici.RemoveRange(deleteVlasnikRelations);

                await db.SaveChangesAsync();

                return Ok("Uspješno ste izbrisali korisnika!");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }

        //api/korisnici/{id}/preporucenirestorani
        [HttpGet]
        [Route("korisnici/{id}/preporucenirestorani")]
        public List<Restorani_Result> PreporuceniRestorani([FromUri] int id)
        {
            PreporuceniRestorani r = new PreporuceniRestorani(id);
            return r.GetPreporucene();
        }

        //api/korisnici/{id}/omiljenirestorani
        [HttpGet]
        [Route("korisnici/{id}/omiljenirestorani")]
        public IHttpActionResult GetOmiljeni([FromUri] int id)
        {
            return Ok(db.esp_Restorani_Omiljeni(id, null).ToList());
        }

        //api/korisnici/{id}/omiljenirestorani
        [HttpPost]
        [Route("korisnici/{id}/omiljenirestorani")]
        public async Task<IHttpActionResult> ToggleOmiljeni([FromUri] int id, [FromBody] int restoranId)
        {
            Omiljeni omiljeni = await db.Omiljeni.Where(o => o.RestoranID == restoranId && o.KorisnikID == id).SingleOrDefaultAsync();
            string response = "Uspješno ste dodali restoran u omiljene!";

            if (omiljeni != null)
            {
                db.Omiljeni.Remove(omiljeni);
                response = "Uspješno ste uklonili restoran iz omiljenih.";
            }
            else
            {
                db.Omiljeni.Add(new Omiljeni { KorisnikID = id, RestoranID = restoranId });
            }

            await db.SaveChangesAsync();
            return Ok(response);
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

        //api/narucioci?gradId=1
        [HttpGet]
        [Route("narucioci")]
        public IHttpActionResult GetNarucioci([FromUri] int? grad = null)
        {
            List<Narucioci_Result> narucioci = db.esp_Narucioci_SelectAllOrByGrad(grad).ToList();
            return Ok(narucioci);
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

        //api/ulogekorisnika
        [HttpGet]
        [Route("ulogekorisnika")]
        public IHttpActionResult GetUloge()
        {
            Thread.Sleep(100);
            return Ok(db.esp_UlogeKorisnika_SelectAll().ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
