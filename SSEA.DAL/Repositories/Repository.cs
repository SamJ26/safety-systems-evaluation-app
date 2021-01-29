using SSEA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSEA.DAL.Repositories
{
    public class Repository<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return dbContext.Set<TEntity>().SingleOrDefault(entity => entity.Id == id);
        }

        public int Insert(TEntity entity)
        {
            dbContext.Add(entity);
            return entity.Id;
        }

        public int Update(TEntity entity)
        {
            dbContext.Update(entity);
            return entity.Id;
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
