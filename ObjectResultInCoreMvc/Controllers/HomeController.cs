using Microsoft.AspNetCore.Mvc;
using ObjectResultInCoreMvc.Models;
using System.Diagnostics;

namespace ObjectResultInCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetPerson()
        //{
        //    var person = new { FirstName = "Mukesh", LastName = "Kumar", Age = 34 };

        //    // Return an ObjectResult with JSON serialization
        //    return new ObjectResult(person);

        //    // Or use the shorthand:
        //    // return Ok(person);
        //}

        //set the status code, content type, and other properties of the response using the properties of the ObjectResult class
        public IActionResult GetPerson()
        {
            var person = new { FirstName = "Mukesh", LastName = "Kumar", Age = 34 };

            var Results = new ObjectResult(person)
            {
                StatusCode = 200,
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
                {
                    //"application/json"
                }
            };
            return Results;
        }

        public IActionResult GetPersonOk()
        {
            var person = new { FirstName = "Mukesh", LastName = "Kumar", Age = 34 };
            return Ok(person);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}