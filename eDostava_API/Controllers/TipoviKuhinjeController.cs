using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/tipovikuhinje")]
    [Route("")]
    [MyExceptionFilter]
    public class TipoviKuhinjeController : BaseApiController
    {
        //api/TipoviKuhinje
        [HttpGet]
        public List<TipoviKuhinje_Result> GetAll()
        {
            return db.esp_TipoviKuhinje_SelectAll().ToList();
        }

        //api/TipoviKuhinje/{id}
        [HttpGet]
        [Route("{id}"),ActionName("GetSingle")]
        public async Task<IHttpActionResult> GetSingle([FromUri] int id)
        {
            TipoviKuhinje t = await db.TipoviKuhinje.FindAsync(id);
           
            if (t != null)
            {
                return Ok(new TipoviKuhinje_Result
                {
                    Naziv = t.Naziv,
                    Opis = t.Opis,
                    TipKuhinjeID = t.TipKuhinjeID
                });
            }

            return NotFound();
        }

        //api/TipoviKuhinje
        [HttpPost]
        public async Task<IHttpActionResult> PostTipKuhinje([FromBody] TipoviKuhinje obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Nevalidni podaci!");
            }

            db.TipoviKuhinje.Add(obj);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { controller = "TipoviKuhinje", action = "GetSingle", id = obj.TipKuhinjeID }, obj);
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
