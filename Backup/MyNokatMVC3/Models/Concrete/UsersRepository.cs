using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNokatMVC3.Models.Abstract;

namespace MyNokatMVC3.Models.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        NokatModelContainer container;



        public Users GetUserByFacebookID(long pFacebookID)
        {
            throw new NotImplementedException();
        }

        public bool SaveUser(Users pUser)
        {
            bool ret = false;
            try
            {
                if (container == null)
                {
                    container = new NokatModelContainer();
                }
                container.Users.AddObject(new Users()
                {
                    AccessToken = pUser.AccessToken,
                    Expires = pUser.Expires,
                    FacebookId = pUser.FacebookId,
                    Name = pUser.Name
                });

                container.SaveChanges();
                ret = true;
            }
            catch
            {

            }
            return ret;
        }
    }
}