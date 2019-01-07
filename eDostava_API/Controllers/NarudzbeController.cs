using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api")]
    [MyExceptionFilter]
    public class NarudzbeController : BaseApiController
    {

        //api/narudzbe
        // optional: api/narudzbe?narucilac=1&restoran=1&status=1
        [HttpGet]
        [Route("narudzbe")]
        public IHttpActionResult GetAll([FromUri] int? narucilac = null, [FromUri] int? restoran = null, [FromUri] int? status = null)
        {
            Thread.Sleep(200);
            return Ok(db.esp_Narudzbe_SelectAllOrByNarucilacOrRestoran(narucilac, restoran, status).ToList());
        }

        //api/narudzbe/{id}
        [HttpGet]
        [Route("narudzbe/{id}")]
        public IHttpActionResult GetSingle([FromUri] int id)
        {
            Narudzbe dbNarudzba = db.Narudzbe
                .Include(n => n.Korisnik)
                .Include(n => n.NarudzbaStatusi)
                .Include(n => n.Blokovi.Gradovi)
                .Include(n => n.StavkeNarudzbe)
                .FirstOrDefault(n => n.NarudzbaID == id);

            return Ok(Narudzbe_Result.GetNarudzbeResultInstance(dbNarudzba));
        }

        //api/narudzbe
        [HttpPost]
        [Route("narudzbe")]
        public IHttpActionResult CreateNarudzba([FromBody] Narudzbe narudzba)
        {
            narudzba.DatumVrijeme = DateTime.Now;
            narudzba.NarudzbaStatusID = 1;
            narudzba.Sifra = Guid.NewGuid();
            narudzba.UkupnaCijena = narudzba.StavkeNarudzbe.Select(s => s.Kolicina * s.Hrana.Cijena).Sum();

            // Kod snimanja podataka, u slučaju da EF nije taj koji je učitao podatke, 
            // EF neće znati da navigation propertiji već postoje u bazi (npr. Hrana), 
            // u tom slučaju trebamo prije snimanja koristiti .Attach(), da bi EF znao da određene navigation podatke ne treba snimati u bazu
            narudzba.StavkeNarudzbe.ToList().ForEach(s =>
            {
                db.Hrana.Attach(s.Hrana);
            });

            db.Narudzbe.Add(narudzba);
            db.SaveChanges();

            return Ok(narudzba);
        }

        //api/narudzbe/{id}
        [HttpDelete]
        [Route("narudzbe/{id}")]
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

        //api/narudzbe/{id}
        [HttpPut]
        [Route("narudzbe/{id}")]
        public async Task<IHttpActionResult> Update([FromUri] int id, [FromBody] Narudzbe obj)
        {
            Narudzbe n = await db.Narudzbe.FindAsync(id);

            n.NarudzbaStatusID = obj.NarudzbaStatusID;
            n.KorisnikID = obj.KorisnikID;

            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { controller = "Narudzbe", action = "GetSingle", id = obj.NarudzbaID }, obj);
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
