using Microsoft.AspNetCore.Mvc;

namespace Casgem_RapiApi.Controllers
{
    public class BookingController : Controller
    {
       
        public async Task<IActionResult> Index(string adult,string child,string checkinDate,string checkoutDate,string roomNumber,string cityId)
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
                Console.WriteLine(body);
            }
            return View();

        }
        

    }
}

