using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.ViewModels
{
    public class JokesFeedViewModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }        
        public List<Jokes> Jokes { get; set; }
                
    }
}