using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/recenzije")]
    [Route("")]
    public class RecenzijeController : BaseApiController
    {
        //api/recenzije
        //api/recenzije?restoran=1&narucilac=1
        [HttpGet]
        [MyExceptionFilter]
        public List<Recenzije_Result> GetAll([FromUri] int? restoran = null, [FromUri] int? narucilac = null)
        {
            return db.esp_Recenzije_SelectByRestoranOrKorisnik(restoran, narucilac).ToList();
        }

        //api/recenzije/{id}
        [HttpDelete]
        [Route("{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Recenzije r = await db.Recenzije.FindAsync(id);
            try
            {
                db.Recenzije.Remove(r);
                await db.SaveChangesAsync();
                return Ok("Uspješno ste izbrisali komentar!");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }

        //api/recenzije
        [HttpPost]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> CreateRecenzija([FromBody] Recenzije recenzija)
        {
            db.Recenzije.Add(recenzija);
            await db.SaveChangesAsync();
            return Ok(db.esp_Recenzije_SelectByRestoranOrKorisnik(recenzija.RestoranID, null).ToList());
        }
    }
}
