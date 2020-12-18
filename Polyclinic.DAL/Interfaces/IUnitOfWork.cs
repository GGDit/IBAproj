using Polyclinic.DAL.EF.Identity;
using System;

namespace Polyclinic.DAL.Interfaces
{
  public  interface IUnitOfWork:IDisposable
    {
        PRoleManager RoleManager { get; }
        PolyclinicUserManager UserManager { get; }
    }
}
