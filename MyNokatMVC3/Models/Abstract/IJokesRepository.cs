using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.Models.Abstract
{
    public interface IJokesRepository
    {
        IQueryable<Jokes> GetAllJokesByDate();
        IQueryable<Jokes> GetJokesByUserId(int pUserId);
        int AddJoke(int pUserId,string pJoke);
    }
}
