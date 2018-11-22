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
        private static Dictionary<string, string> Cheeses = new Dictionary<string, string>();

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


        // Add a new controller to display the cheese removal form
        public IActionResult RemoveCheese()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        /*
         Could also do this (versus the above):

         public IActionREsult Index(Dictionary<string, string> cheeses) {
         
            ViewBag.Cheeses() = cheeses

            return View();

        }
         */



        [HttpPost]
        // [Route("/Cheese/AddCheese")] << Don't need this
        public IActionResult AddCheese(string cheesename, string cheesedescription, string nameError)
        {
            // Set error to an empty string by default
            nameError = "";

            // If nothing is listed for the cheese name...
            if (String.IsNullOrEmpty(cheesename) || cheesename.Length > 10 || cheesename.Length < 3)
            {
                ViewBag.nameError = "Please enter a valid name (3-10 characters in length).";

                return View(); // Use this instead of redirecting, which will wipe out the current view
            }


            // Add new cheese to exisiting cheese list
            else
            {
                Cheeses.Add(cheesename, cheesedescription);
            }
            return Redirect("/Cheese");
        }

        [HttpPost]
        [Route("/Cheese/RemoveCheese")]
        public IActionResult OldCheese(List<string> cheeseToDelete)
        {
            // Remove cheese from cheese list
            foreach (string cheeseitem in cheeseToDelete)
            {
                Cheeses.Remove(cheeseitem);
            }

            return Redirect("/Cheese");
        }
    }
}
