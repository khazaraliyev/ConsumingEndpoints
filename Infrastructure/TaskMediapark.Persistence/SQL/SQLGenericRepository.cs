using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.Repositories;

namespace TaskMediapark.Persistence.SQL.Abstract
{
    public class SQLGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public readonly MediaparkDbContext dbContext;
        private DbSet<TEntity> entities;
        public SQLGenericRepository(MediaparkDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }
        public TEntity Create(TEntity entity)
        {
            entities.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
