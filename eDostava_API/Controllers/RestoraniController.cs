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
        [HttpGet]
        public List<Restorani_Result> GetAll()
        {
            return db.esp_Restorani_SelectAll().ToList();
        }

        //api/Restorani/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetSingle([FromUri] int id)
        {
            Restorani_Result r = db.esp_Restorani_SelectAll().ToList()
                .Where(x => x.RestoranID == id)
                .Single();

            if (r != null)
            {
                return Ok(r);
            }

            return NotFound();
        }

        //api/Restorani/Pretraga/{param?}
        [HttpGet]
        [Route("Pretraga/{param?}")]
        public List<Restorani_Result> Pretraga([FromUri] string param = "")
        {
            return db.esp_Restorani_FilterString(param).ToList();
        }

        //api/Restorani/{id}
        [HttpDelete]
        [MyExceptionFilter]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Restorani r = await db.Restorani.FindAsync(id);
            if (r != null)
            {
                db.Restorani.Remove(r);
                await db.SaveChangesAsync();

                return Ok("Uspješno ste izbrisali restoran!");
            }

            return BadRequest("Ne postoji ni jedan restoran s navedenim id-em!");
        }

        //api/Restorani
        [HttpPost]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> PostRestoran([FromBody] Restorani obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Nevalidni podaci!");
            }

            try
            {
                db.Restorani.Add(obj);
                await db.SaveChangesAsync();
            } catch (Exception e) // TODO: change this to EntityException when you add stored procedures (vid: RS2 8.)
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
            return Ok("Uspješno ste kreirali novi restoran!");
        }

        //api/Restorani/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> PutRestoran([FromUri] int id, [FromBody] Restorani obj)
        {
            if (!ModelState.IsValid || obj.RestoranID != id)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Restorani restoran = await db.Restorani.FindAsync(obj.RestoranID);
                if (restoran != null)
                {
                    restoran = obj;
                    await db.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("Restoran ne postoji u bazi podataka!");
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

            return Ok("Izmjene uspješno sačuvane!");
        }

        //api/restorani/{id}/zaposlenici
        [HttpGet]
        [Route("{id}/zaposlenici")]
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
