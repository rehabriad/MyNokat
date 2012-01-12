using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNokatMVC3.Models.Abstract
{
    public interface IUsersRepository
    {
        Users GetUserByFacebookID(long pFacebookID);
        bool SaveUser(Users pUser);
    }
}
