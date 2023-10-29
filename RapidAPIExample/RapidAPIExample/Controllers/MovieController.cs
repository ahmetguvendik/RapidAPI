using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIExample.Models;
using System.Net.Http.Headers;
using static RapidAPIExample.Models.MovieViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidAPIExample.Controllers
{
    public class MovieController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://movies-tv-shows-database.p.rapidapi.com/?page=1"),
                Headers =
    {
        { "Type", "get-boxoffice-movies" },
        { "X-RapidAPI-Key", "b4c3adbfaemsh294f5a6a6d249f3p10e37cjsn96cc2e085b4d" },
        { "X-RapidAPI-Host", "movies-tv-shows-database.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<MovieViewModel>(body);
                return View(list.movie_results.ToList());
            }

        }
    }
}

