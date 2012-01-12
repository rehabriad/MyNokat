using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models.Entities;
using Facebook;
using System.Configuration;
using MyNokatMVC3.Models.Abstract;

namespace MyNokatMVC3.Models.Concrete
{
    public class FacebookRepository : IFacebookRepository
    {
        //public string
        public void Publish(FacebookMessage pMessage)
        {
            var args = new Dictionary<string, object>();
            args["message"] = pMessage.Message  ;
            args["caption"] = pMessage.ArticleCaption ;
            args["description"] = pMessage.Description ;
            args["name"] = pMessage.Title;
            args["picture"] = pMessage.PhotoLink;
            args["link"] = pMessage.ArticleLink ;

            string path = "340791049284352" + "/feed";
            var fbApp = new FacebookClient(GetAppAccessToken());
            //fbApp.Post(path, args);
            dynamic dnm=fbApp.Get(path);
        }


        public string GetAppAccessToken()
        {
            
            var fb = new FacebookOAuthClient { AppId = "340791049284352", AppSecret = "c46526d851aaf7dd547a63ae332d3e49" };
            dynamic result = fb.GetApplicationAccessToken();
            var appAccessToken = result.access_token;
            return appAccessToken.ToString();
        }

    }
}