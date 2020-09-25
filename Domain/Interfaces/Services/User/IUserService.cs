using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services.User
{
    public interface IUserService : IService<UserEntity, int>
    {
    }
}
