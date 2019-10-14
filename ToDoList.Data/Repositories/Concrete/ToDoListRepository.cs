using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoListData.Entities;
using ToDoListData.Repositories.Abstract;

namespace ToDoListData.Repositories.Concrete
{
    public class ToDoListRepsitory : BaseEntityRepository<ToDoList>, IToDoListRepository
    {
        public List<ToDoList> GetToDoListByFilter(Expression<Func<ToDoList, bool>> filter = null)
        {
            using (var context = new ToDoListDbContext())
            {
                return context.ToDoLists.Where(filter).ToList();
            }
        }
    }
}
