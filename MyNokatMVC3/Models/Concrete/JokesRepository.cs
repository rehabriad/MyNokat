using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models.Abstract;
using MyNokatMVC3.Models.Entities;

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

                var retJokes = container.Jokes.OrderByDescending(i=>i.AddDate).AsQueryable();
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

                var retJokes = container.Jokes.Where(i => i.UserId == pUserId).OrderByDescending(i => i.AddDate).AsQueryable<Jokes>();
                return retJokes;
            }
            catch
            {
                return null;
            }  
        }


        public int AddJoke(int pUserId, string pJoke)
        {
            int ret = 0;
            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }

                Jokes newJoke = new Jokes(){ UserId = pUserId, Joke = pJoke, AddDate=DateTime.Now };

                container.AddToJokes(newJoke);
                container.SaveChanges();
                ret = newJoke.JokeId;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}