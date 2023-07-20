using Casgem_RapiApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapiApi.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityname = "London")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&London&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "4bfe6f312emshcd773f84d742925p19be5ajsnf7eaa34ab0bd" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);
                return View(value.Take(1).ToList());
            }

        }

    }
}
