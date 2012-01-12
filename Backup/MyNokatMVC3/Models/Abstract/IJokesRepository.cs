using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNokatMVC3.Models.Abstract
{
    public interface IJokesRepository
    {
        IQueryable<Jokes> GetAllJokesByDate();
        IQueryable<Jokes> GetJokesByUserId(int pUserId);
        bool AddJoke(int pUserId,string pJoke);
    }
}
