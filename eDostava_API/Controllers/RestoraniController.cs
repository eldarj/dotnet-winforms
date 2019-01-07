using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eDostava_API.Models;
using System.Web.Http.Description;
using eDostava_API.Helpers.BaseClasses;
using System.Data.Entity.Core;
using eDostava_API.Helpers;
using System.Threading.Tasks;
using System.Threading;
using eDostava_API.Helpers.Recommenders;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/Restorani")]
    [Route("")]
    [MyExceptionFilter]
    public class RestoraniController : BaseApiController
    {
        //api/Restorani?blok=1&grad=1&status=1
        [HttpGet]
        public List<Restorani_Result> GetAll([FromUri] int? blok = null, [FromUri] int? grad = null, [FromUri] int? status = null)
        {
            return db.esp_Restorani_FilterBlokGradStatus(blok, grad, status).ToList();
        }

        //api/restorani/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetSingle([FromUri] int id)
        {
            try
            {
                Restorani_Result r = db.esp_Restorani_SelectAll(id).Single();
                return Ok(r);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }

        //api/restorani/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Restorani r = await db.Restorani.FindAsync(id);
            try
            {
                db.Restorani.Remove(r);
                await db.SaveChangesAsync();
                return Ok("Uspješno ste izbrisali restoran!");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }

        //api/Restorani
        [HttpPost]
        public async Task<IHttpActionResult> PostRestoran([FromBody] Restorani obj)
        {
            try
            {
                obj.Sifra = Guid.NewGuid();
                db.Restorani.Add(obj);
                await db.SaveChangesAsync();
                return Ok("Uspješno ste kreirali novi restoran!");
            }
            catch (Exception e) 
            {
                if (e is EntityException)
                {
                    throw ExceptionHandler.CreateHttpResponseException(ExceptionHandler.HandleEception(e as EntityException),
                        HttpStatusCode.Conflict);
                }

                throw new InvalidOperationException();
            }
        }

        //api/restorani/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> PutRestoran([FromUri] int id, [FromBody] Restorani obj)
        {
            Restorani r = await db.Restorani.FindAsync(id);

            r.Naziv = obj.Naziv;
            r.Opis = obj.Opis;
            r.Email = obj.Email;
            r.WebUrl = obj.WebUrl;
            r.Telefon = obj.Telefon;
            r.Slika = obj.Slika;
            r.MinimalnaCijenaNarudzbe = obj.MinimalnaCijenaNarudzbe;

            r.Adresa = obj.Adresa;
            r.BlokID = obj.BlokID;

            if (obj.RestoranStatusID != 0 && obj.RestoranStatusID != r.RestoranStatusID)
            {
                r.RestoranStatusID = obj.RestoranStatusID;
                r.KorisnikID = obj.KorisnikID;
            }

            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { controller = "Restorani", action = "GetSingle", id = obj.RestoranID }, obj);
        }

        //api/restorani/{id}/slicni
        [HttpGet]
        [Route("{id}/slicni")]
        public List<Restorani_Result> PreporuceniRestorani([FromUri] int id)
        {
            SlicniRestorani r = new SlicniRestorani();
            return r.GetSlicnePoOcjenama(id);
        }

        //api/restorani/{id}/recenzije
        [HttpGet]
        [Route("{id}/recenzije")]
        public List<Recenzije_Result> Recenzije([FromUri] int id)
        {
            return db.esp_Recenzije_SelectByRestoranOrKorisnik(id, null).ToList();
        }

        //api/restorani/statusi
        [HttpGet]
        [Route("statusi")]
        public IHttpActionResult GetStatusi()
        {
            return Ok(db.esp_RestoranStatusi_SelectAll().ToList());
        }

        //api/restorani/{id}/zaposlenici
        [HttpGet]
        [Route("{id}/zaposlenici")]
        public IHttpActionResult GetZaposlenikeRestorana([FromUri] int id)
        {
            Thread.Sleep(100);
            List<Korisnik> zaposlenici = db.Korisnik
                .Where(x => db.Zaposlenici
                    .Select(z => new { z.KorisnikID, z.RestoranID })
                    .ToList()
                    .Contains(new { KorisnikID = x.KorisnikID, RestoranID = id }))
                .ToList();

            return Ok(zaposlenici.Select(z => Korisnici_Result.GetKorisnikResultInstance(z)));
        }

        //api/restorani/{id}/zaposlenici
        [HttpPost]
        [Route("{id}/zaposlenici")]
        public async Task<IHttpActionResult> PostZaposlenikeRestorana([FromUri] int id, [FromBody] List<Korisnici_Result> objList)
        {
            Restorani r = await db.Restorani.FindAsync(id);

            List<Zaposlenici> todelete = db.Zaposlenici.Where(z => z.RestoranID == id).ToList();
            db.Zaposlenici.RemoveRange(todelete);
            await db.SaveChangesAsync();

            db.Zaposlenici.AddRange(objList.Select(z => new Zaposlenici { KorisnikID = z.KorisnikID, RestoranID = id }).ToList());
            await db.SaveChangesAsync();

            return Ok("Izmjene uspješno sačuvane!");
        }

        //api/restorani/{id}/vlasnici
        [HttpGet]
        [Route("{id}/vlasnici")]
        public IHttpActionResult GetVlasnikeRestorana([FromUri] int id)
        {
            List<Korisnik> vlasnici = db.Korisnik
                .Where(x => db.Vlasnici
                    .Select(v => new { v.KorisnikID, v.RestoranID })
                    .ToList()
                    .Contains(new { x.KorisnikID, RestoranID = id }))
                .ToList();

            return Ok(vlasnici.Select(v => Korisnici_Result.GetKorisnikResultInstance(v)));
        }

        //api/restorani/{id}/vlasnici
        [HttpPost]
        [Route("{id}/vlasnici")]
        public async Task<IHttpActionResult> PostVlasnikeRestorana([FromUri] int id, [FromBody] List<Korisnici_Result> objList)
        {
            Restorani r = await db.Restorani.FindAsync(id);

            List<Vlasnici> todelete = db.Vlasnici.Where(z => z.RestoranID == id).ToList();
            db.Vlasnici.RemoveRange(todelete);
            await db.SaveChangesAsync();

            db.Vlasnici.AddRange(objList.Select(z => new Vlasnici { KorisnikID = z.KorisnikID, RestoranID = id }).ToList());
            await db.SaveChangesAsync();

            return Ok("Izmjene uspješno sačuvane!");
        }

        //api/restorani/pretraga/{param}
        [HttpGet]
        [Route("Pretraga/{param?}")]
        public List<Restorani_Result> Pretraga([FromUri] string param = "")
        {
            return db.esp_Restorani_FilterString(param).ToList();
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
