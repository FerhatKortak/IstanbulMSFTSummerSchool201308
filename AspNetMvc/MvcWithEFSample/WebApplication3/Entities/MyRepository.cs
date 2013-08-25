using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Entities
{
    public class MyRepository : IRepository
    {
        private readonly PeopleContext _ctx;

        public MyRepository()
        {
            _ctx = new PeopleContext();
        }

        public IEnumerable<Person> GetPeople()
        {
            return _ctx.People.ToList();
        }
    }
}