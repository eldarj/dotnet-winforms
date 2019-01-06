using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Threading;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/Restorani/{restoranId}/Hrana")]
    [Route("")]
    public class HranaController : BaseApiController
    {
        //api/Restorani/{restoranId}/Hrana
        [HttpGet]
        public async Task<IHttpActionResult> GetByRestoran([FromUri] int restoranId)
        {
            Thread.Sleep(1000);
            var Restoran = await db.Restorani.FindAsync(restoranId);
            if (Restoran != null)
            {
                return Ok(db.esp_Hrana_SelectByRestoran(Restoran.RestoranID).ToList());
            }
            return BadRequest("Restoran ne postoji u bazi podataka!");
        }

        //api/Restorani/{restoranId}/Hrana/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetSingle([FromUri] int id)
        {
            Hrana obj = await db.Hrana.FindAsync(id);
            if (obj != null)
            {
                return Ok(Hrana_Result.GetHranaResultInstance(obj));
            }
            return BadRequest("Tražena stavka hrane ne postoji!");
        }

        //api/Restorani/{restoranId}/Hrana/Pretraga/{param?}
        [HttpGet]
        [Route("Pretraga/{param?}")]
        public async Task<IHttpActionResult> Pretraga([FromUri] int restoranId, [FromUri] string param = "")
        {
            Thread.Sleep(1000); // ukloni kasnije
            var Restoran = await db.Restorani.FindAsync(restoranId);
            if (Restoran != null)
            {
                return Ok(
                        param == "" ?
                        db.esp_Hrana_SelectByRestoran(Restoran.RestoranID) :
                        db.esp_Hrana_Pretraga(Restoran.RestoranID, param)
                    );
            }
            return BadRequest();
        }
        //api/Restorani/{restoranId}/Hrana
        [HttpPost]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Nova([FromUri] int restoranId, [FromBody] Hrana obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Podaci nisu validni!");
            }

            try
            {
                db.Hrana.Add(obj);
                await db.SaveChangesAsync();
            } catch(Exception e)
            {
                throw new NotImplementedException();
            }

            return Ok(Hrana_Result.GetHranaResultInstance(obj));
        }
        //api/Restorani/{restoranId}/Hrana/{id}
        [HttpPut]
        [Route("{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Update([FromUri] int restoranId, [FromUri] int id, [FromBody] Hrana obj)
        {
            if (!ModelState.IsValid || obj.HranaID != id)
            {
                return BadRequest("Podaci nisu validni!");
            }

            Hrana stavka = await db.Hrana.FindAsync(obj.HranaID);
            try
            {
                if (stavka == null)
                {
                    return BadRequest("Stavka ne postoji u bazi podataka!");
                }

                stavka.Naziv = obj.Naziv;
                stavka.Opis = obj.Opis;
                stavka.Sifra = obj.Sifra;
                stavka.Cijena = obj.Cijena;
                stavka.TipKuhinjeID = obj.TipKuhinjeID;
                stavka.Slika = obj.Slika;
                stavka.SlikaThumb = obj.SlikaThumb;

                await db.SaveChangesAsync();

                return Ok(Hrana_Result.GetHranaResultInstance(obj));
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        //api/Restorani/{restoranId}/Hrana/{id}
        [HttpDelete]
        [Route("{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Delete([FromUri] int restoranId, [FromUri] int id)
        {
            Restorani r = await db.Restorani.FindAsync(restoranId);
            if (r == null)
            {
                return BadRequest("Došlo je do greške, restoran ne postoji u bazi!");
            }

            Hrana h = r.Hrana.Where(x => x.HranaID == id).Single();

            if (h != null)
            {
                db.Hrana.Remove(h);
                await db.SaveChangesAsync();

                return Ok("Uspješno ste izbrisali stavku hrane!");
            }

            return BadRequest("Stavka hrane ne postoji u bazi!");
        }
    }
}
