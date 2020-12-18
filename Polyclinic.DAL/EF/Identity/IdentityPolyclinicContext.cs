using Microsoft.AspNet.Identity.EntityFramework;
using Polyclinic.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.EF.Identity
{
  public  class IdentityPolyclinicContext : IdentityDbContext<User>
    {
        public IdentityPolyclinicContext(string connectionString) : base(connectionString)
        {

        }
    }
   
}
