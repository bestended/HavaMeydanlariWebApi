using HavaMeydanlariWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HavaMeydanlariWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcaklarController : ControllerBase
    {
        public readonly ApplicationDbContext application;


        public UcaklarController(ApplicationDbContext application)
        {
            this.application = application;
        }

        [HttpGet]
        public IActionResult Indexspr()
        {
            return Ok(application.Ucaklars.ToList());


        }

        [HttpGet("{id}")]
        public IActionResult IndexsprId(int id)
        {
            return Ok(application.Ucaklars.FirstOrDefault(m => m.UcakId == id));


        }


        [HttpPost]
        public IActionResult Addspr(Ucaklar ucaklar)
        {

            application.Add(ucaklar);
            application.SaveChanges();
            return Created("", ucaklar);


        }

        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Ucaklar ucaklar)
        {

            var update = application.Ucaklars.FirstOrDefault(i => i.UcakId == id);
            update.UcakRengi = ucaklar.UcakRengi;
            update.UcakTipi = ucaklar.UcakTipi;
            update.YolcuKapasitesi = ucaklar.YolcuKapasitesi;
            update.UcakGenislik = ucaklar.UcakGenislik;
            update.BiletFiyati = ucaklar.BiletFiyati;
            update.FirmaId = ucaklar.FirmaId;
         
            application.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {

            var delete = application.Ucaklars.FirstOrDefault(i => i.UcakId == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();

        }

    }
}
