using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _context;
        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }
        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Rollback()
        {

        }
    }
}
