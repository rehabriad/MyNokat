using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNokatMVC3.Models.Abstract;
using MyNokatMVC3.Models.Concrete;

namespace MyNokatMVC3.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(string id)
        {
            return View();
        }

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
            if (jokeRep.AddJoke(pUserId, pJoke))
            {
                return "Success";
            }
            else
            {
                return "Failure";
            }
        }

    }
}
