using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using HavaLimaniMVCprojesi.Models;
using System.Collections.Generic;

namespace HavaLimaniMVCprojesi.Controllers
{
    public class FirmalarController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44343/api/Firmalar").Result;

            List<Firmalar> Firmalar;

            Firmalar = JsonConvert.DeserializeObject<List<Firmalar>>(response.Content.ReadAsStringAsync().Result);

            return View(Firmalar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Firmalar());


        }



        [HttpPost]
        public IActionResult Create(Firmalar Firmalar)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Firmalar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44343/api/Firmalar", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44343/api/Firmalar/{id}").Result;



            var Firmalar = JsonConvert.DeserializeObject<Firmalar>(response.Content.ReadAsStringAsync().Result);

            return View(Firmalar);
        }

        [HttpPost]
        public IActionResult Edit(Firmalar firmalar)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(firmalar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44343/api/Firmalar/{firmalar.FirmaId}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44343/api/Firmalar/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}
