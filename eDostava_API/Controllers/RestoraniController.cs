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

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/Restorani")]
    [Route("")]
    public class RestoraniController : BaseApiController
    {
        //api/Restorani
        //api/Restorani?blok=1&grad=1&status=1
        [HttpGet]
        public List<Restorani_Result> GetAll([FromUri] int? blok = null, [FromUri] int? grad = null, [FromUri] int? status = null)
        {
            return db.esp_Restorani_FilterBlokGradStatus(blok, grad, status).ToList();
        }

        //api/restorani/{id}
        [HttpGet]
        [Route("{id}")]
        [MyExceptionFilter]
        public IHttpActionResult GetSingle([FromUri] int id)
        {
            try
            {
                Restorani_Result r = db.esp_Restorani_SelectAll().ToList()
                    .Where(x => x.RestoranID == id)
                    .Single();
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
        [MyExceptionFilter]
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
        [MyExceptionFilter]
        public async Task<IHttpActionResult> PostRestoran([FromBody] Restorani obj)
        {
            try
            {
                db.Restorani.Add(obj);
                await db.SaveChangesAsync();
                return Ok("Uspješno ste kreirali novi restoran!");
            }
            catch (Exception e) // TODO: change this to EntityException when you add stored procedures (vid: RS2 8.)
            {
                //if (e is EntityException)
                //{
                //    throw CreateHttpResponseException(ExceptionHandler.HandleEception(e as EntityException),
                //        HttpStatusCode.Conflict);
                //} else
                //{
                //    return BadRequest();
                //}
                throw new NotImplementedException();
            }
        }

        //api/restorani/{id}
        [HttpPut]
        [Route("{id}")]
        [MyExceptionFilter]
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

            r.RestoranStatusID = obj.RestoranStatusID;

            //user koji je zadnji promijenio status restorana
            r.KorisnikID = r.RestoranStatusID != obj.RestoranStatusID ?  
                obj.KorisnikID : r.KorisnikID; 

            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { controller = "Restorani", action = "GetSingle", id = obj.RestoranID }, obj);
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
        [MyExceptionFilter]
        public IHttpActionResult GetZaposlenikeRestorana([FromUri] int id)
        {
            Thread.Sleep(250);
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
        [MyExceptionFilter]
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
        [MyExceptionFilter]
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
        [MyExceptionFilter]
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
