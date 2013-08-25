using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Entities;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class FakeRepo : IRepository
    {
        public IEnumerable<Person> GetPeople()
        {
            return new List<Person> { 

                new Person { Id = 1, Name = "Tugberk" },
                new Person { Id = 2, Name = "Foo" }
            };
        }
    }

    public class HomeTest
    {
        public void Test()
        {
            var controller = new HomeController(new FakeRepo());
            // ViewResult result = controller.Index(null, null);
        }
    }

    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index(string name, int? age) 
        {
            var people = _repo.GetPeople();

            return View(new HomeViewModel { 
                Names = people.Select(person => 
                    person.Name).ToList() 
            });
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(
            string name, 
            int? age, 
            [Bind(Prefix = "Contact")]ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // Send Email

                return RedirectToAction("Index");
            }

            List<string> names = new List<string> { "Bar", "Tugberk" };
            if (name == null || !name.Equals("ahmet", StringComparison.InvariantCultureIgnoreCase))
            {
                names.Add("Foo");
            }

            return View(new HomeViewModel { Names = names, Contact = model });
        }
    }
}