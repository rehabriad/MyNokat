using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNokatMVC3.Models;
using Facebook;
using Facebook.Web.Mvc;
using Facebook.Web;
using System.Configuration;
using MyNokatMVC3.Models.Abstract;
using MyNokatMVC3.Models.Concrete;
using MyNokatMVC3.Models.Entities;
using MyNokatMVC3.ViewModels;

namespace MyNokatMVC3.Controllers
{
    public class HomeController : Controller
    {
        [FacebookAuthorize(LoginUrl = "/Account/Logon")]        
        public ActionResult Index()
        {
            var client = new FacebookWebClient();
            dynamic me = client.Get("me");
            ViewBag.Name = me.name;
            ViewBag.Id = me.id.ToString();

            JokesFeedViewModel model = new JokesFeedViewModel();
            model.UserName = me.name;
            model.UserId = me.id;            
            IJokesRepository jokeRep = new JokesRepository();
            IVotesRepository votesRep=new VotesRepository();
            List<Jokes> allJokes = jokeRep.GetAllJokesByDate().ToList<Jokes>();
            if (allJokes != null)
            {
                foreach (Jokes joke in allJokes)
                {
                    joke.UserVoteType = votesRep.GetCurrentUserVote(joke.JokeId, joke.UserId);
                    joke.UpVotesCount = votesRep.GetJokesVotesCount(joke.JokeId, true);
                    joke.DownVotesCount = votesRep.GetJokesVotesCount(joke.JokeId, false);
                    dynamic jUser = client.Get(joke.UserId.ToString());
                    joke.UserName = jUser.name;
                }
                model.Jokes = allJokes;
            }

            return View(model);
        }

    }
}
