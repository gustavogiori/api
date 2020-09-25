using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.User;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class UserService : Service<UserEntity, int>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}
