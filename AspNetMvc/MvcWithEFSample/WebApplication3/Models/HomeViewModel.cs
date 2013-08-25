using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class HomeViewModel
    {
        public List<string> Names { get; set; }
        public ContactModel Contact { get; set; }
    }
}