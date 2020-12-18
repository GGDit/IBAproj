using Microsoft.AspNet.Identity;
using Polyclinic.BLL.EntitiesDTO.Identity;
using Polyclinic.BLL.Infrastructure;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Entities.Identity;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork uf)
        {
            unitOfWork = uf;
        }
        public async Task<OperationDetails> AddRoleAsync(string roleName)
        {
            var role = await unitOfWork.RoleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new Role { Name = roleName };
                var result = await unitOfWork.RoleManager.CreateAsync(role);
                if (result.Succeeded)
                    return new OperationDetails(true, "Добавление роли выполнено", "");
                else
                    return new OperationDetails(false, "Роль не добавлена", "Name");
            }
            return new OperationDetails(false, "Роль уже есть", "Name");
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(string userName, string password)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await unitOfWork.UserManager.FindAsync(userName, password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await unitOfWork.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO user)
        {
            User us = await unitOfWork.UserManager.FindByNameAsync(user.UserName);
            if (us == null)
            {
                us = new User
                {
                    Email = user.Email,
                    UserName = user.UserName
                };
                var result = await unitOfWork.UserManager.CreateAsync(us, user.Password);
                if (!result.Succeeded)
                    return new OperationDetails(false, "Пациент не создан", "");
                //добавляем роли
                foreach (var item in user.Roles)
                {
                    await unitOfWork.UserManager.AddToRoleAsync(us.Id, item);
                }
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            return new OperationDetails(false, "Пациент с таким логином уже существует", "UserName");
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
            
        }

        public IList<UserDTO> GetAll()
        {
            IList<UserDTO> users = new List<UserDTO>();
            foreach (var item in unitOfWork.UserManager.Users)
            {
                UserDTO usDTO = new UserDTO
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email
                };
                foreach (var role in item.Roles)
                {
                    string roleName = unitOfWork.RoleManager.FindById(role.RoleId).Name;
                    usDTO.Roles.Add(roleName);
                }
                users.Add(usDTO);
            }
            return users;
        }
    }
}
