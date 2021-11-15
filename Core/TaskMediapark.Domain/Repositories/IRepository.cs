using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMediapark.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public TEntity Create(TEntity entity);
    }
}
