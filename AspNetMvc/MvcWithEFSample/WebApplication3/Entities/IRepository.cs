using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Entities
{
    public interface IRepository
    {
        IEnumerable<Person> GetPeople();
    }
}