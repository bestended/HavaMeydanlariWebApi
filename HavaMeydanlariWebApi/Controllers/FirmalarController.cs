using HavaMeydanlariWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HavaMeydanlariWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmalarController : ControllerBase
    {

        public readonly ApplicationDbContext application;


        public FirmalarController(ApplicationDbContext application)
        {
            this.application = application;
        }

        [HttpGet]   
        public IActionResult Indexspr()
        {
            return Ok(application.Firmalars.ToList());


        }

        [HttpGet("{id}")]   
        public IActionResult IndexsprId(int id)
        {
            return Ok(application.Firmalars.FirstOrDefault(m => m.FirmaId == id));


        }


        [HttpPost]
        public IActionResult Addspr(Firmalar Firmalar)
        {

            application.Add(Firmalar);
            application.SaveChanges();
            return Created("", Firmalar);

            //ekleme
        }

        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Firmalar firmalar)
        {

            var update = application.Firmalars.FirstOrDefault(i => i.FirmaId == id);
            update.FirmaAdi = firmalar.FirmaAdi;
            update.FirmaBütcesi = firmalar.FirmaBütcesi;
            update.FirmaMerkezi = firmalar.FirmaMerkezi;
            update.FirmaTelefon = firmalar.FirmaTelefon;
            application.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {

            var delete = application.Firmalars.FirstOrDefault(i => i.FirmaId == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();

        }



    }
}
