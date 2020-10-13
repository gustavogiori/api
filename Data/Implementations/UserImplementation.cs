using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Implementations
{
    public class UserImplementation : Repository<UserEntity, int>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;
        public UserImplementation(DbContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }
    }
}
