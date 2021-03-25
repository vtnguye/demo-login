using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repository
{
    interface IRepository<T> where T : BaseEntities
    {
        void Delete(string id);
        T Find(string id);
        T Insert(T entity);
        void Update(T entity);
    }
}
