using Polyclinic.DAL.EF.Identity;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Repositories.Identity
{
    class IdentityUnitOfWork : IUnitOfWork
    {
        string connectionString;
        PRoleManager roleManager;
        PolyclinicUserManager userManager;

        public IdentityUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
            roleManager = new PRoleManager(connectionString); 
            userManager = new PolyclinicUserManager(connectionString);
        }

        public PRoleManager RoleManager => roleManager;

        public PolyclinicUserManager UserManager => userManager;

        public void Dispose()
        {
            userManager.Dispose();
            roleManager.Dispose();
        }
    }
}
