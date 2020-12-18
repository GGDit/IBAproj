using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Polyclinic.DAL.Entities.Identity;

namespace Polyclinic.DAL.EF.Identity
{
    public class PRoleManager:RoleManager<Role>
    {
        string connectionString;
        public PRoleManager(string connectionString) :this(new RoleStore<Role>(new IdentityPolyclinicContext(connectionString)))
        {

        }
        public PRoleManager(RoleStore<Role> store)
            : base(store)
        {
        }
    }
}
