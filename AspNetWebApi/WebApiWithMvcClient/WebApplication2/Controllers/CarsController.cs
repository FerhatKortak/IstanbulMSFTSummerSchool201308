using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApplication2.Controllers {

    public class Car {

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    public class CarRequestModel {

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    public class CarsController : ApiController {

        public IEnumerable<Car> GetCars() {

            return new List<Car> { 
                new Car { Id = 1, Make = "Murat", Model = "131", Year = 1800 },
                new Car { Id = 2, Make = "Serçe", Model = "??", Year = 1700 }
            };
        }

        public string GetCar(string id) {

            return "Car " + id;
        }

        public HttpResponseMessage PostCar(CarRequestModel car) { 

            // Added car obj to database

            var newCar = new Car {
                Id = 1,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year
            };

            var response = Request.CreateResponse(HttpStatusCode.Created, newCar);
            return response;
        } 
    }
}