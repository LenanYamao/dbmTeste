using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TestDbmFront.Models;

namespace TestDbmFront.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProdutoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://testdbm:8080/Produto/GetAll");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Produto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Produto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(products);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return View(new Produto()); // Create mode

            var response = await _httpClient.GetAsync("http://testdbm:8080/Produto/Get?id=" + id);

            if (!response.IsSuccessStatusCode) return NotFound();

            var produto = JsonSerializer.Deserialize<Produto>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Produto produto)
        {
            string json = JsonSerializer.Serialize(produto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response;

            if (produto.Id == 0)
                response = await _httpClient.PostAsync("http://testdbm:8080/Produto/Post", content);
            else
                response = await _httpClient.PutAsync("http://testdbm:8080/Produto/Put", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error saving product");
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync("http://testdbm:8080/Produto/Delete?id=" + id);

            if (response.IsSuccessStatusCode)
                return Json(new { success = true });

            return Json(new { success = false });
        }
    }
}
