using HavaLimaniMVCprojesi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace HavaLimaniMVCprojesi.Controllers
{
    public class UcaklarController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44343/api/Ucaklar").Result;

            List<Ucaklar> Ucaklar;

            Ucaklar = JsonConvert.DeserializeObject<List<Ucaklar>>(response.Content.ReadAsStringAsync().Result);

            return View(Ucaklar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Ucaklar());


        }



        [HttpPost]
        public IActionResult Create(Ucaklar Ucaklar)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Ucaklar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44343/api/Ucaklar", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44343/api/Ucaklar/{id}").Result;



            var Ucaklar = JsonConvert.DeserializeObject<Ucaklar>(response.Content.ReadAsStringAsync().Result);

            return View(Ucaklar);
        }

        [HttpPost]
        public IActionResult Edit(Ucaklar Ucaklar)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Ucaklar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44343/api/Ucaklar/{Ucaklar.UcakId}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44343/api/Ucaklar/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}
