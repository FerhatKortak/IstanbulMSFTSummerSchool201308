using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers {

    public class Person {

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
    
    public class HomeController : Controller {

        public ActionResult Index() {

            IEnumerable<Person> people = new List<Person> { 
                new Person { Name = "Tugberk", Surname = "Ugurlu", Age = 26 },
                new Person { Name = "Foo", Surname = "Bar", Age = 18 }
            };

            ViewBag.Title = "People App";

            return View(people);
        }

        public ActionResult About() {

            return View();
        }

        public ActionResult Contact() {

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}