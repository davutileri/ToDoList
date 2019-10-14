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
    public class ToDoListItemRepository : BaseEntityRepository<ToDoListItem>, IToDoListItemRepository
    {
        public List<ToDoListItem> GetToDoListItemByFilter(Expression<Func<ToDoListItem, bool>> filter = null)
        {
            using (var context = new ToDoListDbContext())
            {
                return context.ToDoListItems.Where(filter).ToList();
            }
        }
    }
}
