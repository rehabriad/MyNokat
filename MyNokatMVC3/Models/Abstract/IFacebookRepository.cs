using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNokatMVC3.Models.Entities;

namespace MyNokatMVC3.Models.Abstract
{
    interface IFacebookRepository
    {
        void ShareToWall(FacebookMessage pMessage, string pUserId);
        string GetAppAccessToken();
    }
}
