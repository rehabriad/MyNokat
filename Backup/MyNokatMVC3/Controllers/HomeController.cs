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

namespace MyNokatMVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";            
            return View();
        }

        //
        // GET: /Home/ProfileInfo/

        [Authorize]
        public ActionResult ProfileInfo()
        {
            NokatModelContainer container = new NokatModelContainer();
            var facebookId = long.Parse(User.Identity.Name);
            //container.UsersSet.Select(i => i.FacebookId = facebookId);
            Users user = container.Users.Where(i => i.FacebookId == facebookId).FirstOrDefault();
            container.Dispose();
            var client = new FacebookClient(user.AccessToken);
            dynamic me = client.Get("me");
            ViewBag.Name = me.name;
            return View();
        }



        [FacebookAuthorize(LoginUrl = "/Account/Login")]
        public ActionResult Profile()
        {
            var client = new FacebookWebClient();

            dynamic me = client.Get("me");
            ViewBag.Name = me.name;
            ViewBag.Id = me.id;

            return View();
        }

        [Authorize]
        public ActionResult PostMesSage()
        {
            //IFacebookRepository fb = new FacebookRepository();
            //fb.Publish(new FacebookMessage { Message = "Hello World!" });
            return View();
        }

        [HttpPost]
        public string PostMessage(int pUserId, string pJoke)
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
