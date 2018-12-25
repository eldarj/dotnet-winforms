using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/zaposlenici")]
    [Route("")]
    public class ZaposleniciController : BaseApiController
    {
        //api/zaposlenici
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(db.esp_Zaposlenici_SelectByRestoran(null).ToList());
        }

        //api/zaposlenici/{id}
        [HttpGet]
        [Route("{id}")]
        [MyExceptionFilter]
        public IHttpActionResult GetSingle([FromUri] int id)
        {
            // Throws InvalidOperationException if resource doesn't exist
            return Ok(db.esp_Zaposlenici_SelectByRestoran(null).ToList()
            .Where(z => z.KorisnikID == id)
            .Single());
        }
    }
}
