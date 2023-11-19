using HavaMeydanlariWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HavaMeydanlariWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HavaLimanlarController : ControllerBase
    {
        public readonly ApplicationDbContext application;


        public HavaLimanlarController(ApplicationDbContext application)
        {
            this.application = application;
        }

        [HttpGet]
        public IActionResult Indexspr()
        {
            return Ok(application.HavaLimanlars.ToList());


        }

        [HttpGet("{id}")]
        public IActionResult IndexsprId(int id)
        {
            return Ok(application.HavaLimanlars.FirstOrDefault(m => m.HavaLimaniId == id));


        }


        [HttpPost]
        public IActionResult Addspr(HavaLimanlar HavaLimanlar)
        {

            application.Add(HavaLimanlar);
            application.SaveChanges();
            return Created("", HavaLimanlar);

            //ekleme
        }

        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, HavaLimanlar HavaLimanlar)
        {

            var update = application.HavaLimanlars.FirstOrDefault(i => i.HavaLimaniId == id);
            update.Yerleskesi = HavaLimanlar.Yerleskesi;
            update.Maliyeti = HavaLimanlar.Maliyeti;
            update.YolcuKapasitesi = HavaLimanlar.YolcuKapasitesi;
            update.PistSayisi = HavaLimanlar.PistSayisi;
            application.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {

            var delete = application.HavaLimanlars.FirstOrDefault(i => i.HavaLimaniId == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();

        }

    }
}
