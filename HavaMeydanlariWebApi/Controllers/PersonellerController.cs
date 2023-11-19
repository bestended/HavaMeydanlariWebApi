using HavaMeydanlariWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HavaMeydanlariWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonellerController : ControllerBase
    {
        public readonly ApplicationDbContext application;


        public PersonellerController(ApplicationDbContext application)
        {
            this.application = application;
        }

        [HttpGet]
        public IActionResult Indexspr()
        {
            return Ok(application.Personellers.ToList());


        }

        [HttpGet("{id}")]
        public IActionResult IndexsprId(int id)
        {
            return Ok(application.Personellers.FirstOrDefault(m => m.PersonelId == id));


        }


        [HttpPost]
        public IActionResult Addspr(Personeller Personeller)
        {

            application.Add(Personeller);
            application.SaveChanges();
            return Created("", Personeller);

          
        }

        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Personeller Personeller)
        {

            var update = application.Personellers.FirstOrDefault(i => i.PersonelId == id);
            update.PersonelAdi = Personeller.PersonelAdi;
            update.PersonelSoyadi = Personeller.PersonelSoyadi;
            update.Yas = Personeller.Yas;
            update.CalismaTarih = Personeller.CalismaTarih;
            update.Vardiya = Personeller.Vardiya;
            update.UcakId = Personeller.UcakId;
            update.HavaLimaniId = Personeller.HavaLimaniId;

            application.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {

            var delete = application.Personellers.FirstOrDefault(i => i.PersonelId == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();

        }

    }
}
