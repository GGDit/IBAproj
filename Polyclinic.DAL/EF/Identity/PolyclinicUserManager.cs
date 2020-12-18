using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Polyclinic.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.EF.Identity
{
  public  class PolyclinicUserManager : UserManager<User>
    {
        string connectionString;
        public PolyclinicUserManager(IUserStore<User> store)
            : base(store)
        {
        }
        public PolyclinicUserManager(string connectionString):this(new UserStore<User>(new IdentityPolyclinicContext(connectionString)))
        {

        }
    }
}
