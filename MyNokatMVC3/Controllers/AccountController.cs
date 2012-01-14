using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MyNokatMVC3.Models;
using Facebook;
using MyNokatMVC3.Models.Abstract;
using MyNokatMVC3.Models.Concrete;
using Facebook.Web;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.Controllers
{
    public class AccountController : Controller
    {
        //private const string logoffUrl = "http://localhost:3434/";
        //private const string redirectUrl = Request.Url.Host + ":" + Request.Url.Port;

        //
        // GET: /Account/LogIn/

        public ActionResult LogIn(string returnUrl)
        {
            if (FacebookWebContext.Current.IsAuthenticated())
            {
                return RedirectToAction("Index", "Home");
            }
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }
        
        //
        // GET: /Account/LogOn/

        public ActionResult LogOn(string returnUrl)
        {
            string redirectUrl = "http://" + Request.Url.Host + "/Account/OAuth/";
            var oAuthClient = new FacebookOAuthClient(FacebookApplication.Current);
            oAuthClient.RedirectUri = new Uri(redirectUrl);
            var loginUri = oAuthClient.GetLoginUrl(new Dictionary<string, object> { { "state", returnUrl } });
            return Redirect(loginUri.AbsoluteUri);
        }

        //
        // GET: /Account/OAuth/
        
        public ActionResult OAuth(string code, string state)
        {
            FacebookOAuthResult oauthResult;
            if (FacebookOAuthResult.TryParse(Request.Url, out oauthResult))
            {
                if (oauthResult.IsSuccess)
                {
                    string redirectUrl = "http://" + Request.Url.Host + "/Account/OAuth/";
                    var oAuthClient = new FacebookOAuthClient(FacebookApplication.Current);
                    oAuthClient.RedirectUri = new Uri(redirectUrl);
                    dynamic tokenResult = oAuthClient.ExchangeCodeForAccessToken(code);
                    string accessToken = tokenResult.access_token;

                    DateTime expiresOn = DateTime.MaxValue;

                    if (tokenResult.ContainsKey("expires"))
                    {
                        DateTimeConvertor.FromUnixTime(tokenResult.expires);
                    }

                    FacebookClient fbClient = new FacebookClient(accessToken);
                    dynamic me = fbClient.Get("me?fields=id,name");
                    long facebookId = Convert.ToInt64(me.id);

                    FormsAuthentication.SetAuthCookie(facebookId.ToString(), false);

                    // prevent open redirection attack by checking if the url is local.
                    if (Url.IsLocalUrl(state))
                    {
                        return Redirect(state);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }


    }
}
