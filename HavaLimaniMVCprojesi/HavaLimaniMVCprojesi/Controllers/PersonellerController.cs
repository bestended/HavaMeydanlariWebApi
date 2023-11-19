using HavaLimaniMVCprojesi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace HavaLimaniMVCprojesi.Controllers
{
    public class PersonellerController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44343/api/Personeller").Result;

            List<Personeller> Personeller;

            Personeller = JsonConvert.DeserializeObject<List<Personeller>>(response.Content.ReadAsStringAsync().Result);

            return View(Personeller);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Personeller());


        }



        [HttpPost]
        public IActionResult Create(Personeller Personeller)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Personeller), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44343/api/Personeller", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44343/api/Personeller/{id}").Result;



            var Personeller = JsonConvert.DeserializeObject<Personeller>(response.Content.ReadAsStringAsync().Result);

            return View(Personeller);
        }

        [HttpPost]
        public IActionResult Edit(Personeller Personeller)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Personeller), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44343/api/Personeller/{Personeller.PersonelId}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44343/api/Personeller/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}
