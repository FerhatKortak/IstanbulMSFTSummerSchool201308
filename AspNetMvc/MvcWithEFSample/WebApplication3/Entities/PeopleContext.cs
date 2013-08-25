using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Entities
{
    public class PeopleContext : DbContext
    {
        public IDbSet<Person> People { get; set; }
    }
}