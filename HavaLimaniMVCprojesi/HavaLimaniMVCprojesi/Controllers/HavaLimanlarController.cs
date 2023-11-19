using HavaLimaniMVCprojesi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace HavaLimaniMVCprojesi.Controllers
{
    public class HavaLimanlarController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44343/api/HavaLimanlar").Result;

            List<HavaLimanlar> HavaLimanlar;

            HavaLimanlar = JsonConvert.DeserializeObject<List<HavaLimanlar>>(response.Content.ReadAsStringAsync().Result);

            return View(HavaLimanlar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new HavaLimanlar());


        }



        [HttpPost]
        public IActionResult Create(HavaLimanlar HavaLimanlar)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(HavaLimanlar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44343/api/HavaLimanlar", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44343/api/HavaLimanlar/{id}").Result;



            var HavaLimanlar = JsonConvert.DeserializeObject<HavaLimanlar>(response.Content.ReadAsStringAsync().Result);

            return View(HavaLimanlar);
        }

        [HttpPost]
        public IActionResult Edit(HavaLimanlar HavaLimanlar)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(HavaLimanlar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44343/api/HavaLimanlar/{HavaLimanlar.HavaLimaniId}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44343/api/HavaLimanlar/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}
