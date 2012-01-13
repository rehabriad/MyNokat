using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNokatMVC3.Models.Abstract;
using MyNokatMVC3.Models.Concrete;
using Facebook.Web;
using MyNokatMVC3.ViewModels;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(string id)
        {
            var client = new FacebookWebClient();
            dynamic me = client.Get("me");
            ViewBag.Name = me.name;
            ViewBag.Id = me.id.ToString();

            JokesFeedViewModel model = new JokesFeedViewModel();
            model.UserName = me.name;
            model.UserId = me.id;

            dynamic jUser = client.Get(id.ToString());
            string userName= jUser.name;

            IJokesRepository jokeRep = new JokesRepository();
            IVotesRepository votesRep = new VotesRepository();
            List<Jokes> allJokes = jokeRep.GetJokesByUserId(int.Parse(id)).ToList<Jokes>();
            if (allJokes != null)
            {
                foreach (Jokes joke in allJokes)
                {
                    joke.UserVoteType = votesRep.GetCurrentUserVote(joke.JokeId, joke.UserId);
                    joke.UpVotesCount = votesRep.GetJokesVotesCount(joke.JokeId, true);
                    joke.DownVotesCount = votesRep.GetJokesVotesCount(joke.JokeId, false);
                    joke.UserName=userName;
                    
                }
                model.Jokes = allJokes;
            }
            ViewBag.Name = userName +"'s Page";
            return View("PostsMain", model);
        }

        [HttpPost]
        public string VoteToJoke(long pUserId,int pJokeId,bool pVoteType)
        {
            IVotesRepository votesRep = new VotesRepository();
            if (votesRep.AddVote(pJokeId,pUserId,pVoteType))
            {
                return "Success";
            }
            else
            {
                return "Failure";
            }
        }

        [HttpPost]
        public string PostJoke(int pUserId, string pJoke)
        {
            IJokesRepository jokeRep = new JokesRepository();
            return jokeRep.AddJoke(pUserId, pJoke).ToString();

        }

    }
}
