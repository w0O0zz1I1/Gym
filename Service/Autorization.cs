using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Autorization
    {
        public static bool Login(string login, string password)
        {
            using(ModelDataBaseContainer container = new ModelDataBaseContainer())
            {
                var user = container.Users.FirstOrDefault(x => x.Login == login);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    if(user.Password== password)
                    {
                        GlobalContainer.Role = user.Role.RoleName;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
