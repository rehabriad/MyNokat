using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models.Abstract;

namespace MyNokatMVC3.Models.Concrete
{
    public class JokesRepository:IJokesRepository
    {
        NokatModelContainer container;
        public IQueryable<Jokes> GetAllJokesByDate()
        {
            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }

                var retJokes = container.Jokes.AsQueryable();
                return retJokes;
            }
            catch
            {
                return null;
            }            
        }

        public IQueryable<Jokes> GetJokesByUserId(int pUserId)
        {
            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }

                var retJokes = container.Jokes.Where(i=>i.UserId==pUserId).AsQueryable<Jokes>();
                return retJokes;
            }
            catch
            {
                return null;
            }  
        }


        public bool AddJoke(int pUserId, string pJoke)
        {
            bool ret = false;
            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }

                container.AddToJokes(new Jokes() { UserId = pUserId, Joke = pJoke, AddDate=DateTime.Now });
                container.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}