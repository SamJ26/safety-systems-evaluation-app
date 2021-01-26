using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities;
using SSEA.DAL.Factories;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL
{
    public class UnitOfWork<TEntity> : IDisposable where TEntity : EntityBase
    {
        public AppDbContext DbContext;
        public Repository<TEntity> Repository;

        public UnitOfWork(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            DbContext = dbContextFactory.CreateDbContext();
            Repository = new Repository<TEntity>(DbContext);
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
