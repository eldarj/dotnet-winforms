﻿using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/locations")]
    [Route("")]
    public class LocationsController : BaseApiController
    {
        //api/locations
        [HttpGet]
        public IHttpActionResult GetLocation()
        {
            return RedirectToRoute("DefaultApi", new { controller = "locations", action = "blokovi" });
        }

        #region Blokovi
        //api/locations/blokovi
        [HttpGet]
        [Route("blokovi")]
        public IHttpActionResult GetBlokovi()
        {
            Thread.Sleep(2000);
            return Ok(db.esp_Blokovi_SelectAll(null).ToList());
        }

        //api/locations/blokovi/{id}
        [HttpGet]
        [Route("blokovi/{id}")]
        [MyExceptionFilter]
        public IHttpActionResult GetSingleBlok([FromUri] int id)
        {
            return Ok(db.esp_Blokovi_SelectAll(null).ToList()
                .Where(b => b.BlokID == id)
                .Single());
        }

        //api/locations/blokovi
        [HttpPost]
        [Route("blokovi")]
        public async Task<IHttpActionResult> PostBlok([FromBody] Blokovi obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Podaci nisu validni!");
            }

            try
            {
                db.Blokovi.Add(obj);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

            return CreatedAtRoute("DefaultApi",
                new { controller = "locations", action = "blokovi", id = obj.BlokID },
                Blokovi_Result.GetBlokoviResultInstance(obj));
        }

        //api/locations/blokovi/{id}
        [HttpPut]
        [Route("blokovi/{id}")]
        public async Task<IHttpActionResult> PutBlok([FromUri] int id, [FromBody] Blokovi obj)
        {
            if (!ModelState.IsValid || obj.BlokID != id)
            {
                return BadRequest("Podaci nisu validni!");
            }

            try
            {
                Blokovi b = await db.Blokovi.FindAsync(id);
                if (b != null)
                {
                    b.GradID = obj.GradID;
                    b.Naziv = obj.Naziv;

                    await db.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("Blok ne postoji u bazi podataka!");
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

            return CreatedAtRoute("DefaultApi", new { controller = "locations", action = "blokovi", id = obj.BlokID },
                Blokovi_Result.GetBlokoviResultInstance(obj));
        }

        //api/locations/blokovi/{id}
        [HttpDelete]
        [Route("blokovi/{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> DeleteBlok([FromUri] int id)
        {
            Blokovi b = await db.Blokovi.FindAsync(id);
            if (b != null)
            {
                db.Blokovi.Remove(b);
                await db.SaveChangesAsync();

                return Ok("Uspješno ste izbrisali blok!");
            }
            return BadRequest("Blok ne postoji u bazi podataka!");
        }

        #endregion

        #region Gradovi
        //api/locations/gradovi
        [HttpGet]
        [Route("gradovi")]
        public IHttpActionResult GetGradovi()
        {
            return Ok(db.esp_Gradovi_SelectAll().ToList());
        }

        //api/locations/gradovi/{id}
        [HttpGet]
        [Route("gradovi/{id}")]
        [MyExceptionFilter]
        public IHttpActionResult GetSingleGrad([FromUri] int id)
        {
            return Ok(db.esp_Gradovi_SelectAll().ToList()
                .Where(g => g.GradID == id)
                .Single());
        }

        //api/locations/gradov/{id}/blokovi
        [HttpGet]
        [Route("gradovi/{id}/blokovi")]
        public IHttpActionResult GetBlokoviByGrad([FromUri] int id)
        {
            return Ok(db.esp_Blokovi_SelectAll(id).ToList());
        }


        //api/locations/gradovi
        [HttpPost]
        [Route("gradovi")]
        public async Task<IHttpActionResult> PostGrad([FromBody] Gradovi obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Podaci nisu validni!");
            }

            try
            {
                db.Gradovi.Add(obj);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

            return CreatedAtRoute("DefaultApi", new { controller = "locations", action = "gradovi", id = obj.GradID }, 
                Gradovi_Result.GetGradoviResultInstance(obj));
        }

        //api/locations/gradovi/{id}
        [HttpPut]
        [Route("gradovi/{id}")]
        public async Task<IHttpActionResult> PutGrad([FromUri] int id, [FromBody] Gradovi obj)
        {
            if (!ModelState.IsValid || obj.GradID != id)
            {
                return BadRequest("Podaci nisu validni!");
            }

            try
            {
                Gradovi g = await db.Gradovi.FindAsync(id);
                if (g != null)
                {
                    g.Naziv = obj.Naziv;
                    g.PostanskiBroj = obj.PostanskiBroj;
                    
                    await db.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("Grad ne postoji u bazi podataka!");
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

            return CreatedAtRoute("DefaultApi", new { controller = "locations", action = "gradovi", id = obj.GradID },
                Gradovi_Result.GetGradoviResultInstance(obj));
        }

        //api/locations/gradovi/{id}
        [HttpDelete]
        [Route("gradovi/{id}")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> DeleteGrad([FromUri] int id)
        {
            Gradovi g = await db.Gradovi.FindAsync(id);
            if (g != null)
            {
                db.Gradovi.Remove(g);
                await db.SaveChangesAsync();

                return Ok("Uspješno ste izbrisali grad!");
            }
            return BadRequest("Grad ne postoji u bazi podataka!");
        }
        #endregion
    }
}