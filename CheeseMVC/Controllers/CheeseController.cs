using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // static means it is available to any code within the class
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            /* List<string> cheeses = new List<string>();

            cheeses.Add("Cheddar");
            cheeses.Add("Swiss");
            cheeses.Add("Asiago"); */

            // ViewBag.cheeses from view, Cheeses from controller
            ViewBag.cheeses = Cheeses; // Able to relate list/dictionary in controller to viewer

            return View();
        }

        // Add a new controller to display the cheese addition form
        public IActionResult AddCheese()
        {
            return View();
        }

        // Handles add cheese form submissions and let user add new cheese to list

        [HttpPost]
        [Route("/Cheese/AddCheese")]
        public IActionResult NewCheese(string cheesename, string cheesedescription)
        {
            // Add new cheese to exisiting cheese list

            Cheeses.Add(cheesename, cheesedescription);

            return Redirect("/Cheese");
        }
    }

}
