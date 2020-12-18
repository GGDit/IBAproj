using Polyclinic.BLL.EntitiesDTO.Identity;
using Polyclinic.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Interfaces
{
  public  interface IUserService:IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO user);
        IList<UserDTO> GetAll();
        Task<ClaimsIdentity> AuthenticateAsync(string userName, string password);
        Task<OperationDetails> AddRoleAsync(string role);
    }
}
