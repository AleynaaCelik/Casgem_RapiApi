using Casgem_RapiApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_RapiApi.Controllers
{
    public class BookingController : Controller
    {
       
        public async Task<IActionResult> Index(string adult="1",string child = "1", string checkinDate = "2023-09-27", string checkoutDate = "2023-09-28", string roomNumber = "1", string cityId = "-553173")
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkinDate}&filter_by_currency=USD&dest_id={cityId}&locale=en-gb&checkout_date={checkoutDate}&units=metric&room_number={roomNumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
                var values = JsonConvert.DeserializeObject<HotelListViewModel>(body);
                return View(values.results.ToList());
            }
           

        }
        

    }
}

