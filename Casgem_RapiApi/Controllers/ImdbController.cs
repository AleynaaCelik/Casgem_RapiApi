using Casgem_RapiApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapiApi.Controllers
{
    public class ImdbController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            //List<ImdbNovieListViewModel> model = new List<ImdbNovieListViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "4bfe6f312emshcd773f84d742925p19be5ajsnf7eaa34ab0bd" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
               var model = JsonConvert.DeserializeObject<List<ImdbNovieListViewModel>>(body);
                return View(model.ToList());
            }
            return View();
        }
    }
}
