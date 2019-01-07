using eDostava_API.Helpers;
using eDostava_API.Helpers.BaseClasses;
using eDostava_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDostava_API.Controllers
{
    [RoutePrefix("api/Auth")]
    [Route("")]
    public class AuthController : BaseApiController
    {
        // api/auth/{username}
        [HttpGet]
        [Route("{username}")]
        public IHttpActionResult GetKorisnik([FromUri] string username)
        {
            Korisnik k = db.Korisnik.Where(x => x.Username == username).FirstOrDefault();

            if (k == null)
            {
                return NotFound();
            }

            return Ok(k.LozinkaSalt);
        }

        // api/auth
        [HttpPost]
        public IHttpActionResult Login([FromBody] Korisnik Model)
        {
            Korisnik user = db.Korisnik.Where(x => x.Username == Model.Username && x.LozinkaHash == Model.LozinkaHash).SingleOrDefault();
            if (user == null)
            {
                return BadRequest("Pogrešan username ili password");
            }
            Korisnici_Result r = Korisnici_Result.GetKorisnikResultInstance(user);
            return Ok(r);
        }

        // api/auth/register
        [HttpPost]
        [Route("register")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Register([FromBody] Korisnik Model)
        {
            Korisnik existing = await db.Korisnik.FindAsync(Model.KorisnikID); // provjeri je li postoji user
            if (existing != null)
            {
                return BadRequest("Username " + Model.Username + " je već zauzet");
            }

            Korisnik novi = new Korisnik
            {
                Ime = Model.Ime,
                Prezime = Model.Prezime,
                Adresa = Model.Adresa,
                BlokID = Model.BlokID,
                Username = Model.Username,
                Email = Model.Email,
                DatumRegistracije = DateTime.Now,
                LozinkaHash = Model.LozinkaHash,
                LozinkaSalt = Model.LozinkaSalt,
                UlogaKorisnikaID = 3
            };

            db.Korisnik.Add(novi);
            await db.SaveChangesAsync();

            novi = db.Korisnik  // moramo ponovo učitati jer SaveChanges() ne puni 'navigation' propertije..
                .Include(k => k.Blokovi.Gradovi)
                .Include(k => k.UlogaKorisnika)
                .Where(k => k.Username == novi.Username)
                .SingleOrDefault();

            return Ok(Korisnici_Result.GetKorisnikResultInstance(novi));
        }

        // api/auth/update
        [HttpPut]
        [Route("update")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> Update([FromBody] Korisnik Model)
        {
            Korisnik k = await db.Korisnik.FindAsync(Model.KorisnikID); // provjeri je li postoji user
            if (k == null)
            {
                return BadRequest("Korisnik ne postoji!");
            }

            k.Ime = Model.Ime;
            k.Prezime = Model.Prezime;
            k.Adresa = Model.Adresa;
            k.BlokID = Model.BlokID;
            k.Telefon = Model.Telefon;
            k.Email = Model.Email;

            await db.SaveChangesAsync();
            return Ok(Korisnici_Result.GetKorisnikResultInstance(k));
        }

        // api/auth/update/password
        [HttpPut]
        [Route("update/password")]
        [MyExceptionFilter]
        public async Task<IHttpActionResult> UpdatePassword([FromBody] PasswordEditModel Model)
        {
            Korisnik k = await db.Korisnik.FindAsync(Model.KorisnikID); // provjeri je li postoji user
            if (k == null)
                return BadRequest("Korisnik ne postoji!");

            if (k.LozinkaHash != Model.LozinkaTrenutnaHash)
                return BadRequest("Pogrešna lozinka!");

            k.LozinkaHash = Model.LozinkaNovaHash;
            k.LozinkaSalt = Model.LozinkaNovaSalt;

            await db.SaveChangesAsync();
            return Ok(Korisnici_Result.GetKorisnikResultInstance(k));
        }
    }
}
