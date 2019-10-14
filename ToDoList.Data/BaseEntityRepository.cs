using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListCore;
using ToDoListData.Entities;

namespace ToDoListData
{
    public class BaseEntityRepository<T> : IEntityRepository<T> where T : BaseEntity, IEntity
    {
        public void Add(T entity)
        {
            using (var context = new ToDoListDbContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new ToDoListDbContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var context = new ToDoListDbContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public IList<T> GetList()
        {
            using (var context = new ToDoListDbContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new ToDoListDbContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
