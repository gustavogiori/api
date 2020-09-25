using Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services.Token
{
    public interface ITokeService
    {
        string GenerateToken(UserDto user);
    }
}
