using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCore
{
    public interface IEntityRepository<T> where T : IEntity
    {
        T GetById(int id);
        IList<T> GetList();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
