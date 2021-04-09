using Microsoft.AspNetCore.Mvc;

namespace Project_Flight_Manager.Controllers
{
    public class ThingController : Controller
    {
        public ThingController()
        {
        }
        // LOCALHOST:3000/Thing/Some
        public IActionResult Some()
        {
            return this.View(); // Some.cshtml
        }

        public IActionResult Im(string name)
        {
            // database => name
            if (name == "Pesho")
            {
                return this.View("Some");
            }
            else
            {
                return this.View();
            }
        }

    }
}
