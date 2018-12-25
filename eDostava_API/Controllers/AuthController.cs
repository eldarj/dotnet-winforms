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
    public class AuthController : BaseApiController
    {
        // api/Auth/{username}
        [HttpGet]
        [Route("api/Auth/{username}")]
        public IHttpActionResult GetKorisnici(string username)
        {
            Korisnik k = db.Korisnik.Where(x => x.Username == username).FirstOrDefault();

            if (k == null)
            {
                return NotFound();
            }

            return Ok(k);
        }
    }
}
