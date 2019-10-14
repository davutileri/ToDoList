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
    public class UserRepository : BaseEntityRepository<User>, IUserRepository
    {
        public List<User> GetUserListByFilter(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new ToDoListDbContext())
            {
                return context.Users.Where(filter).ToList();
            }
        }
    }
}
