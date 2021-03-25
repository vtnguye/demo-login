using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repository
{
    public interface IRepository<T> where T : BaseEntities
    {
        void Delete(Guid id);
        T Find(Guid id);
        T Insert(T entity);
        void Update(T entity);
    }
}
