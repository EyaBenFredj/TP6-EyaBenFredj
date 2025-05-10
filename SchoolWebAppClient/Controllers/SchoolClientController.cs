using Microsoft.AspNetCore.Mvc;
using SchoolWebAppClient.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace SchoolWebAppClient.Controllers
{
    public class SchoolClientController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:7189/api/Schools"; // Make sure this matches YOUR Swagger URL

        public SchoolClientController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: /SchoolClient/GetAllSchools
        public async Task<IActionResult> GetAllSchools()
        {
            try
            {
                var schools = await _httpClient.GetFromJsonAsync<List<SchoolClient>>(_apiUrl);
                return View(schools ?? new List<SchoolClient>());
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"Erreur lors de la récupération des écoles : {ex.Message}";
                return View(new List<SchoolClient>());
            }
        }

        // GET: /SchoolClient/GetSchoolById/1
        public async Task<IActionResult> GetSchoolById(int id)
        {
            try
            {
                var school = await _httpClient.GetFromJsonAsync<SchoolClient>($"{_apiUrl}/{id}");
                if (school == null)
                    return NotFound();

                return View(school);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"Erreur lors de la récupération de l'école : {ex.Message}";
                return View();
            }
        }

        // GET: /SchoolClient/GetSchoolByName?keyword=ENISo
        public async Task<IActionResult> GetSchoolByName(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return View(new List<SchoolClient>());

                var result = await _httpClient.GetFromJsonAsync<List<SchoolClient>>($"{_apiUrl}/search-by-name/{keyword}");
                return View(result ?? new List<SchoolClient>());
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"Erreur lors de la recherche : {ex.Message}";
                return View(new List<SchoolClient>());
            }
        }

        // GET: /SchoolClient/CreateSchool
        [HttpGet]
        public IActionResult CreateSchool()
        {
            return View();
        }

        // POST: /SchoolClient/CreateSchool
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSchool(SchoolClient school)
        {
            if (!ModelState.IsValid)
                return View(school);

            var response = await _httpClient.PostAsJsonAsync(_apiUrl, school);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetAllSchools");

            ViewBag.Error = "Erreur lors de la création de l'école.";
            return View(school);
        }

        // GET: /SchoolClient/EditSchool/1
        [HttpGet]
        public async Task<IActionResult> EditSchool(int id)
        {
            var school = await _httpClient.GetFromJsonAsync<SchoolClient>($"{_apiUrl}/{id}");
            if (school == null)
                return NotFound();

            return View(school);
        }

        // POST: /SchoolClient/EditSchool/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSchool(int id, SchoolClient school)
        {
            if (!ModelState.IsValid)
                return View(school);

            var response = await _httpClient.PutAsJsonAsync($"{_apiUrl}/{id}", school);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetAllSchools");

            ViewBag.Error = "Erreur lors de la modification de l'école.";
            return View(school);
        }

        // GET: /SchoolClient/DeleteSchool/1
        [HttpGet]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _httpClient.GetFromJsonAsync<SchoolClient>($"{_apiUrl}/{id}");
            if (school == null)
                return NotFound();

            return View(school);
        }

        // POST: /SchoolClient/DeleteConfirmed/1
        [HttpPost, ActionName("DeleteSchool")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetAllSchools");

            ViewBag.Error = "Erreur lors de la suppression de l'école.";
            return RedirectToAction("DeleteSchool", new { id });
        }
    }
}