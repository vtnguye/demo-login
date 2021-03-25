using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntities
    {
        public ShopDbContext ShopDbContext { get; set; }

        public Repository(ShopDbContext shopDbContext)
        {
            ShopDbContext = shopDbContext;
        }

        public T Find(Guid id)
        {
            return (T)ShopDbContext.Find(typeof(T), id);
        }
        public T Insert(T entity)
        {
            ShopDbContext.Add(entity);
            ShopDbContext.SaveChanges();
            return entity;
        }
        public void Delete(Guid id)
        {
            ShopDbContext.Remove(id);
            ShopDbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            ShopDbContext.Update(entity);
            ShopDbContext.SaveChanges();

        }
    }
}
