using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RapidAPIExample.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidAPIExample.Controllers
{
    public class ExchangeController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index(string tur)
        {
        if(tur != null)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={tur}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "b4c3adbfaemsh294f5a6a6d249f3p10e37cjsn96cc2e085b4d" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                    return View(list.exchange_rates.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "b4c3adbfaemsh294f5a6a6d249f3p10e37cjsn96cc2e085b4d" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                    return View(list.exchange_rates.ToList());
                }
            }
            
        }
    }
}

