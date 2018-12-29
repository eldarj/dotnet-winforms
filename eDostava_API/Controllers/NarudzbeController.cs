using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api")]
    public class NarudzbeController : BaseApiController
    {

        //api/narudzbe
        // optional: api/narudzbe?narucilac=1&restoran=1&status=1
        [HttpGet]
        [Route("narudzbe")]
        public IHttpActionResult GetAll([FromUri] int? narucilac = null, [FromUri] int? restoran = null, [FromUri] int? status = null)
        {
            Thread.Sleep(500);
            return Ok(db.esp_Narudzbe_SelectAllOrByNarucilacOrRestoran(narucilac, restoran, status).ToList());
        }

        //api/narudzbe/{id}
        [HttpDelete]
        [Route("narudzbe/{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Narudzbe n = await db.Narudzbe.FindAsync(id);
            try
            {
                db.Narudzbe.Remove(n);
                await db.SaveChangesAsync();
                return Ok("Uspješno ste izbrisali narudžbu!");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
            }
        }

        //api/narudzbe/statusi
        [HttpGet]
        [Route("narudzbe/statusi")]
        public IHttpActionResult GetStatusi()
        {
            Thread.Sleep(100);
            return Ok(db.esp_NarudzbeStatusi_SelectAll().ToList());
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
